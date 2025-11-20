using System.Data;
using System.Data.SqlClient;
using WOW.LifePortraitsWebAuthentication.Properties;
using WOW.LifePortraitsWebAuthentication.Models;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace WOW.LifePortraitsWebAuthentication.Code
{
    public class DataFunctions
    {
        public UserAgent GetUserDataID(string userID)
        {
            UserAgent agent = new UserAgent();

            using (SqlConnection conn = new SqlConnection(Settings.Default.LPALPESDBConnectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT UserDataID, LastUsedAgentID FROM UserData WHERE username = @p0", conn))
                {
                    SqlParameter param0 = new SqlParameter("@p0", userID);
                    cmd.Parameters.Add(param0);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            agent.UserDataId = reader.GetGuid(0).ToString();
                            agent.AgentId = reader.GetGuid(1).ToString();
                        }
                    }
                }
            }
            return agent;
        }
            
   
        public string UpdateSessionData(UserAgent agent, string payload)
        {
            string returnValue = string.Empty;
            string sessionID = string.Empty;
            
            using (SqlConnection sessionConn = new SqlConnection(Settings.Default.LPASessionDBConnectionString))
            {
                sessionConn.Open();

                using (SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT SessionID FROM SessionInfo WHERE UserID = @p0 and RTrim(SessionData) = ''", sessionConn))
                {
                    DataTable dtResults = new DataTable();

                    SqlParameter param0 = new SqlParameter("@p0", agent.UserDataId);
                    dataAdapter.SelectCommand.Parameters.Add(param0);

                    dataAdapter.Fill(dtResults);

                    if (dtResults.Rows.Count > 0)
                    {
                        sessionID = dtResults.Rows[0][0].ToString();
                        //Broken session info exists.  Let's fix it.
                        string xmlString = GenerateXmlString(agent);

                        using (SqlCommand commandFix = new SqlCommand("UPDATE SessionInfo SET SessionData = @p0 WHERE UserID = @p1 and RTrim(SessionData) = ''", sessionConn))
                        {
                            SqlParameter paramFix0 = new SqlParameter("@p0", xmlString);
                            commandFix.Parameters.Add(paramFix0);

                            SqlParameter paramFix1 = new SqlParameter("@p1", agent.UserDataId);
                            commandFix.Parameters.Add(paramFix1);

                            commandFix.ExecuteNonQuery();

                            
                        }

                        using (SqlCommand accountSetupFix = new SqlCommand("INSERT INTO AccountSetupInfo (AccountSetupId, SessionId, AccountData, RequestDate) VALUES (@p0, @p1, @p2, @p3)", sessionConn))
                        {
                            string newGuid = System.Guid.NewGuid().ToString();
                            SqlParameter accountParam0 = new SqlParameter("@p0", newGuid);
                            accountSetupFix.Parameters.Add(accountParam0);

                            SqlParameter accountParam1 = new SqlParameter("@p1", sessionID);
                            accountSetupFix.Parameters.Add(accountParam1);

                            SqlParameter accountParam2 = new SqlParameter("@p2", payload);
                            accountSetupFix.Parameters.Add(accountParam2);

                            SqlParameter accountParam3 = new SqlParameter("@p3", System.DateTime.Now);
                            accountSetupFix.Parameters.Add(accountParam3);

                            accountSetupFix.ExecuteNonQuery();

                            returnValue = newGuid;
                        }
                    }                    
                }
            }

            return returnValue;
        }

        private string GenerateXmlString(UserAgent agent)
        {
            ArrayOfKeyValueOfstringstring xmlString = new ArrayOfKeyValueOfstringstring();
            ArrayOfKeyValueOfstringstringKeyValueOfstringstring[] xmlArray = new ArrayOfKeyValueOfstringstringKeyValueOfstringstring[4];

            ArrayOfKeyValueOfstringstringKeyValueOfstringstring xmlItem = new ArrayOfKeyValueOfstringstringKeyValueOfstringstring();
            xmlItem.Key = "Agent";
            xmlItem.Value = agent.AgentId;

            xmlArray[0] = xmlItem;

            xmlItem = new ArrayOfKeyValueOfstringstringKeyValueOfstringstring();
            xmlItem.Key = "User";
            xmlItem.Value = agent.UserDataId;

            xmlArray[1] = xmlItem;

            xmlItem = new ArrayOfKeyValueOfstringstringKeyValueOfstringstring();
            xmlItem.Key = "LanguageFolder";
            xmlItem.Value = "en";

            xmlArray[2] = xmlItem;

            xmlItem = new ArrayOfKeyValueOfstringstringKeyValueOfstringstring();
            xmlItem.Key = "RegionFolder";
            xmlItem.Value = "base";

            xmlArray[3] = xmlItem;

            xmlString.KeyValueOfstringstring = xmlArray;

            XmlSerializer xmlSerializer = new XmlSerializer(xmlString.GetType());
                        
            var settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.OmitXmlDeclaration = true;

            using (var stream = new StringWriter())
            using (var writer = XmlWriter.Create(stream, settings))
            {
                xmlSerializer.Serialize(writer, xmlString);
                return stream.ToString();
            }
        }

    }
}
