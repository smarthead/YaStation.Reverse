using System.Threading.Tasks;
using Xunit;
using YaStation.Reverse.Core.Connection;

namespace YaStation.Reverse.Core.Tests
{
    public class YandexConnectionTests
    {
        private IYandexApi _api = new YandexApi();
        
        [Fact]
        public async Task Test()
        {
            await _api.AuthorizeByLoginAsync(new AuthByLoginRequest
            {
                Login = "qdumka@yandex.ru",
                Password = "qsc147wdv"
            });

            await _api.AuthorizeByXTokenAsync(_api.Session.XToken);
        }
    }
}