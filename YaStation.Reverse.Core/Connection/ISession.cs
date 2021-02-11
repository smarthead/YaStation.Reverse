using System.Collections.Generic;
using System.Threading.Tasks;

namespace YaStation.Reverse.Core.Connection
{
    public interface ISession
    {
        public string XToken { get; set; }
        
        public string OauthYaMusicToken { get; set; }

        public string CsrfToken { get; set; }
        
        public List<string> Cookies { get; set; }
    }

    public interface ISessionStore
    {
        ISession Get(string path = null);

        Task Set(ISession session);
    }
}