using System;
using System.Text.Json.Serialization;
using YaStation.Reverse.Core.Yandex.Api;

namespace YaStation.Reverse.Quasar.Scenarios
{
    public class GetScenariosResponse : YandexResponse
    {
        [JsonPropertyName("request_id")]
        public Guid RequestId { get; set; }

        [JsonPropertyName("scenarios")]
        public Scenario[] Scenarios { get; set; }
    }

    public class Scenario
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("icon")]
        public string Icon { get; set; }

        [JsonPropertyName("icon_url")]
        public Uri IconUrl { get; set; }

        [JsonPropertyName("executable")]
        public bool Executable { get; set; }

        [JsonPropertyName("devices")]
        public string[] Devices { get; set; }

        [JsonPropertyName("is_active")]
        public bool IsActive { get; set; }
    }
}