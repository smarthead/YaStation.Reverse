using System;
using System.Text.Json.Serialization;
using YaStation.Reverse.Quasar.Common;

namespace YaStation.Reverse.Quasar.Scenarios
{
    public class ScenarioListItem
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("icon")]
        public Icon Icon { get; set; }
        
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