using System.Net.Http;
using System.Threading.Tasks;

namespace HttUnicorn.Interfaces
{
    public interface IUnicornPutter
    {
        Task<TResponseBody> PutModelAsync<TRequestBody, TResponseBody>(TRequestBody obj, object key);
        Task<HttpResponseMessage> PutResponseAsync<T>(T obj, object key);
        Task<string> PutStringAsync<T>(T obj, object key);
    }
}