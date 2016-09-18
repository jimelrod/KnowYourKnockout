using System;

namespace KnowYourKnockout.Web.Api.Models
{
    public class KykErrorResponse : KykResponse<Exception>
    {
        public KykErrorResponse(Exception ex)
        {
            Body = ex;
        }

        public override KykResponseStatus StatusCode
        {
            get { return KykResponseStatus.Error; }
        }
    }
}