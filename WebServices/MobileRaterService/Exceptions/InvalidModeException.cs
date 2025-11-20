using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WOW.MobileRaterService.Exceptions
{
    [Serializable()]

    public class InvalidModeException : System.Exception
    {

        public InvalidModeException() : base() { }
        public InvalidModeException(string message) : base(message) { }
        public InvalidModeException(string message, System.Exception inner) : base(message, inner) { }

        protected InvalidModeException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {

        }


    }

}