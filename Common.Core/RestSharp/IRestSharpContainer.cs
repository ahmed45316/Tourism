using System.Threading.Tasks;
using RestSharp;

namespace Common.Core.RestSharp
{
   public interface IRestSharpContainer
    {
        Task<T> SendRequest<T>(string uri, Method method, object obj = null);
    }
}
