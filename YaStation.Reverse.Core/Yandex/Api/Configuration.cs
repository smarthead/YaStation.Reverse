using System.Text.Json.Serialization;

namespace YaStation.Reverse.Core.Yandex.Api
{
    public class Configuration
    {
        [JsonPropertyName("aliceProactivity")]
        public bool AliceProactivity { get; set; }

        [JsonPropertyName("alwaysOnMicForShortcuts")]
        public bool AlwaysOnMicForShortcuts { get; set; }

        [JsonPropertyName("childContentAccess")]
        public string ChildContentAccess { get; set; }

        [JsonPropertyName("contentAccess")]
        public string ContentAccess { get; set; }

        [JsonPropertyName("jingle")]
        public bool Jingle { get; set; }

        [JsonPropertyName("spotter")]
        public string Spotter { get; set; }
    }
}