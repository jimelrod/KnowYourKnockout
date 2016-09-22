namespace KnowYourKnockout.Web.Api.Models
{
    public class KykApiError
    {
        public KykApiError() { }

        public KykApiError(string resource, string field, KykApiErrorCode errorCode)
            :this(resource, field, errorCode, string.Empty)
        {
            
        }

        public KykApiError(string resource, string field, KykApiErrorCode errorCode, string message)
        {
            Resource = resource;
            Field = field;
            ErrorCode = errorCode;
            Message = message;
        }

        public string Resource { get; set; }
        public string Field { get; set; }
        public KykApiErrorCode ErrorCode { get; set; }
        public string Error { get { return ErrorCode.ToString(); } }
        public string Message { get; set; }
    }
}
