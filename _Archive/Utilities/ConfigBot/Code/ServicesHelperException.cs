using System;

namespace ConfigBot
{
    [Serializable()]
    public class ServicesHelperException : System.Exception
    {
        public ServicesHelperException() : base() { }
        public ServicesHelperException(string message) : base(message) { }
        public ServicesHelperException(string message, System.Exception inner) : base(message, inner) { }

        // A constructor is needed for serialization when an 
        // exception propagates from a remoting server to the client.  
        protected ServicesHelperException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {

        }
    }
}
