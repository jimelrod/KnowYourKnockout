namespace KnowYourKnockout.Web.Api.Models
{
    public class KykSuccessResponse<T> : KykResponse<T> where T : class
    {
        public KykSuccessResponse(T body)
        {
            Body = body;
        }

        public override KykResponseCode StatusCode
        {
            get { return KykResponseCode.Success; }
        }
    }
}
