using System.Text.Json.Serialization;

namespace YaStation.Reverse.Quasar.Devices
{
    public class CapabilityState
    {
        [JsonPropertyName("instance")]
        public string Instance { get; set; }

        [JsonPropertyName("value")]
        public bool Value { get; set; }
    }
}