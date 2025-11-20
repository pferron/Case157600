using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wow.CommonIllustrationService.Builders
{
    public class IllustrationRequestValidationException : Exception
    {
        public IllustrationRequestValidationException() : base() { }
        public IllustrationRequestValidationException(string message) : base(message) { }
        public IllustrationRequestValidationException(string message, System.Exception inner) : base(message, inner) { }

        // A constructor is needed for serialization when an 
        // exception propagates from a remoting server to the client.  
        protected IllustrationRequestValidationException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {

        }

    }
}