using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace YaStation.Reverse.Core.Yandex.Internal
{
    public class YandexApiInvoker : IYandexApiInvoker
    {
        private readonly HttpClientHandler _httpClientHandler;
        private readonly HttpClient _httpClient;

        public YandexApiInvoker()
        {
            _httpClientHandler = new HttpClientHandler
            {
                UseCookies = true,
                CookieContainer = new CookieContainer()
            };

            _httpClient = new HttpClient(_httpClientHandler);
        }

        public void SetCookies(CookieCollection cookies)
        {
            _httpClientHandler.CookieContainer.Add(cookies);
        }

        public void ClearCookies()
        {
            _httpClientHandler.CookieContainer = new CookieContainer();
        }

        public async Task<TOut> CallAsync<TOut>(HttpRequestMessage request, bool skipAuth, CancellationToken token)
        {
            var response = await _httpClient.SendAsync(request, token);
            
            // todo: Описать обработку ошибок
            if (!response.IsSuccessStatusCode)
                throw new InvalidOperationException();

            var text = await response.Content.ReadAsStringAsync();
            return JsonSerializer
                .Deserialize<TOut>(text);
        }
    }
}