using System.Text.Json.Serialization;

namespace YaStation.Reverse.Quasar.Common.Properties
{
    public class PropertyParameters
    {
        [JsonPropertyName("instance")]
        public string Instance { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("unit")]
        public string Unit { get; set; }
    }
}