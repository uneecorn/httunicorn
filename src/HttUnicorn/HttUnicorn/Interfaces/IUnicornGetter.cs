using System.Net.Http;
using System.Threading.Tasks;

namespace HttUnicorn.Interfaces
{
    public interface IUnicornGetter 
    {
        /// <summary>
        /// Performs an HTTP GET Request
        /// </summary>
        /// <typeparam name="T">Response body's Type</typeparam>
        /// <returns>Response body deserialized to the specified type</returns>
        Task<T> GetModelAsync<T>();

        /// <summary>
        /// Performs an HTTP GET Request
        /// </summary>
        /// <returns>Response body read as string</returns>
        Task<string> GetStringAync();

        /// <summary>
        /// Performs an HTTP GET Request
        /// </summary>
        /// <returns>Pure response message</returns>
        Task<HttpResponseMessage> GetResponseAsync();
    }
}
