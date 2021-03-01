using System.Text.Json.Serialization;

namespace YaStation.Reverse.Quasar.Devices
{
    public class QuasarInfo
    {
        [JsonPropertyName("device_id")]
        public string DeviceId { get; set; }

        [JsonPropertyName("platform")]
        public string Platform { get; set; }
    }
}