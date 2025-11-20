using System;

namespace WOW.LifePortraitsWebAuthentication.Exceptions
{
    [Serializable()]
    public class DataException : System.Exception
    {
        public DataException() : base() { }
        public DataException(string message) : base(message) { }
        public DataException(string message, System.Exception inner) : base(message, inner) { }

        // A constructor is needed for serialization when an 
        // exception propagates from a remoting server to the client.  
        protected DataException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {

        }
    }
}