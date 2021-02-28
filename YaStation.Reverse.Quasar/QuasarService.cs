using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using YaStation.Reverse.Core.Yandex.Api;

namespace YaStation.Reverse.Quasar
{
    public class QuasarService : IQuasarService
    {
        private readonly QuasarOptions _options;
        private readonly IYandexApi _yandexApi;

        private readonly string _baseUrl = "https://iot.quasar.yandex.ru/m/user";
        
        public QuasarService(IOptions<QuasarOptions> options, IYandexApi yandexApi) 
            : this(options.Value, yandexApi)
        {
        }
        
        public QuasarService(QuasarOptions options, IYandexApi yandexApi)
        {
            _options = options;
            _yandexApi = yandexApi;
        }

        public Task<DeviceListItem> GetDevicesAsync(CancellationToken token = new())
        {
            throw new System.NotImplementedException();
        }

        public Task<Device> GetDeviceAsync(CancellationToken token = new())
        {
            throw new System.NotImplementedException();
        }

        public Task<ScenarioListItem> GetScenariosAsync(CancellationToken token = new())
        {
            throw new System.NotImplementedException();
        }

        public Task<Scenario> AddScenarioAsync(CancellationToken token = new())
        {
            throw new System.NotImplementedException();
        }

        public Task<Intent> AddIntentAsync(CancellationToken token = new())
        {
            throw new System.NotImplementedException();
        }

        public Task SendToStationAsync(CancellationToken token = new())
        {
            throw new System.NotImplementedException();
        }

        public Task CallDeviceActionAsync(CancellationToken token = new())
        {
            throw new System.NotImplementedException();
        }

        public Task<DeviceConfiguration> GetDeviceConfigurationAsync(CancellationToken token = new())
        {
            throw new System.NotImplementedException();
        }

        public Task SetDeviceConfigurationAsync(CancellationToken token = new())
        {
            throw new System.NotImplementedException();
        }
    }
}