using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace YaStation.Reverse.Quasar.Common.Triggers
{
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum TriggerType
    {
        [EnumMember(Value = "scenario.trigger.voice")] Voice
    }
}