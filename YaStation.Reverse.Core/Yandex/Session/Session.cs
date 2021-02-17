using System.Net;

namespace YaStation.Reverse.Core.Yandex.Session
{
    public class Session : ISession
    {
        public string XToken { get; init; }
        
        public CookieCollection Cookies { get; init; }
    }
}