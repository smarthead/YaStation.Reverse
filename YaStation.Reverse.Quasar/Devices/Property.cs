using System.Text.Json.Serialization;

namespace YaStation.Reverse.Quasar.Devices
{
    public class Property
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("parameters")]
        public PropertyParameters Parameters { get; set; }

        [JsonPropertyName("state")]
        public PropertyState State { get; set; }
    }
}