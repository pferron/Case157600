using System;

namespace WOW.WoodmenIllustrationService.Code
{
    /// <summary>
    /// Thrown when a ACORD TX 111 Factory class cannot map the IPolicy object to the TX 111 model objects.
    /// </summary>
    [Serializable()]
    public class AcordRequestFactoryException : System.Exception
    {
        public AcordRequestFactoryException() : base() { }
        public AcordRequestFactoryException(string message) : base(message) { }
        public AcordRequestFactoryException(string message, System.Exception inner) : base(message, inner) { }

        // A constructor is needed for serialization when an 
        // exception propagates from a remoting server to the client.  
        protected AcordRequestFactoryException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {

        }
    }
}