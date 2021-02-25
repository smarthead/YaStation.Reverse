using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using YaStation.Reverse.Core.Common.CookieContainer;

namespace YaStation.Reverse.Core.Yandex.Internal
{
    public class YandexApiInvoker : IYandexApiInvoker
    {
        private readonly HttpClientHandler _httpClientHandler;
        private readonly HttpClient _httpClient;
        private const string DefaultUserAgent = "com.yandex.mobile.auth.sdk/7.15.0.715001762";

        public YandexApiInvoker()
        {
            _httpClientHandler = new HttpClientHandler
            {
                UseCookies = true,
                AllowAutoRedirect = true,
                CookieContainer = new CookieContainer()
            };

            _httpClient = new HttpClient(_httpClientHandler);
            _httpClient.DefaultRequestHeaders.UserAgent.TryParseAdd(DefaultUserAgent);
        }

        public void SetCookies(CookieCollection cookies)
        {
            _httpClientHandler.CookieContainer.Add(cookies);
        }

        public CookieCollection GetCookies()
        {
            return _httpClientHandler.CookieContainer.GetCookies();
        }

        public void ClearCookies()
        {
            _httpClientHandler.CookieContainer = new CookieContainer();
        }

        public async Task<TOut> CallAsync<TOut>(HttpRequestMessage request, bool skipAuth, CancellationToken token)
        {
            var response = await CallAsync(request, skipAuth, token);
            var text = await response.Content.ReadAsStringAsync(token);
            
            return JsonSerializer
                .Deserialize<TOut>(text);
        }

        public async Task<HttpResponseMessage> CallAsync(HttpRequestMessage request, bool skipAuth = false, CancellationToken token = new CancellationToken())
        {
            var response = await _httpClient.SendAsync(request, token);

            // todo: Реализовать обработку ошибок;

            return response;
        }
    }
}