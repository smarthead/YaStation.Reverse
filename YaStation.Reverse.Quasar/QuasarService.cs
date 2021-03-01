using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using YaStation.Reverse.Core.Yandex.Api;
using YaStation.Reverse.Quasar.Devices;

namespace YaStation.Reverse.Quasar
{
    public class QuasarService : IQuasarService
    {
        private readonly IYandexApi _yandexApi;

        private readonly string _baseUrl = "https://iot.quasar.yandex.ru/m/user";
        
        public QuasarService(IYandexApi yandexApi)
        {
            _yandexApi = yandexApi;
        }

        public async Task<GetDevicesResponse> GetDevicesAsync(CancellationToken token = new()) 
            => await _yandexApi
                .GetAsync<GetDevicesResponse>(new Uri($"{_baseUrl}/devices"),token: token);

        public Task<ScenarioListItem> GetScenariosAsync(CancellationToken token = new())
        {
            throw new System.NotImplementedException();
        }

        public Task<Scenario> AddScenarioAsync(CancellationToken token = new())
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