using LifeServer.DataModel.request;
using log4net;
using System;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Xml;
using System.Xml.Linq;
using WOW.LifePortraitsWebAuthentication.AgentAccountServiceReference;
using WOW.LifePortraitsWebAuthentication.Exceptions;
using WOW.LifePortraitsWebAuthentication.Models;
using WOW.LifePortraitsWebAuthentication.Properties;
using WOW.LifePortraitsWebAuthentication.Code;
using System.Xml.Serialization;
using System.IO;

namespace WOW.LifePortraitsWebAuthentication.Controllers
{
    public class IntegrationController : ApiController
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(IntegrationController));

        /// <summary>
        /// WebAPI method that starts a new user session for the provided username
        /// and returns the URL for the client to redirect to.
        /// </summary>
        /// <param name="Username">Woodmen Active Directory Username</param>
        /// <returns>URL to the LPA web application with a session ID</returns>
        [ActionName("RequestLpaSession")]
        [HttpGet]
        public string RequestLpaSession(string Username)
        {
            try
            {
                if (log.IsDebugEnabled) { log.DebugFormat(CultureInfo.InvariantCulture, "RequestLpaSession requested with username {0}.", Username); }

                // Create new authorization request model object
                var authRequest = new AuthorizationRequest();

                // Assign provided values now
                authRequest.Username = Username;
                authRequest.RequestDate = DateTime.Now;

                // Perform AD lookups
                LookupFullName(authRequest);
                DetermineUserType(authRequest);

                // Request a new LPA session and return the URL to the calling client
                return RequestNewSession(authRequest);
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled) { log.Error("There was an error processing the LPA integration request.", ex); }

                return String.Format("{0}?ErrorCode={1}&ErrorMessage={2}", Settings.Default.AuthErrorUrl, 500, HttpUtility.UrlEncode(ex.Message));
            }
        }

        /// <summary>
        /// This method queries Active Directory with the Username property of the AuthorizationRequest object
        /// and assigns the GivenName and Surname values to the object's related properties.
        /// </summary>
        /// <param name="authRequest">Object model for user requesting LPA access</param>
        private void LookupFullName(AuthorizationRequest authRequest)
        {
            // Check that object is at least not null
            if (authRequest == null)
            {
                throw new ArgumentNullException("authRequest", "AuthorizationRequest object cannot be null.");
            }

            try
            {
                // Create context object for the configured AD Domain
                if (log.IsDebugEnabled) { log.DebugFormat(CultureInfo.InvariantCulture, "Looking up user '{0}' in ActiveDirectory for domain '{1}'.", authRequest.Username, Settings.Default.ActiveDirectoryDomainName); }

                using (var pc = new PrincipalContext(ContextType.Domain, Settings.Default.ActiveDirectoryDomainName))
                {
                    // Perform Active Directory lookup by username and try to find the user's first name and last name.
                    var user = UserPrincipal.FindByIdentity(pc, authRequest.Username);

                    // Copy values to the auth object
                    authRequest.FirstName = user.GivenName;
                    authRequest.LastName = user.Surname;

                    if (log.IsDebugEnabled) { log.DebugFormat(CultureInfo.InvariantCulture, "Found '{0} {1}' for user '{2}'.", user.GivenName, user.Surname, authRequest.Username); }
                }
            }
            catch (Exception ex)
            {
                // Error will be logged by the calling method
                throw new SessionException(String.Format(CultureInfo.InvariantCulture, "There was an error looking up user '{0}' in Active Directory. The user may not exist.", authRequest.Username), ex);
            }
        }

        /// <summary>
        /// This method generates a XML payload for LPA to consume based on the type of user trying to 
        /// access LPA.
        /// </summary>
        /// <param name="authRequest">Object model for user requesting LPA access</param>
        /// <returns> The full URL to the web application with the session ID</returns>
        private string RequestNewSession(AuthorizationRequest authRequest)
        {
            // Null check
            if (authRequest == null)
            {
                throw new ArgumentNullException("authRequest", "authRequest object cannot be null.");
            }

            // Make sure we know the user type before doing anything
            if (authRequest.UserType == AuthorizationRequest.LpaUserType.Unknown)
            {
                throw new SessionException("A new LifePortraits session cannot be started. The LifePortraits Web Authentication Service could not determine your user type. It is likely that you are not authorized via Active Directory to access LifePortraits. Please contact your manager or the Help Desk.");
            }

            try
            {
                DataFunctions dataFunctions = new DataFunctions();
                string tempAccountId = string.Empty;

                // Override SSL validation for non-PROD regions
                if (Settings.Default.BypassSSLValidation)
                {
                    if (log.IsDebugEnabled) { log.Debug("Bypassing SSL validation."); }

                    System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                }

                // Fetch URLs from config
                var successUrl = Settings.Default.LpaUrl;
                var errorUrl = Settings.Default.AuthErrorUrl;

                // Create data objects from StoneRiver's LifeServer library
                var data = new AgentAccountSetupData();
                data.AUTHENTICATION = new AgentAccountSetupDataAUTHENTICATION();
                data.AGENT = new AgentAccountSetupDataAGENT();

                var profile = new AgentAccountSetupDataAGENTPROFILE();
                data.AGENT.PROFILES.Add(profile);

                // Not sure if we'll need authentication here yet
                data.AUTHENTICATION.USERID = String.Empty;
                data.AUTHENTICATION.PASSWORD = String.Empty;

                // Populate data
                data.AGENT.UNIQUEID = authRequest.Username;
                data.AGENT.UNIQUEPASS = String.Empty; // Password not required by service and not available to MyWoodmen
                data.AGENT.FIRSTNAME = authRequest.FirstName;
                data.AGENT.LASTNAME = authRequest.LastName;
                data.AGENT.ROLECODE = (authRequest.UserType == AuthorizationRequest.LpaUserType.FieldAgent) ? Settings.Default.FieldRoleCode : Settings.Default.HomeOfficeRoleCode;
                data.AGENT.LANGUAGE = Settings.Default.LanguageCode;

                profile.DISTRIBUTION = Settings.Default.DistributionChannel; // May need to split into two channels later on
                profile.AGENTID = (authRequest.UserType == AuthorizationRequest.LpaUserType.FieldAgent) ? authRequest.Username : String.Empty; // Field agent usernames are their agent codes

                // Assigning to local variable so I don't have to call the method twice (once for logging and once for building the request object).
                var payload = data.Serialize();

                XmlSerializer xmlSerializer = new XmlSerializer(data.GetType());
                string formattedPayload = string.Empty;

                var settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.OmitXmlDeclaration = true;

                using (var stream = new StringWriter())
                using (var writer = XmlWriter.Create(stream, settings))
                {
                    xmlSerializer.Serialize(writer, data);
                    formattedPayload = stream.ToString();
                }

                // Create XML object out of data object
                if (log.IsDebugEnabled) { log.DebugFormat(CultureInfo.InvariantCulture, "Serialized Request: {0}", payload); }

                // Create web service request object
                var request = AgentAccountRequest.buildFromStringXML(payload);

                // Assign XML to request object
                //request.accountSetupRequestXML = XElement.Parse(xmlDoc.OuterXml); // XElement.Parse(payload)  xmlDoc.DocumentElement;

                // Create new web service client and send request
                using (var client = new AgentAccountServiceClient())
                {
                    #region ResponseDocumentation
                    // ErrorCode = 1000 AUTHENTICATION
                    // ErrorCode = 2000 BUSINESS_SERVER
                    // ErrorCode = 3000 INVALID_REQUEST_DATA
                    // ErrorCode = 4000 WEB_SERVICE 

                    // TempAccountID = Temporary ID for the agent; will be a GUID
                    #endregion

                    // Send request and get response
                    var response = client.agentSetup(request);

                    if (response.HasError)
                    {
                        if (response.ErrorCode == 4000)
                        {
                            //Update database to fix broken session record
                            UserAgent agent = dataFunctions.GetUserDataID(authRequest.Username);
                            if (agent != null)
                            {
                                tempAccountId = dataFunctions.UpdateSessionData(agent, formattedPayload);
                                
                                if (string.IsNullOrEmpty(tempAccountId))
                                {
                                    if (log.IsErrorEnabled) { log.ErrorFormat("AgentAccountService returned an error. ErrorCode: {0}, Exception: {1}", response.ErrorCode, response.Exception.ToString()); }

                                    return $"{errorUrl}?ErrorCode={response?.ErrorCode}&ErrorMessage={response?.Exception?.Message}";
                                }
                            }
                            else
                            {
                                if (log.IsErrorEnabled) { log.ErrorFormat("AgentAccountService returned an error. ErrorCode: {0}, Exception: {1}", response.ErrorCode, response.Exception.ToString()); }

                                return $"{errorUrl}?ErrorCode={response?.ErrorCode}&ErrorMessage={response?.Exception?.Message}";
                            }
                        }
                        else
                        {
                            if (log.IsErrorEnabled) { log.ErrorFormat("AgentAccountService returned an error. ErrorCode: {0}, Exception: {1}", response.ErrorCode, response.Exception.ToString()); }

                            return $"{errorUrl}?ErrorCode={response?.ErrorCode}&ErrorMessage={response?.Exception?.Message}";
                        }                        
                    }
                    else
                    {
                        tempAccountId = response.accountCreateResponseXML.Value;
                    }
                    return $"{successUrl}?TempAccountID={tempAccountId}";
                }
            }
            catch (Exception ex)
            {
                throw new SessionException("There was an error creating a new LPA user session.", ex);
            }
        }

        /// <summary>
        /// This method reads the Organization Units, Groups and Usernames from the config file
        /// and queries AD to see if the requesting user is authorized to access LPA.
        /// </summary>
        /// <param name="authRequest">Object model for user requesting LPA access</param>
        private void DetermineUserType(AuthorizationRequest authRequest)
        {
            // Check that object is at least not null
            if (authRequest == null)
            {
                throw new ArgumentNullException("authRequest", "AuthorizationRequest object cannot be null.");
            }

            try
            {
                // Load whitelist values
                // Load list of OU names
                var fieldOrgUnits = Settings.Default.AllowedFieldOrganizationUnits.Split(',').ToList();
                var homeOfficeOrgUnits = Settings.Default.AllowedHomeOfficeOrganizationUnits.Split(',').ToList();

                // Load list of Group names
                var fieldGroups = Settings.Default.AllowedFieldGroups.Split(',').ToList();
                var homeOfficeGroups = Settings.Default.AllowedHomeOfficeGroups.Split(',').ToList();

                // Load list of User names
                var fieldUsers = Settings.Default.AllowedFieldUsers.Split(',').ToList();
                var homeOfficeUsers = Settings.Default.AllowedHomeOfficeUsers.Split(',').ToList();

                // Create context object for the configured AD Domain
                var pc = new PrincipalContext(ContextType.Domain, Settings.Default.ActiveDirectoryDomainName);

                // Get user object for the requesting user
                var user = UserPrincipal.FindByIdentity(pc, authRequest.Username);


                // Organization Unit data
                DirectoryEntry deUser = user.GetUnderlyingObject() as DirectoryEntry;
                DirectoryEntry deUserContainer = deUser.Parent;

                // Sample value: OU=Users,OU=BusinessTechnology,OU=HOWOW,DC=hoad,DC=local
                var props = deUserContainer.Properties["distinguishedName"].Value as string;

                // Check for Field User first
                // Check Field User white list from config file
                if (fieldUsers.Contains(authRequest.Username, StringComparer.OrdinalIgnoreCase))
                {
                    authRequest.UserType = AuthorizationRequest.LpaUserType.FieldAgent;

                    if (log.IsDebugEnabled) { log.DebugFormat(CultureInfo.InvariantCulture, "User '{0}' set as 'Field Agent' for SSO by user white list.", authRequest.Username); }

                    return;
                }

                // Check Field user groups
                foreach (var grpName in fieldGroups)
                {
                    if (!String.IsNullOrWhiteSpace(grpName) && user.IsMemberOf(GroupPrincipal.FindByIdentity(pc, grpName)))
                    {
                        authRequest.UserType = AuthorizationRequest.LpaUserType.FieldAgent;

                        if (log.IsDebugEnabled) { log.DebugFormat(CultureInfo.InvariantCulture, "User '{0}' set as 'Field Agent' for SSO by AD group membership.", authRequest.Username); }

                        return;
                    }
                }

                // Check Field OU
                foreach (var ou in fieldOrgUnits)
                {
                    if (!String.IsNullOrWhiteSpace(ou) && props.Contains("OU=" + ou))
                    {
                        authRequest.UserType = AuthorizationRequest.LpaUserType.FieldAgent;

                        if (log.IsDebugEnabled) { log.DebugFormat(CultureInfo.InvariantCulture, "User '{0}' set as 'Field Agent' for SSO by OU membership.", authRequest.Username); }

                        return;
                    }
                }

                // Check Home Office User white list from config file
                if (homeOfficeUsers.Contains(authRequest.Username, StringComparer.OrdinalIgnoreCase))
                {
                    authRequest.UserType = AuthorizationRequest.LpaUserType.HomeOffice;

                    if (log.IsDebugEnabled) { log.DebugFormat(CultureInfo.InvariantCulture, "User '{0}' set as 'Home Office' for SSO by user white list.", authRequest.Username); }

                    return;
                }

                // Check Home Office user groups
                foreach (var grpName in homeOfficeGroups)
                {
                    if (!String.IsNullOrWhiteSpace(grpName) && user.IsMemberOf(GroupPrincipal.FindByIdentity(pc, grpName)))
                    {
                        authRequest.UserType = AuthorizationRequest.LpaUserType.HomeOffice;

                        if (log.IsDebugEnabled) { log.DebugFormat(CultureInfo.InvariantCulture, "User '{0}' set as 'Home Office' for SSO by AD group membership.", authRequest.Username); }

                        return;
                    }
                }

                // Check Home Office OU
                foreach (var ou in homeOfficeOrgUnits)
                {
                    if (!String.IsNullOrWhiteSpace(ou) && props.Contains("OU=" + ou))
                    {
                        authRequest.UserType = AuthorizationRequest.LpaUserType.HomeOffice;

                        if (log.IsDebugEnabled) { log.DebugFormat(CultureInfo.InvariantCulture, "User '{0}' set as 'Home Office' for SSO by OU membership.", authRequest.Username); }

                        return;
                    }
                }

                // If nothing found above, set to unknown
                authRequest.UserType = AuthorizationRequest.LpaUserType.Unknown;

                if (log.IsDebugEnabled) { log.DebugFormat(CultureInfo.InvariantCulture, "User '{0}' set as 'Unknown' for SSO.", authRequest.Username); }

                return;
            }
            catch (Exception ex)
            {
                throw new SessionException(String.Format(CultureInfo.InvariantCulture, "There was an error determining the LPA type for user {0}.", authRequest.Username), ex);
            }
        }
    }
}
