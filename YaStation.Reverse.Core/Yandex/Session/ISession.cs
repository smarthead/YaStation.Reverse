using System.Net;

namespace YaStation.Reverse.Core.Yandex.Session
{
    public interface ISession
    {
        public string XToken { get; init; }

        public CookieCollection Cookies { get; init; }
    }
}