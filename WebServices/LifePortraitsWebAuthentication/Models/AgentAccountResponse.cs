using System;
using System.Xml.Linq;
using WOW.LifePortraitsWebAuthentication.Exceptions;

namespace WOW.LifePortraitsWebAuthentication.Models
{
    /// <summary>
    /// This is a Woodmen model for the StoneRiver response from their web service.
    /// The response from the service is just XML and no model class was provided.
    /// This name matches the name of the root element, but may cause namespace collisions.
    /// </summary>
    public class AgentAccountResponse
    {
        public bool HasError { get; set; }
        public string ErrorCode { get; set; }
        public string TempAccountId { get; set; }
        public string ExceptionMessage { get; set; }
        public string StackTrace { get; set; }
        public string OccurenceDateTime { get; set; }

        /// <summary>
        /// Woodmen model for StoneRiver Single Sign On Sevice
        /// </summary>
        public AgentAccountResponse()
        {

        }

        /// <summary>
        /// Helper method to hydrate instance with values from XDocument
        /// </summary>
        /// <param name="doc"></param>
        public AgentAccountResponse(XDocument doc)
        {
            try
            {
                if (doc == null)
                {
                    throw new ArgumentNullException("doc", "The XDocument object cannot be null.");
                }

                HasError = (doc.Root.Element("HasError").Value == "1") ? true : false;
                ErrorCode = doc.Root.Element("ErrorCode").Value;
                TempAccountId = doc.Root.Element("accountCreateResponseXML").Element("TempAccountID").Value;

                if (HasError)
                {
                    ExceptionMessage = doc.Root.Element("LifeServerException").Element("Message").Value;
                    StackTrace = doc.Root.Element("LifeServerException").Element("StackTrace").Value;
                    OccurenceDateTime = doc.Root.Element("LifeServerException").Element("OccurenceDateTime").Value;
                }
            }
            catch (Exception ex)
            {
                throw new DataException("There was an error parsing the XDocument.", ex);
            }
        }
    }
}