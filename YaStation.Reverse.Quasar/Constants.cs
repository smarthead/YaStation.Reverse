using System.Collections.Generic;

namespace YaStation.Reverse.Quasar
{
    public static class Constants
    {
        // https://github.com/AlexxIT/YandexStation
        public static Dictionary<string, string> IotTypes = new Dictionary<string, string>
        {
            {"on", "devices.capabilities.on_off"},
            {"temperature", "devices.capabilities.range"},
            {"fan_speed", "devices.capabilities.mode"},
            {"thermostat", "devices.capabilities.mode"},
            {"volume", "devices.capabilities.range"},
            {"pause", "devices.capabilities.toggle"},
            {"mute", "devices.capabilities.toggle"},
            {"channel", "devices.capabilities.range"},
            {"input_source", "devices.capabilities.mode"},
            {"brightness", "devices.capabilities.range"},
            {"color", "devices.capabilities.color_setting"},
            // don"t work
            {"hsv", "devices.capabilities.color_setting"},
            {"rgb", "devices.capabilities.color_setting"},
            {"temperature_k", "devices.capabilities.color_setting"},
        };
    }
}