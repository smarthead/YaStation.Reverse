using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace YaStation.Reverse.Core.Yandex.Internal
{
    public interface IYandexApiInvoker
    {
        void SetCookies(CookieCollection cookies);

        CookieCollection GetCookies();
        
        void ClearCookies();
        
        Task<TOut> CallAsync<TOut>(HttpRequestMessage request, bool skipAuth = false, CancellationToken token = new());
        
        Task<HttpResponseMessage> CallAsync(HttpRequestMessage request, bool skipAuth = false, CancellationToken token = new());
    }
}