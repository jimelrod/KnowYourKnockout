using System;

namespace KnowYourKnockout.Web.Api.Models
{
    public class KykExceptionResponse : KykResponse<Exception>
    {
        public KykExceptionResponse(Exception ex)
        {
            Body = ex;
        }

        public override KykResponseCode StatusCode
        {
            get { return KykResponseCode.ServerError; }
        }
    }
}