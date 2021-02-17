using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using YaStation.Reverse.Core.Yandex.Internal;
using YaStation.Reverse.Core.Yandex.Session;

namespace YaStation.Reverse.Core.Yandex.Api
{
    public class YandexApi : IYandexApi
    {
        private readonly YandexApiOptions _yandexApiOptions;
        private readonly ISessionStorage _sessionStorage;
        private readonly IYandexApiInvoker _api;
        
        private readonly Dictionary<string, string> _yandexUrls = new()
        {
            {"AUTH_START", "https://mobileproxy.passport.yandex.net/2/bundle/mobile/start/"},
            {"AUTH_CONFIRM_PASSWORD", "https://mobileproxy.passport.yandex.net/1/bundle/mobile/auth/password/"},
            {"AUTH_BY_TOKEN", "https://mobileproxy.passport.yandex.net/1/bundle/auth/x_token/"},
        };
        
        public YandexApi(YandexApiOptions yandexApiOptions = null, 
            IYandexApiInvoker api = null, 
            ISessionStorage sessionStorage = null)
        {
            _yandexApiOptions = yandexApiOptions ?? new YandexApiOptions();
            _api = api ?? new YandexApiInvoker();
            _sessionStorage = sessionStorage ?? new SessionStorage(_yandexApiOptions.SessionFilePath);
        }
        
        public Task<bool> IsAuthorizedAsync()
        {
            throw new NotImplementedException();
        }

        public async Task AuthorizeByLoginAsync(AuthByLoginRequest request)
        {
            var startAuthResponse = 
                await _api.CallAsync<StartAuthResponse>(new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    Content = new FormUrlEncodedContent(new Dictionary<string, string>()
                    {
                        {"x_token_client_id", _yandexApiOptions.XTokenClientId},
                        {"x_token_client_secret", _yandexApiOptions.XTokenClientSecret},
                        {"client_id", _yandexApiOptions.ClientId},
                        {"client_secret", _yandexApiOptions.ClientSecret},
                        {"display_language", _yandexApiOptions.DisplayLanguage},
                        {"force_register", _yandexApiOptions.ForceRegister.ToString()},
                        {"is_phone_number", _yandexApiOptions.IsPhoneNumber.ToString()},
                        {"login", request.Login},
                    }),
                    RequestUri = new Uri(_yandexUrls["AUTH_START"])
                });

            if (string.IsNullOrEmpty(startAuthResponse.TrackId))
                throw new InvalidOperationException();

            var confirmPasswordResponse = 
                await _api.CallAsync<ConfirmPasswordResponse>(new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    Content = new FormUrlEncodedContent(new Dictionary<string, string>()
                    {
                        {"password_source", "login"},
                        {"password", request.Password},
                        {"track_id", startAuthResponse.TrackId},
                    }),
                    RequestUri = new Uri(_yandexUrls["AUTH_CONFIRM_PASSWORD"])
                });
        }

        public Task AuthorizeByXToken(string xToken)
        {
            throw new NotImplementedException();
        }

        public async Task<TOut> GetAsync<TIn, TOut>(Uri url, TIn query, 
            IDictionary<string, string> additionalHeaders, 
            CancellationToken token)
        {
            return await _api.CallAsync<TOut>(new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = url
            });
        }

        public async Task<TOut> PostAsync<TIn, TOut>(Uri url, TIn request, 
            IDictionary<string, string> additionalHeaders, 
            CancellationToken token)
        {
            return await _api.CallAsync<TOut>(new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = url
            });
        }
    }
}