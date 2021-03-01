using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using YaStation.Reverse.Core.Yandex.Internal;
using YaStation.Reverse.Core.Yandex.Session;

namespace YaStation.Reverse.Core.Yandex.Api
{
    public class YandexApi : IYandexApi
    {
        private readonly YandexApiOptions _yandexApiOptions;
        private readonly ISessionStorage _sessionStorage;
        private readonly IYandexApiInvoker _api;

        
        private ISession _session;
        private ISession Session => _session ??= (_sessionStorage.Get());
        
        private readonly Dictionary<string, string> _yandexUrls = new()
        {
            {"AUTH_START", "https://mobileproxy.passport.yandex.net/2/bundle/mobile/start/"},
            {"AUTH_CONFIRM_PASSWORD", "https://mobileproxy.passport.yandex.net/1/bundle/mobile/auth/password/"},
            {"AUTH_BY_TOKEN", "https://mobileproxy.passport.yandex.net/1/bundle/auth/x_token/"},
            {"AUTH_CHECK", "https://quasar.yandex.ru/get_account_config"}
        };
        
        public YandexApi(YandexApiOptions yandexApiOptions = null, 
            IYandexApiInvoker api = null, 
            ISessionStorage sessionStorage = null)
        {
            _yandexApiOptions = yandexApiOptions ?? new YandexApiOptions();
            _api = api ?? new YandexApiInvoker();
            _sessionStorage = sessionStorage ?? new SessionStorage(_yandexApiOptions.SessionFilePath);
            
            if (Session != null) 
                _api.SetCookies(Session.Cookies);
        }
        
        public async Task<bool> IsAuthorizedAsync()
        {
            var response = await _api.CallAsync<GetConfigResponse>(new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(_yandexUrls["AUTH_CHECK"])
            });
            
            return response.Data.IsSucсess;
        }

        public string GetXToken() => Session?.XToken;

        public async Task AuthorizeByLoginAsync(AuthByLoginRequest request)
        {
            if (await IsAuthorizedAsync())
                return;
            
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

            if (string.IsNullOrEmpty(startAuthResponse.Data.TrackId))
                throw new InvalidOperationException();

            var confirmPasswordResponse = 
                await _api.CallAsync<ConfirmPasswordResponse>(new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    Content = new FormUrlEncodedContent(new Dictionary<string, string>()
                    {
                        {"password_source", "login"},
                        {"password", request.Password},
                        {"track_id", startAuthResponse.Data.TrackId},
                    }),
                    RequestUri = new Uri(_yandexUrls["AUTH_CONFIRM_PASSWORD"])
                });

            if (!confirmPasswordResponse.Data.IsSucсess)
                throw new InvalidOperationException();
            
            Session.XToken = confirmPasswordResponse.Data.XToken;
            _sessionStorage.Save(Session);

            await AuthorizeByXToken(Session?.XToken);
        }

        public async Task AuthorizeByXToken(string xToken)
        {
            if (await IsAuthorizedAsync())
                return;
            
            var authByTokenResponse = 
                await _api.CallAsync<AuthByTokenResponse>(new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    Content = new FormUrlEncodedContent(new Dictionary<string, string>()
                    {
                        {"type", "x-token"},
                        {"retpath", "https://www.yandex.ru/androids.txt"},
                    }),
                    RequestUri = new Uri(_yandexUrls["AUTH_BY_TOKEN"]),
                    Headers = { {"Ya-Consumer-Authorization", $"OAuth {xToken}"}}
                });

            if (!authByTokenResponse.Data.IsSucсess)
                throw new InvalidOperationException();

            var url = $"{authByTokenResponse.Data.PassportHost}auth/session?track_id={authByTokenResponse.Data.TrackId}";

            var response = await _api
                .CallAsync(new HttpRequestMessage(HttpMethod.Get, url));

            if (response.StatusCode == HttpStatusCode.NotFound)
                await response.Content.ReadAsStringAsync();

            Session.Cookies = _api.GetCookies();
            _sessionStorage.Save(Session);
        }

        public async Task<TOut> GetAsync<TOut>(Uri url, IDictionary<string, string> additionalHeaders = null, CancellationToken token = new CancellationToken())
        {
            return await SendAsync<TOut>(new HttpRequestMessage
            {
                RequestUri = url,
                Method = HttpMethod.Get
            }, _yandexApiOptions.RetryCount, token);
        }

        public async Task<TOut> GetAsync<TIn, TOut>(Uri url, TIn query, 
            IDictionary<string, string> additionalHeaders, 
            CancellationToken token = new())
        {
            var queryParams = typeof(TIn)
                .GetProperties()
                .Where(x => x.GetValue(query, null) != null)
                .Select(x =>
                    $"{x.Name.ToLower()}={HttpUtility.UrlEncode(x.GetValue(query, null)?.ToString())}")
                .ToArray();

            return await GetAsync<TOut>(new UriBuilder(url)
            {
                Query = string.Join("&", queryParams)
            }.Uri, additionalHeaders, token);
        }

        public async Task<TOut> PostAsync<TIn, TOut>(Uri url, TIn request, 
            IDictionary<string, string> additionalHeaders, 
            CancellationToken token = new())
        {
            return await SendAsync<TOut>(new HttpRequestMessage
            {
                RequestUri = url,
                Method = HttpMethod.Post
            }, _yandexApiOptions.RetryCount, token);
        }

        private async Task<TOut> SendAsync<TOut>(HttpRequestMessage request, int retryCount,
            CancellationToken token = new())
        {
            var result = await _api.CallAsync<TOut>(request, token: token);

            if (result.StatusCode != HttpStatusCode.Unauthorized || retryCount == 0) 
                return result.Data;
            
            await AuthorizeByXToken(Session.XToken);
            return await SendAsync<TOut>(request, retryCount, token);

        }
    }
}