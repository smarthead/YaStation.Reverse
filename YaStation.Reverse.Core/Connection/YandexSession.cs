using System.Collections.Generic;

namespace YaStation.Reverse.Core.Connection
{
    public class YandexSession : ISession
    {
        public string XToken { get; set; }
        
        public string OauthYaMusicToken { get; set; }
        
        public string CsrfToken { get; set; }

        public List<string> Cookies { get; set; }
    }
}