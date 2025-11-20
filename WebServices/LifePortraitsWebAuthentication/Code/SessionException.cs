using System;

namespace WOW.LifePortraitsWebAuthentication.Exceptions
{
    [Serializable()]
    public class SessionException : System.Exception
    {
        public SessionException() : base() { }
        public SessionException(string message) : base(message) { }
        public SessionException(string message, System.Exception inner) : base(message, inner) { }

        // A constructor is needed for serialization when an 
        // exception propagates from a remoting server to the client.  
        protected SessionException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {

        }
    }
}