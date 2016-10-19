using System;
using System.Runtime.Serialization;

namespace PantMerchant
{
    /// <summary>
    /// Thrown if the controller is already instantiated
    /// </summary>
    [Serializable]
    internal class ControllerAlreadyInitialisedException : Exception
    {
        public ControllerAlreadyInitialisedException()
            : this("The controller has already been instantiated. Something has gone horribly wrong somewhere.")
        {
        }

        public ControllerAlreadyInitialisedException(string message) : base(message)
        {
        }

        public ControllerAlreadyInitialisedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ControllerAlreadyInitialisedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}