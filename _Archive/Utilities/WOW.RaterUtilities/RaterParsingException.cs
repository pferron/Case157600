using System;

namespace WOW.RaterUtilities
{
    [Serializable()]
    public class RaterParsingException : System.Exception
    {
        public string FipInput { get; set; }

        public RaterParsingException() : base() { }
        public RaterParsingException(string message) : base(message) { }
        public RaterParsingException(string message, System.Exception inner) : base(message, inner) { }

        // A constructor is needed for serialization when an 
        // exception propagates from a remoting server to the client.  
        protected RaterParsingException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {

        }
    }
}
