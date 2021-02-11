namespace YaStation.Reverse.Core.Connection
{
    public class YandexApiOptions
    {
        public string XTokenClientId { get; set; } = "c0ebe342af7d48fbbbfcf2d2eedb8f9e";

        public string XTokenClientSecret { get; set; } = "ad0a908f0aa341a182a37ecd75bc319e";

        public string ClientId { get; set; } = "f8cab64f154b4c8e96f92dac8becfcaa";

        public string ClientSecret { get; set; } = "5dd2389483934f02bd51eaa749add5b2";
        
        public string YandexMusicClientId { get; set; } = "23cabbbdc6cd418abb4b39c32c41195d";
        
        public string YandexMusicClientSecret { get; set; } = "53bc75238f0c4d08a118e51fe9203300";

        public string DisplayLanguage { get; set; } = "ru";

        public bool ForceRegister { get; set; } = false;

        public bool IsPhoneNumber { get; set; } = false;
    }
}