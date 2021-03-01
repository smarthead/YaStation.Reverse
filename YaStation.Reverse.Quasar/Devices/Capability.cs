using System.Text.Json.Serialization;

namespace YaStation.Reverse.Quasar.Devices
{
    public class Capability
    {
        [JsonPropertyName("reportable")]
        public bool Reportable { get; set; }

        [JsonPropertyName("retrievable")]
        public bool Retrievable { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("parameters")]
        public CapabilityParameters Parameters { get; set; }

        [JsonPropertyName("state")]
        public CapabilityState State { get; set; }

        [JsonPropertyName("last_updated")]
        public double LastUpdated { get; set; }
    }
}