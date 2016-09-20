namespace KnowYourKnockout.Web.Api.Models
{
    public abstract class KykResponse<T> : IKykResponse<T> where T : class
    {
        public virtual KykResponseCode StatusCode { get; }
        public string Status { get { return StatusCode.ToString(); } }
        public T Body { get; set; }
    }
}
