using System;

namespace KnowYourKnockout.Data.Exceptions
{
    public class KykDataLayerException : Exception
    {
        public KykDataLayerException(ExceptionType exceptionType)
            : this(exceptionType, string.Empty)
        {

        }

        public KykDataLayerException(ExceptionType exceptionType, string message)
           : this(exceptionType, message, null)
        {

        }

        public KykDataLayerException(ExceptionType exceptionType, string message, Exception innerException)
           : base(message, innerException)
        {
            ExceptionType = exceptionType;
        }

        public ExceptionType ExceptionType { get; }
    }
}
