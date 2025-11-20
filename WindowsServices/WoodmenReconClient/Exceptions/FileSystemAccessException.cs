using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WOW.WoodmenReconClient.Exceptions
{
    [Serializable()]
    public class FileSystemAccessException : System.Exception
    {
        public FileSystemAccessException() : base() { }
        public FileSystemAccessException(string message) : base(message) { }
        public FileSystemAccessException(string message, System.Exception inner) : base(message, inner) { }

        // A constructor is needed for serialization when an 
        // exception propagates from a remoting server to the client.  
        protected FileSystemAccessException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context)
        {
        }
    }
}
