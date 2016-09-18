namespace KnowYourKnockout.Web.Api.Models
{
    public class KykSuccessResponse<T> : KykResponse<T> where T : class
    {
        public KykSuccessResponse(T body)
        {
            Body = body;
        }

        public override KykResponseStatus StatusCode
        {
            get { return KykResponseStatus.Success; }
        }
    }
}
