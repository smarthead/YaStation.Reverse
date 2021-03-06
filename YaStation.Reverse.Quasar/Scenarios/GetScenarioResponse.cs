using System;
using System.Text.Json.Serialization;
using YaStation.Reverse.Quasar.Common.Capabilities;
using YaStation.Reverse.Quasar.Common.Response;
using YaStation.Reverse.Quasar.Common.Triggers;

namespace YaStation.Reverse.Quasar.Scenarios
{
    public class GetScenarioResponse : QuasarResponse
    {
        [JsonPropertyName("scenario")]
        public Scenario Scenario { get; set; }
    }

    public class Scenario
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("triggers")]
        public Trigger[] Triggers { get; set; }

        [JsonPropertyName("icon")]
        public string Icon { get; set; }

        [JsonPropertyName("icon_url")]
        public Uri IconUrl { get; set; }

        [JsonPropertyName("devices")]
        public ScenarioDeviceItem[] Devices { get; set; }

        [JsonPropertyName("is_active")]
        public bool IsActive { get; set; }
    }

    public class ScenarioDeviceItem
    {
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

        [JsonPropertyName("capabilities")]
        public Capability[] Capabilities { get; set; }

        [JsonPropertyName("properties")]
        public object[] Properties { get; set; }

        [JsonPropertyName("skill_id")]
        public string SkillId { get; set; }

        [JsonPropertyName("external_id")]
        public string ExternalId { get; set; }
    }
}