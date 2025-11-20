using System;

namespace Wow.CommonIllustrationService.Exceptions
{
    [Serializable()]
    public class PolicyConverterException : Exception
    {
        public PolicyConverterException() : base() { }
        public PolicyConverterException(string message) : base(message) { }
        public PolicyConverterException(string message, System.Exception inner) : base(message, inner) { }

        // A constructor is needed for serialization when an 
        // exception propagates from a remoting server to the client.  
        protected PolicyConverterException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {

        }
    }
}