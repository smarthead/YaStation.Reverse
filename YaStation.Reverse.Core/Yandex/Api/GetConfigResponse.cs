using System.Text.Json.Serialization;

namespace YaStation.Reverse.Core.Yandex.Api
{
    public class GetConfigResponse : YandexResponse
    {
        [JsonPropertyName("config")]
        public Configuration Configuration { get; set; }
    }
}