using System;
using System.Text.Json.Serialization;
using YaStation.Reverse.Quasar.Common.Capabilities;
using YaStation.Reverse.Quasar.Common.Properties;
using YaStation.Reverse.Quasar.Common.Response;

namespace YaStation.Reverse.Quasar.Devices
{
    public class GetDeviceResponse : QuasarResponse
    {
        [JsonPropertyName("updates_url")]
        public string UpdatesUrl { get; set; }

        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("names")]
        public string[] Names { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("icon_url")]
        public Uri IconUrl { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("groups")]
        public object[] Groups { get; set; }

        [JsonPropertyName("room")]
        public string Room { get; set; }

        [JsonPropertyName("capabilities")]
        public Capability[] Capabilities { get; set; }

        [JsonPropertyName("properties")]
        public Property[] Properties { get; set; }

        [JsonPropertyName("skill_id")]
        public string SkillId { get; set; }

        [JsonPropertyName("external_id")]
        public string ExternalId { get; set; }
    }
}