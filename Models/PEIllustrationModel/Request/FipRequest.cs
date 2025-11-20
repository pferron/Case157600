using System.Globalization;

namespace WOW.PEIllustrationModel.Request
{
    public class FipRequest
    {
        public string HostName { get; set; }
        
        public string FipFile { get; set; }


        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "Host Name: {0}, FIP File: {1}", HostName, FipFile);
        }
    }
}
