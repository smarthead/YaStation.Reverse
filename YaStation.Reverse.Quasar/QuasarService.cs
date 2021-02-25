using System.Threading.Tasks;
using YaStation.Reverse.Core.Yandex.Api;

namespace YaStation.Reverse.Quasar
{
    public class QuasarService : IQuasarService
    {
        private readonly IYandexApi _yandexApi;

        public QuasarService(IYandexApi yandexApi)
        {
            _yandexApi = yandexApi;
        }
        
        public Task<DeviceListItem> GetDevices()
        {
            throw new System.NotImplementedException();
        }

        public Task<Device> GetDevice()
        {
            throw new System.NotImplementedException();
        }

        public Task<ScenarioListItem> GetScenarios()
        {
            throw new System.NotImplementedException();
        }

        public Task<Scenario> AddScenario()
        {
            throw new System.NotImplementedException();
        }

        public Task<Intent> AddIntent()
        {
            throw new System.NotImplementedException();
        }

        public Task SendToStation()
        {
            throw new System.NotImplementedException();
        }

        public Task CallDeviceAction()
        {
            throw new System.NotImplementedException();
        }

        public Task<DeviceConfiguration> GetDeviceConfiguration()
        {
            throw new System.NotImplementedException();
        }

        public Task SetDeviceConfiguration()
        {
            throw new System.NotImplementedException();
        }
    }
}