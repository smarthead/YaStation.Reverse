using System.Net;

namespace YaStation.Reverse.Core.Yandex.Session
{
    public interface ISession
    {
        public string XToken { get; set; }

        public CookieCollection Cookies { get; set; }
    }
}