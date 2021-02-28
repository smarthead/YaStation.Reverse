using System.IO;

namespace YaStation.Reverse.Core.Yandex.Api
{
    public class YandexApiOptions
    {
        public string SessionFilePath { get; set; } = Path.Join(Path.GetTempPath(),"ya.session");
        
        public string XTokenClientId { get; set; } = "c0ebe342af7d48fbbbfcf2d2eedb8f9e";

        public string XTokenClientSecret { get; set; } = "ad0a908f0aa341a182a37ecd75bc319e";

        public string ClientId { get; set; } = "f8cab64f154b4c8e96f92dac8becfcaa";

        public string ClientSecret { get; set; } = "5dd2389483934f02bd51eaa749add5b2";
        
        public string DisplayLanguage { get; set; } = "ru";

        public bool ForceRegister { get; set; } = false;

        public bool IsPhoneNumber { get; set; } = false;

        public int RetryCount { get; set; } = 5;
    }
}