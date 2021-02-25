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
        Task<DeviceListItem> GetDevices();
        
        Task<Device> GetDevice();

        Task<ScenarioListItem> GetScenarios();
        
        Task<Scenario> AddScenario();
        
        Task<Intent> AddIntent();
        
        Task SendToStation();
        
        Task CallDeviceAction();
        
        Task<DeviceConfiguration> GetDeviceConfiguration();
        
        Task SetDeviceConfiguration();
        
        
    }
}