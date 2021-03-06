﻿using System;
using System.Text.Json.Serialization;

namespace YaStation.Reverse.Core.Yandex.Api
{
    public class AuthByTokenResponse : YandexResponse
    {
        [JsonPropertyName("passport_host")]
        public Uri PassportHost { get; set; }

        [JsonPropertyName("track_id")]
        public string TrackId { get; set; }
    }
}