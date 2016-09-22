using Newtonsoft.Json;

namespace KnowYourKnockout.Web.Api.Models
{
    public class FirebaseUser
    {
        [JsonProperty(PropertyName = "displayName")]
        public string DisplayName { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "photoURL")]
        public string PhotoUrl { get; set; }

        [JsonProperty(PropertyName = "uid")]
        public string uid { get; set; }
    }
}
