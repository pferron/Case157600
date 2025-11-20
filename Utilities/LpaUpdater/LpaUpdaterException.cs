using System;

namespace LpaUpdater
{
    [Serializable()]
    public class LpaUpdaterException : System.Exception
    {
        public LpaUpdaterException() : base() { }
        public LpaUpdaterException(string message) : base(message) { }
        public LpaUpdaterException(string message, System.Exception inner) : base(message, inner) { }

        // A constructor is needed for serialization when an 
        // exception propagates from a remoting server to the client.  
        protected LpaUpdaterException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {

        }
    }
}
