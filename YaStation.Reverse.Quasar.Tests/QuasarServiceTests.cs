using System.Threading.Tasks;
using Xunit;
using YaStation.Reverse.Core.Yandex.Api;
using YaStation.Reverse.Core.Yandex.Session;
using YaStation.Reverse.TestUtilities;

namespace YaStation.Reverse.Quasar.Tests
{
    public class QuasarServiceTests
    {
        private readonly ISessionStorage _store;
        private readonly IYandexApi _yandexApi;

        public QuasarServiceTests()
        {
            _store = new SessionStorage("./ya.session");
            _yandexApi = new YandexApi(sessionStorage: _store);
        }
        
        [Theory(Skip = "Debug")]
        [EnvData("ya_login", "ya_password")]
        public async Task Test(string login, string password)
        {
            await _yandexApi.AuthorizeByLoginAsync(new AuthByLoginRequest
            {
                Login = login,
                Password = password
            });
            
            var service = new QuasarService(_yandexApi);

            var devices = await service.GetDevicesAsync();
            
            Assert.NotNull(devices);
        }
    }
}