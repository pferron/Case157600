using System;

namespace WOW.WoodmenIllustrationService.Code
{
    /// <summary>
    /// Thrown when the LifePortraits Accelerate WCF client class suffers some kind of failure.
    /// </summary>
    [Serializable()]
    public class LpaClientException : System.Exception
    {
        public LpaClientException() : base() { }
        public LpaClientException(string message) : base(message) { }
        public LpaClientException(string message, System.Exception inner) : base(message, inner) { }

        // A constructor is needed for serialization when an 
        // exception propagates from a remoting server to the client.  
        protected LpaClientException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {

        }
    }
}