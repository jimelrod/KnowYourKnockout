using KnowYourKnockout.Data.Models;
using Newtonsoft.Json;

namespace KnowYourKnockout.Web.Api.Models
{
    public class FirebaseUser
    {
        [JsonProperty(PropertyName = "displayName")]
        public string DisplayName { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string EmailAddress { get; set; }

        [JsonProperty(PropertyName = "photoURL")]
        public string PhotoUrl { get; set; }

        [JsonProperty(PropertyName = "uid")]
        public string FirebaseId { get; set; }

        [JsonProperty(PropertyName = "isFirstTimeUser")]
        public bool IsFirstTimeUser { get; set; }
    }
}
