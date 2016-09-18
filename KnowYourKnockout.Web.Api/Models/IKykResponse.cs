namespace KnowYourKnockout.Web.Api.Models
{
    public interface IKykResponse<T> where T : class
    {
        KykResponseStatus StatusCode { get; }
        string Status { get; }
        T Body { get; set; }
    }
}
