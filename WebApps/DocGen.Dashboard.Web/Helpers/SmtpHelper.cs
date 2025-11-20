using System.Collections.Generic;
using System.IO;

namespace LPA.Dashboard.Web.Helpers
{
    /// <summary>Represents a simple e-mail message generator.</summary>
    public sealed class SmtpHelper
    {
        /// <summary>Initializes a new instance of this class.</summary>
        private SmtpHelper()
        {
            //Used for hiding the Public constructor.
        }

        /// <summary>Sends the specified message to the given addresses.</summary>
        /// <param name="toAddressees"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <param name="isHtml"></param>
        /// <param name="log"></param>
        public static void Send(string[] toAddressees, string subject, string body, bool isHtml, List<string> log = null)
        {
            string strServer = Properties.Settings.Default.SMTPServer;
            string strFromAddress = Properties.Settings.Default.SMTPFromAddress;

            if (toAddressees == null)
                toAddressees = new string[1];
            if (subject == null)
                subject = string.Empty;
            if (body == null)
                body = string.Empty;

            System.Net.Mail.SmtpClient objClient = new System.Net.Mail.SmtpClient(strServer);

            System.Net.Mail.MailMessage objMessage = new System.Net.Mail.MailMessage();

            var _with1 = objMessage;
            _with1.From = new System.Net.Mail.MailAddress(strFromAddress, "Automated Message");
            foreach (string strAddress in toAddressees)
            {
                _with1.To.Add(strAddress);
            }
            _with1.Subject = subject;
            _with1.Body = body;
            _with1.IsBodyHtml = isHtml;

            if (log != null)
            {
                using (var stream = new MemoryStream())
                using (var writer = new StreamWriter(stream))
                {
                    foreach (var logItem in log)
                    {
                        writer.WriteLine(logItem);
                    }
                    writer.Flush();
                    stream.Position = 0;
                    var attachment = new System.Net.Mail.Attachment(stream, "error.log", "text/plain");
                    objMessage.Attachments.Add(attachment);

                    objClient.Send(objMessage);
                    objMessage = null;
                    return;
                }
            }

            objClient.Send(objMessage);
        }
    }
}