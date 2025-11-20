using System;

namespace WOW.RaterUtilities
{
    /// <summary>
    /// Thrown when a state value in not found that corresponds to the provided input value.
    /// </summary>
    [Serializable()]
    public class StateNotFoundException : System.Exception
    {
        public string Input { get; set; }

        public StateNotFoundException() : base() { }
        public StateNotFoundException(string message) : base(message) { }
        public StateNotFoundException(string message, System.Exception inner) : base(message, inner) { }

        // A constructor is needed for serialization when an 
        // exception propagates from a remoting server to the client.  
        protected StateNotFoundException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {

        }
    }
}
