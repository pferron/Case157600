using System;

namespace LpaDesktopSyncUpdater
{
    [Serializable()]
    public class RemoteServicesHelperException : System.Exception
    {
        public RemoteServicesHelperException() : base() { }
        public RemoteServicesHelperException(string message) : base(message) { }
        public RemoteServicesHelperException(string message, System.Exception inner) : base(message, inner) { }

        // A constructor is needed for serialization when an 
        // exception propagates from a remoting server to the client.  
        protected RemoteServicesHelperException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {

        }
    }
}
