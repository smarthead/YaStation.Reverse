using System.Text.Json.Serialization;

namespace YaStation.Reverse.Quasar.Devices
{
    public class CapabilityParameters
    {
        [JsonPropertyName("split")]
        public bool Split { get; set; }
    }
}