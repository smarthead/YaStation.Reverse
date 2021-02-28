using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace YaStation.Reverse.Core.Yandex.Api
{
    public interface IYandexApi
    {
        Task<bool> IsAuthorizedAsync();

        string GetXToken();
        
        Task AuthorizeByLoginAsync(AuthByLoginRequest request);
        
        Task AuthorizeByXToken(string xToken);

        Task<TOut> GetAsync<TIn, TOut>(Uri url, TIn query, 
            IDictionary<string, string> additionalHeaders = null, CancellationToken token = new());
        
        Task<TOut> PostAsync<TIn, TOut>(Uri url, TIn request, 
            IDictionary<string, string> additionalHeaders = null, CancellationToken token = new());
    }
}