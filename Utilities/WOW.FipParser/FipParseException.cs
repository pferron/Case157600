using System;

namespace WOW.FipUtilities
{
    /// <summary>
    /// Thrown when there is an error parsing a FIP file.
    /// </summary>
    [Serializable()]
    public class FipParseException : System.Exception
    {
        public string FipInput { get; set; }

        public FipParseException() : base() { }
        public FipParseException(string message) : base(message) { }
        public FipParseException(string message, System.Exception inner) : base(message, inner) { }

        // A constructor is needed for serialization when an 
        // exception propagates from a remoting server to the client.  
        protected FipParseException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {

        }
    }
}
