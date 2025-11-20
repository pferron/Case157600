using System;

namespace WOW.LifePortraitsWebAuthentication.Models
{
    public class AuthorizationRequest
    {
        public enum LpaUserType
        {
            Unknown,
            FieldAgent,
            HomeOffice
        }

        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime RequestDate { get; set; }
        public LpaUserType UserType { get; set; }

        public AuthorizationRequest()
        {
            UserType = LpaUserType.Unknown;
        }
    }
}