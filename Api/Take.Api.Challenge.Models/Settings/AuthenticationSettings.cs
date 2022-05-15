using Newtonsoft.Json;

namespace Take.Api.Challenge.Models.Settings
{
    public class AuthenticationSettings
    {
        [JsonProperty("secretKey")]
        public string SecretKey { get; set; }
    }
}
