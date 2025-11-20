using System;

namespace WOW.RaterUtilities
{
    [Serializable()]
    public class PolicyBuilderException : System.Exception
    {
        public PolicyBuilderException() : base() { }
        public PolicyBuilderException(string message) : base(message) { }
        public PolicyBuilderException(string message, System.Exception inner) : base(message, inner) { }

        // A constructor is needed for serialization when an 
        // exception propagates from a remoting server to the client.  
        protected PolicyBuilderException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {

        }
    }
}
