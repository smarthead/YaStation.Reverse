using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace YaStation.Reverse.Core.Connection
{
    public class StartAuthResponse: YandexResponse
    {
        [JsonPropertyName("primary_alias_type")]
        public long PrimaryAliasType { get; set; }

        [JsonPropertyName("magic_link_email")]
        public string MagicLinkEmail { get; set; }

        [JsonPropertyName("can_authorize")]
        public bool CanAuthorize { get; set; }

        [JsonPropertyName("auth_methods")]
        public List<string> AuthMethods { get; set; }

        [JsonPropertyName("track_id")]
        public string TrackId { get; set; }
    }
}