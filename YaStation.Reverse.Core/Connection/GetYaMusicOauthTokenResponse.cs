using System.Text.Json.Serialization;

namespace YaStation.Reverse.Core.Connection
{
    public class GetYaMusicOauthTokenResponse : YandexResponse
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }
    }
}