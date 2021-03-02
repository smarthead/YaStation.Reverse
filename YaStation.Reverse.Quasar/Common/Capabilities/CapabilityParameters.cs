using System.Text.Json.Serialization;

namespace YaStation.Reverse.Quasar.Common.Capabilities
{
    public class CapabilityParameters
    {
        [JsonPropertyName("split")]
        public bool? Split { get; set; }
        
        [JsonPropertyName("instance")] 
        public string Instance { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("palette")]
        public Palette[] Palette { get; set; }

        [JsonPropertyName("scenes")]
        public object[] Scenes { get; set; }

        [JsonPropertyName("unit")]
        public string Unit { get; set; }

        [JsonPropertyName("random_access")]
        public bool? RandomAccess { get; set; }

        [JsonPropertyName("looped")]
        public bool? Looped { get; set; }

        [JsonPropertyName("range")]
        public Range Range { get; set; }
    }

    public class Palette
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("type")]
        public TypeEnum Type { get; set; }

        [JsonPropertyName("value")]
        public ValueClass Value { get; set; }
    }

    public class ValueClass
    {
        [JsonPropertyName("h")]
        public long H { get; set; }

        [JsonPropertyName("s")]
        public long S { get; set; }

        [JsonPropertyName("v")]
        public long V { get; set; }
    }

    public class Range
    {
        [JsonPropertyName("min")]
        public long Min { get; set; }

        [JsonPropertyName("max")]
        public long Max { get; set; }

        [JsonPropertyName("precision")]
        public long Precision { get; set; }
    }
    
    public enum TypeEnum { Multicolor, White };
}