using System;
using System.Text.Json.Serialization;

namespace YaStation.Reverse.Core.Yandex.Api
{
    public class ConfirmPasswordResponse : YandexResponse
    {
        [JsonPropertyName("access_token_expires_in")]
        public long AccessTokenExpiresIn { get; set; }

        [JsonPropertyName("public_id")]
        public string PublicId { get; set; }

        [JsonPropertyName("uid")]
        public long Uid { get; set; }

        [JsonPropertyName("firstname")]
        public string Firstname { get; set; }

        [JsonPropertyName("lastname")]
        public string Lastname { get; set; }

        [JsonPropertyName("x_token_expires_in")]
        public long XTokenExpiresIn { get; set; }

        [JsonPropertyName("cloud_token")]
        public string CloudToken { get; set; }

        [JsonPropertyName("has_password")]
        public bool HasPassword { get; set; }

        [JsonPropertyName("has_music_subscription")]
        public bool HasMusicSubscription { get; set; }

        [JsonPropertyName("has_plus")]
        public bool HasPlus { get; set; }

        [JsonPropertyName("primary_alias_type")]
        public long PrimaryAliasType { get; set; }

        [JsonPropertyName("x_token")]
        public string XToken { get; set; }

        [JsonPropertyName("display_name")]
        public string DisplayName { get; set; }

        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        [JsonPropertyName("gender")]
        public string Gender { get; set; }

        [JsonPropertyName("normalized_display_login")]
        public string NormalizedDisplayLogin { get; set; }

        [JsonPropertyName("x_token_issued_at")]
        public long XTokenIssuedAt { get; set; }

        [JsonPropertyName("display_login")]
        public string DisplayLogin { get; set; }

        [JsonPropertyName("public_name")]
        public string PublicName { get; set; }

        [JsonPropertyName("is_avatar_empty")]
        public bool IsAvatarEmpty { get; set; }

        [JsonPropertyName("avatar_url")]
        public Uri AvatarUrl { get; set; }

        [JsonPropertyName("native_default_email")]
        public string NativeDefaultEmail { get; set; }
    }
}