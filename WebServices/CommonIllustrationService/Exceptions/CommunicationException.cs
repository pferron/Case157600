using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wow.CommonIllustrationService.Exceptions
{
    [Serializable()]

    public class CommunicationException : Exception
    {
        public CommunicationException() : base() { }
        public CommunicationException(string message) : base(message) { }
        public CommunicationException(string message, System.Exception inner) : base(message, inner) { }

        // A constructor is needed for serialization when an 
        // exception propagates from a remoting server to the client.  
        protected CommunicationException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {

        }
    }
}