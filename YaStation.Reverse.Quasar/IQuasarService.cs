using System.Threading;
using System.Threading.Tasks;

namespace YaStation.Reverse.Quasar
{
    public class DeviceListItem
    {
        
    }
    
    public class ScenarioListItem
    {
        
    }
    
    public class Device
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
        Task<DeviceListItem> GetDevicesAsync(CancellationToken token);
        
        Task<Device> GetDeviceAsync(CancellationToken token);

        Task<ScenarioListItem> GetScenariosAsync(CancellationToken token);
        
        Task<Scenario> AddScenarioAsync(CancellationToken token);
        
        Task<Intent> AddIntentAsync(CancellationToken token);
        
        Task SendToStationAsync(CancellationToken token);
        
        Task CallDeviceActionAsync(CancellationToken token);
        
        Task<DeviceConfiguration> GetDeviceConfigurationAsync(CancellationToken token);
        
        Task SetDeviceConfigurationAsync(CancellationToken token);
        
        
    }
}