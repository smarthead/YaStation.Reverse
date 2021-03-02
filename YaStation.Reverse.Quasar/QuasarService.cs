using System;
using System.Threading;
using System.Threading.Tasks;
using YaStation.Reverse.Core.Yandex.Api;
using YaStation.Reverse.Quasar.Devices;
using YaStation.Reverse.Quasar.Scenarios;

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

        public async Task<GetDeviceResponse> GetDeviceAsync(Guid deviceId, CancellationToken token = new()) 
            => await _yandexApi
                .GetAsync<GetDeviceResponse>(
                    new Uri($"{_baseUrl}/devices/{deviceId}"),
                    token: token);

        public async Task<GetScenariosResponse> GetScenariosAsync(CancellationToken token = new())
            => await _yandexApi
                .GetAsync<GetScenariosResponse>(new Uri($"{_baseUrl}/scenarios"),token: token);

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