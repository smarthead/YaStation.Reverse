using System.Text.Json.Serialization;

namespace YaStation.Reverse.Core.Yandex.Api
{
    public abstract class YandexResponse
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }

        public bool IsSucсess => Status == "ok";
    }
}