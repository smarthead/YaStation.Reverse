using System.Threading.Tasks;

namespace YaStation.Reverse.Core.Connection
{
    public interface IYandexApi
    {
        ISession Session { get; }
        
        Task AuthorizeByLoginAsync(AuthByLoginRequest request);
        
        Task AuthorizeByXTokenAsync(string xToken);
    }
}