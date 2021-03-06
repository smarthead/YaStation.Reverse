using System.Text.Json.Serialization;

namespace YaStation.Reverse.Quasar.Common.Properties
{
    public class PropertyState
    {
        [JsonPropertyName("percent")]
        public object Percent { get; set; }

        [JsonPropertyName("status")]
        public object Status { get; set; }

        [JsonPropertyName("value")]
        public long Value { get; set; }
    }
}