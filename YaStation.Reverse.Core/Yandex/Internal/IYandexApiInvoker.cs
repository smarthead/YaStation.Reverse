using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace YaStation.Reverse.Core.Yandex.Internal
{
    public interface IYandexApiInvoker
    {
        void SetCookies(CookieCollection cookies);
        
        void ClearCookies();
        
        Task<TOut> CallAsync<TOut>(HttpRequestMessage request, bool skipAuth = false, CancellationToken token = new());
    }
}