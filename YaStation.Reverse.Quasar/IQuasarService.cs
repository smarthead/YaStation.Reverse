using System;
using System.Threading;
using System.Threading.Tasks;
using YaStation.Reverse.Quasar.Devices;
using YaStation.Reverse.Quasar.Scenarios;

namespace YaStation.Reverse.Quasar
{
    public class DeviceConfiguration
    {
        
    }
    
    public interface IQuasarService
    {
        Task<GetDevicesResponse> GetDevicesAsync(CancellationToken token);
        
        Task<GetDeviceResponse> GetDeviceAsync(Guid deviceId, CancellationToken token);
        
        Task<GetScenariosResponse> GetScenariosAsync(CancellationToken token);
        
        Task<GetScenarioResponse> GetScenarioAsync(Guid scenarioId, CancellationToken token);
        
        Task<Scenario> AddScenarioAsync(AddScenarioRequest request, CancellationToken token);

        Task CallDeviceActionAsync(CancellationToken token);
        
        Task<DeviceConfiguration> GetDeviceConfigurationAsync(CancellationToken token);
        
        Task SetDeviceConfigurationAsync(CancellationToken token);
        
        
    }
}