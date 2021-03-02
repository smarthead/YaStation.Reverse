using System;
using System.Linq;
using System.Text.Json.Serialization;
using YaStation.Reverse.Core.Yandex.Api;

namespace YaStation.Reverse.Quasar.Devices
{
    public class GetDevicesResponse : YandexResponse
    {
        [JsonPropertyName("request_id")]
        public Guid RequestId { get; set; }

        [JsonPropertyName("rooms")]
        public Room[] Rooms { get; set; }

        [JsonPropertyName("groups")]
        public object[] Groups { get; set; }

        [JsonPropertyName("unconfigured_devices")]
        public Device[] UnconfiguredDevices { get; set; }

        [JsonPropertyName("speakers")]
        public Device[] Speakers { get; set; }

        [JsonIgnore]
        public Device[] AllDevices => Rooms
            .SelectMany(x => x.Devices)
            .Concat(UnconfiguredDevices)
            .Concat(Speakers)
            .ToArray();
    }
}