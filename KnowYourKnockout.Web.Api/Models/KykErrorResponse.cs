using System.Collections.Generic;

namespace KnowYourKnockout.Web.Api.Models
{
    public class KykErrorResponse : KykResponse<List<KykApiError>>
    {
        public KykErrorResponse(List<KykApiError> errors)
        {
            Body = errors;
        }

        public override KykResponseCode StatusCode
        {
            get { return KykResponseCode.ClientError; }
        }
    }
}
