using System.Text.Json.Serialization;

namespace YaStation.Reverse.Quasar.Common.Capabilities
{
    public class CapabilityState
    {
        [JsonPropertyName("instance")]
        public string Instance { get; set; }

        [JsonPropertyName("value")]
        public object Value { get; set; }
        
        [JsonPropertyName("relative")]
        public bool? Relative { get; set; }
    }
}