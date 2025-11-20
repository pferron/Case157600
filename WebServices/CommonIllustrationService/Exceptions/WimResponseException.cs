using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wow.CommonIllustrationService.Exceptions
{
    [Serializable()]
    public class WimResponseException : Exception
    {
        public WimResponseException() : base() { }
        public WimResponseException(string message) : base(message) { }
        public WimResponseException(string message, System.Exception inner) : base(message, inner) { }

        // A constructor is needed for serialization when an 
        // exception propagates from a remoting server to the client.  
        protected WimResponseException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {

        }
    }
}