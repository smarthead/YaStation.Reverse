using System;
using System.Threading.Tasks;
using Xunit;
using YaStation.Reverse.Core.Yandex.Api;
using YaStation.Reverse.Core.Yandex.Session;

namespace YaStation.Reverse.Core.Tests.Yandex.Api
{
    public class YandexApiTests : IDisposable
    {
        private readonly ISessionStorage _store;
        private readonly IYandexApi _yandexApi;

        public YandexApiTests()
        {
            _store = new SessionStorage("./ya.session");
            _yandexApi = new YandexApi(sessionStorage: _store);
        }
        
        [Theory]
        [EnvData("ya_login", "ya_password")]
        public async Task AuthorizeByLoginAsync(string login, string password)
        {
            await _yandexApi.AuthorizeByLoginAsync(new AuthByLoginRequest
            {
                Login = login,
                Password = password
            });

            var isAuthorized = await _yandexApi.IsAuthorizedAsync();
            
            Assert.True(isAuthorized);
        }

        public void Dispose()
        {
            _store.Clear();
        }
    }
}