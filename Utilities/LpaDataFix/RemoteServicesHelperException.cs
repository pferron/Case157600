using System;
using System.Runtime.Serialization;

namespace LpaDataFix
{
    [Serializable]
    public class RemoteServicesHelperException : Exception
    {
        public RemoteServicesHelperException()
        {
        }

        public RemoteServicesHelperException(string message)
          : base(message)
        {
        }

        public RemoteServicesHelperException(string message, Exception inner)
          : base(message, inner)
        {
        }

        protected RemoteServicesHelperException(SerializationInfo info, StreamingContext context)
          : base(info, context)
        {
        }
    }
}