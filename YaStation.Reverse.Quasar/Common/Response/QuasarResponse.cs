using System;
using System.Text.Json.Serialization;
using YaStation.Reverse.Core.Yandex.Api;

namespace YaStation.Reverse.Quasar.Common.Response
{
    public class QuasarResponse : YandexResponse
    {
        [JsonPropertyName("request_id")] 
        public Guid RequestId { get; set; }
    }
}