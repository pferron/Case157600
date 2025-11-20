using WOW.Illustration.Model.Generation.Request;

namespace WOW.MobileRaterService.Builders
{
    public class ClientBuilder
    {
        public ClientPerson BuildClient()
        {
            ClientPerson client = new ClientPerson();
            client.FirstName = "Rater";
            client.MiddleName = string.Empty;
            client.LastName = "Application";

            return client;
        }
    }
}