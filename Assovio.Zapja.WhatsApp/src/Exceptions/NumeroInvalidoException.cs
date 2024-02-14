using System;
using System.Runtime.Serialization;

namespace Assovio.Zapja.WhatsApp.Exceptions
{
    [Serializable]
    internal class NumeroInvalidoException : Exception
    {
        public NumeroInvalidoException()
        {
        }

        public NumeroInvalidoException(string message) : base(message)
        {
        }

        public NumeroInvalidoException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NumeroInvalidoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}