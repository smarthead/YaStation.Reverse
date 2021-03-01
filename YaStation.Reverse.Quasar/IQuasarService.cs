using System.Threading;
using System.Threading.Tasks;
using YaStation.Reverse.Quasar.Devices;

namespace YaStation.Reverse.Quasar
{
    public class ScenarioListItem
    {
        
    }
    
    public class Scenario
    {
        
    }

    public class Intent
    {
        
    }

    public class DeviceConfiguration
    {
        
    }
    
    public interface IQuasarService
    {
        Task<GetDevicesResponse> GetDevicesAsync(CancellationToken token);
        
        Task<ScenarioListItem> GetScenariosAsync(CancellationToken token);
        
        Task<Scenario> AddScenarioAsync(CancellationToken token);

        Task SendToStationAsync(CancellationToken token);
        
        Task CallDeviceActionAsync(CancellationToken token);
        
        Task<DeviceConfiguration> GetDeviceConfigurationAsync(CancellationToken token);
        
        Task SetDeviceConfigurationAsync(CancellationToken token);
        
        
    }
}