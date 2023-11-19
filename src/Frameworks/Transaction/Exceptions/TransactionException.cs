namespace Transaction.Framework.Exceptions
{
    using System;
    using Transaction.Framework.Types;

    public abstract class TransactionException : Exception
    {
        public TransactionException(string message)
            : base(message)
        {  }

        public abstract int ErrorCode { get; }
    }


    public class InvalidСoordinatesException : TransactionException
    {
        public InvalidСoordinatesException()
        : base($"coordinates cannot be negative")
        { }

        public override int ErrorCode =>
            TransactionErrorCode.ErrorCode;
    }

    public class InvalidValutaCodeException : TransactionException
    {
        public InvalidValutaCodeException(string ValutaCode)
        : base($"{ValutaCode} -> This code does not exist or the code was entered incorrectly.")
        { }

        public override int ErrorCode =>
            TransactionErrorCode.ErrorCode;
    }
    public class InvalidRadiusException : TransactionException
    {
        public InvalidRadiusException(string Radius)
        : base($"{Radius} -> Please indicate the radius")
        { }

        public override int ErrorCode =>
            TransactionErrorCode.ErrorCode;
    }

    public class InvalidValueExceededException : TransactionException
    {
        public InvalidValueExceededException(float x, float y)
        : base($"{x}, {y} -> Value exceeded")
        { }

        public override int ErrorCode =>
            TransactionErrorCode.ErrorCode;
    }

    public class InvalidRequestFromCBException : TransactionException
    {
        public InvalidRequestFromCBException()
        : base($"ERROR The request from the central bank was not processed")
        { }

        public override int ErrorCode =>
            TransactionErrorCode.ErrorCode;
    }

}
