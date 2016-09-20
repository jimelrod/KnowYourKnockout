namespace KnowYourKnockout.Web.Api.Models
{
    public class KykApiError
    {
        public KykApiError() { }

        public KykApiError(string resource, string field, KykApiErrorCode errorCode)
        {
            Resource = resource;
            Field = field;
            ErrorCode = errorCode;
        }

        public string Resource { get; set; }
        public string Field { get; set; }
        public KykApiErrorCode ErrorCode { get; set; }
        public string Error { get { return ErrorCode.ToString(); } }
    }
}
