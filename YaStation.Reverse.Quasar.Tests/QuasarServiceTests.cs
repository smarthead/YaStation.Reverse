using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using YaStation.Reverse.Core.Yandex.Api;
using YaStation.Reverse.Core.Yandex.Session;
using YaStation.Reverse.Quasar.Common;
using YaStation.Reverse.Quasar.Common.Capabilities;
using YaStation.Reverse.Quasar.Common.Triggers;
using YaStation.Reverse.Quasar.Scenarios;
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
            var scenarios = await service.GetScenariosAsync();
            var scenario = await service.GetScenarioAsync(scenarios.Scenarios.First().Id);
            
            var device = await service
                .GetDeviceAsync(
                    devices.AllDevices.First(x => x.Type == "devices.types.smart_speaker.yandex.station")
                .Id);

            await service.AddScenarioAsync(new AddScenarioRequest
            {
                Name = "Тестирование Колонки",
                Icon = Icon.Home,
                Triggers = new []
                {
                    new Trigger
                    {
                        Type = TriggerType.Voice,
                        Value = "Запусти мой тестовый навык",
                    }
                },
                Devices = new[]
                {
                    new ScenarioDevice
                    {
                        Id = device.Id,
                        Capabilities = new[]
                        {
                            new Capability
                            {
                                Type = "devices.capabilities.quasar.server_action",
                                State = new CapabilityState
                                {
                                    Instance = "phrase_action",
                                    Value = "Hello",
                                }
                            }
                        }
                    }
                }
            });
            
            Assert.NotNull(devices);
        }
    }
}