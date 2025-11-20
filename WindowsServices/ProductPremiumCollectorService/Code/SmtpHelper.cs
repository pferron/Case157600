namespace ProductPremiumCollectorService.Code
{
    public sealed class SmtpHelper
    {
        /// <summary>Initializes a new instance of this class.</summary>
        private SmtpHelper()
        {
            //Used for hiding the Public constructor.
        }

        /// <summary>Sends the specified message to the given addresses.</summary>
        /// <param name="ToAddressees">Array of one or more addressees.</param>
        /// <param name="Subject">The subject line of the message.</param>
        /// <param name="Body">The body of the message.</param>
        /// <param name="IsHtml">Indication of whether the body is HTML markup.</param>

        public static void Send(string[] toAddressees, string subject, string body, bool isHtml)
        {
            System.Net.Mail.SmtpClient objClient = null;
            System.Net.Mail.MailMessage objMessage = null;
            string strServer = Properties.Settings.Default.SMTPServer;
            string strFromAddress = Properties.Settings.Default.SMTPFromAddress;

            if (toAddressees == null)
                toAddressees = new string[1];
            if (subject == null)
                subject = string.Empty;
            if (body == null)
                body = string.Empty;

            objClient = new System.Net.Mail.SmtpClient(strServer);

            objMessage = new System.Net.Mail.MailMessage();
            var _with1 = objMessage;
            _with1.From = new System.Net.Mail.MailAddress(strFromAddress, "Automated Message");
            foreach (string strAddress in toAddressees)
            {
                _with1.To.Add(strAddress);
            }
            _with1.Subject = subject;
            _with1.Body = body;
            _with1.IsBodyHtml = isHtml;

            objClient.Send(objMessage);
            objMessage = null;
        }
    }
}
