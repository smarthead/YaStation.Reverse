using System;
using System.Text.Json.Serialization;
using YaStation.Reverse.Quasar.Common;
using YaStation.Reverse.Quasar.Common.Capabilities;
using YaStation.Reverse.Quasar.Common.Triggers;

namespace YaStation.Reverse.Quasar.Scenarios
{
    public class AddScenarioRequest
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("icon")]
        public Icon Icon { get; set; }
        
        [JsonPropertyName("trigger_type")]
        public TriggerType TriggerType { get; set; }

        [JsonPropertyName("triggers")]
        public Trigger[] Triggers { get; set; }
        
        [JsonPropertyName("requested_speaker_capabilities")]
        public Capability[] RequestedSpeakerCapabilities { get; set; }
        
        [JsonPropertyName("devices")]
        public ScenarioDevice[] Devices { get; set; }
    }

    public class ScenarioDevice
    {
        public Guid Id { get; set; }
        
        [JsonPropertyName("capabilities")] 
        public Capability[] Capabilities { get; set; }
    }
}