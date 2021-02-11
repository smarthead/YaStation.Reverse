using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace YaStation.Reverse.Core.Connection
{
    /// <summary>
    /// Класс для различных запросов к API Яндекса
    /// </summary>
    public class YandexApi : IYandexApi
    {
        private readonly ISessionStore _sessionStore;

        private readonly HttpClient _httpClient = new HttpClient();
        public ISession Session { get; private set; }
        
        private readonly YandexApiOptions _yandexApiOptions;

        private readonly Dictionary<string, string> _yandexUrls = new()
        {
            {"AUTH_START", "https://mobileproxy.passport.yandex.net/2/bundle/mobile/start/"},
            {"AUTH_CONFIRM_PASSWORD", "https://mobileproxy.passport.yandex.net/1/bundle/mobile/auth/password/"},
            {"AUTH_BY_TOKEN", "https://mobileproxy.passport.yandex.net/1/bundle/auth/x_token/"},
            {"YA_MUSIC_OAUTH", "https://oauth.mobile.yandex.net/1/token"},
            {"CSRF_TOKEN", "https://yandex.ru/quasar/iot"},
        };

        public YandexApi(IOptions<YandexApiOptions> apiClientOptions, ISessionStore sessionStore = null) 
            : this(apiClientOptions?.Value, sessionStore) {}
        
        public YandexApi(YandexApiOptions yandexApiOptions = null, ISessionStore sessionStore = null)
        {
            _sessionStore = sessionStore;
            _yandexApiOptions = yandexApiOptions ?? new();

            if (_sessionStore != null) 
                Session = _sessionStore.Get();
            
            Session ??= new YandexSession();
        }

        /// <summary>
        /// Авторизация по логину и паролю
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task AuthorizeByLoginAsync(AuthByLoginRequest request)
        {
            var startAuthResponse = await SendRequestAsync<StartAuthResponse>(new HttpRequestMessage()
            {
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
                Method = HttpMethod.Post,
                RequestUri = new Uri(_yandexUrls["AUTH_START"])
            });

            if (string.IsNullOrEmpty(startAuthResponse.TrackId))
                throw new InvalidOperationException();

            var confirmPasswordResponse = await SendRequestAsync<ConfirmPasswordResponse>(new HttpRequestMessage()
            {
                Content = new FormUrlEncodedContent(new Dictionary<string, string>()
                {
                    {"password_source", "login"},
                    {"password", request.Password},
                    {"track_id", startAuthResponse.TrackId},
                }),
                Method = HttpMethod.Post,
                RequestUri = new Uri(_yandexUrls["AUTH_CONFIRM_PASSWORD"])
            });
            
            Session.XToken = confirmPasswordResponse.XToken;
        }

        /// <summary>
        /// Авторизация по x-token
        /// </summary>
        /// <param name="xToken"></param>
        /// <returns></returns>
        public async Task AuthorizeByXTokenAsync(string xToken)
        {
            var authByTokenResponse = await SendRequestAsync<AuthByTokenResponse>(new HttpRequestMessage()
            {
                Content = new FormUrlEncodedContent(new Dictionary<string, string>()
                {
                    {"type", "x-token"},
                    {"retpath", "https://www.yandex.ru/androids.txt"},
                }),
                Headers = { { "Ya-Consumer-Authorization", $"OAuth {xToken}" } },
                Method = HttpMethod.Post,
                RequestUri = new Uri(_yandexUrls["AUTH_BY_TOKEN"])
            });
            
            var refreshSession = await SendRequestAsync<AuthByTokenResponse>(new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(
                    $"{authByTokenResponse.PassportHost}/auth/session?track_id={authByTokenResponse.TrackId}"
                )
            });
        }

        /// <summary>
        /// Получение OAUTH-токена Яндекс.Музыки
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task<string> GetMusicToken()
        {
            if (Session == null)
                throw new InvalidOperationException();

            var token = await SendRequestAsync<GetYaMusicOauthTokenResponse>(new HttpRequestMessage
            {
                Content = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    {"client_id", _yandexApiOptions.YandexMusicClientId},
                    {"client_secret", _yandexApiOptions.YandexMusicClientSecret},
                    {"grant_type", "x-token"},
                    {"access_token", Session.XToken},
                }),
                Method = HttpMethod.Post,
                RequestUri = new Uri(_yandexUrls["YA_MUSIC_OAUTH"])
            });

            if (token.IsSucсess)
                Session.OauthYaMusicToken = token.AccessToken;
            
            return Session.OauthYaMusicToken;
        }
        
        /// <summary>
        /// Получение CSRF токена для запросов к API
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<string> GetCsrfToken()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Отправка запросов подписанных CSRF токеном
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<HttpResponseMessage> SendAuthorizedRequestAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (Session == null)
                throw new InvalidOperationException();

            if (Session.CsrfToken == null)
                Session.CsrfToken = await GetCsrfToken();
            
            throw new NotImplementedException();
        }
        
        /// <summary>
        /// Отправка запросов подписанных Oauth токеном
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<HttpResponseMessage> SendGlagolRequestAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (Session == null)
                throw new InvalidOperationException();

            if (Session.OauthYaMusicToken == null)
                Session.OauthYaMusicToken = await GetMusicToken();
            
            throw new NotImplementedException();
        }

        private async Task<TOut> SendRequestAsync<TOut>(HttpRequestMessage message)
            where TOut : class
        {
            var response = await _httpClient.SendAsync(message);

            if (!response.IsSuccessStatusCode)
                return null;

            var text = await response.Content.ReadAsStringAsync();
            return JsonSerializer
                .Deserialize<TOut>(text);
        }
    }
}