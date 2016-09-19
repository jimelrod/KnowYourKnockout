using System;

namespace KnowYourKnockout.Data.Exceptions
{
    public class KykDataLayerException : Exception
    {
        public KykDataLayerException()
            : base()
        {

        }

        public KykDataLayerException(string message)
           : base(message)
        {

        }

        public KykDataLayerException(string message, Exception innerException)
           : base(message, innerException)
        {

        }
    }
}
