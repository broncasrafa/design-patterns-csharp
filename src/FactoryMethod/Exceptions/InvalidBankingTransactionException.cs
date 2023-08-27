using System.Runtime.Serialization;

namespace FactoryMethod.Exceptions;

public class InvalidBankingTransactionException : Exception
{
    public InvalidBankingTransactionException()
    {
    }

    public InvalidBankingTransactionException(string message) : base(message)
    {
    }

    public InvalidBankingTransactionException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected InvalidBankingTransactionException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}