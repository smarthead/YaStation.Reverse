using System.Net;

namespace YaStation.Reverse.Core.Yandex.Session
{
    public class Session : ISession
    {
        public string XToken { get; set; }

        public CookieCollection Cookies { get; set; } = new();
    }
}