using System.Net;

namespace YaStation.Reverse.Core.Yandex.Api
{
    public class ApiResponse<T>
    {
        public T Data { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public string RawMessage { get; set; }
    }
}