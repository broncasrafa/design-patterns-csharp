using System.Runtime.Serialization;

namespace FactoryMethod.Exceptions
{
    public class InvalidPaymentMethodException : Exception
    {
        public InvalidPaymentMethodException()
        {
        }

        public InvalidPaymentMethodException(string message) : base(message)
        {
        }

        public InvalidPaymentMethodException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidPaymentMethodException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
