using System.Text.Json.Serialization;

namespace YaStation.Reverse.Quasar.Common.Triggers
{
    public class Trigger
    {
        [JsonPropertyName("type")]
        public TriggerType Type { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }
    }
}