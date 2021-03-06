using System;
using System.Linq;
using System.Text.Json.Serialization;
using YaStation.Reverse.Quasar.Common.Capabilities;
using YaStation.Reverse.Quasar.Common.Properties;
using YaStation.Reverse.Quasar.Common.Response;

namespace YaStation.Reverse.Quasar.Devices
{
    public class GetDevicesResponse : QuasarResponse
    {
        [JsonPropertyName("rooms")]
        public Room[] Rooms { get; set; }

        [JsonPropertyName("groups")]
        public object[] Groups { get; set; }

        [JsonPropertyName("unconfigured_devices")]
        public DeviceListItem[] UnconfiguredDevices { get; set; }

        [JsonPropertyName("speakers")]
        public DeviceListItem[] Speakers { get; set; }

        [JsonIgnore]
        public DeviceListItem[] AllDevices => Rooms
            .SelectMany(x => x.Devices)
            .Concat(UnconfiguredDevices)
            .Concat(Speakers)
            .ToArray();
    }
    
    public class DeviceListItem
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("icon_url")]
        public Uri IconUrl { get; set; }

        [JsonPropertyName("capabilities")]
        public Capability[] Capabilities { get; set; }

        [JsonPropertyName("properties")]
        public Property[] Properties { get; set; }

        [JsonPropertyName("groups")]
        public object[] Groups { get; set; }

        [JsonPropertyName("skill_id")]
        public string SkillId { get; set; }

        [JsonPropertyName("quasar_info")]
        public QuasarInfo QuasarInfo { get; set; }
    }
}