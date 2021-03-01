using System;
using System.Text.Json.Serialization;

namespace YaStation.Reverse.Quasar.Devices
{
    public class Device
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("icon_url")]
        public Uri IconUrl { get; set; }

        [JsonPropertyName("capabilities")]
        public Capability[] Capabilities { get; set; }

        [JsonPropertyName("properties")]
        public Property[] Properties { get; set; }

        [JsonPropertyName("groups")]
        public object[] Groups { get; set; }

        [JsonPropertyName("skill_id")]
        public string SkillId { get; set; }

        [JsonPropertyName("quasar_info")]
        public QuasarInfo QuasarInfo { get; set; }
    }
}