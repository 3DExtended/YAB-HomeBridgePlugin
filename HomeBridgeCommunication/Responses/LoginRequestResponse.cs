using System.Text.Json.Serialization;

using Newtonsoft.Json;

namespace HomeBridgeCommunication.Responses
{
    public class LoginRequestResponse
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty ("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonProperty ("token_type")]
        public string TokenType { get; set; }
    }
}