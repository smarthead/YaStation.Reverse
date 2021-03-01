using System;
using System.Text.Json.Serialization;

namespace YaStation.Reverse.Quasar.Devices
{
    public class Room
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("devices")]
        public Device[] Devices { get; set; }
    }
}