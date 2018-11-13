using System.Net.Http;
using System.Threading.Tasks;

namespace HttUnicorn.Interfaces
{
    public interface IHttpGetter 
    {
        /// <summary>
        /// Performs an HTTP GET Request
        /// </summary>
        /// <typeparam name="T">Model's Type</typeparam>
        /// <returns>Response body deserialized to the specified type</returns>
        Task<T> GetModelAsync<T>();

        /// <summary>
        /// Performs an HTTP GET Request
        /// </summary>
        /// <returns>Response body read as string</returns>
        Task<string> GetJsonAync();

        /// <summary>
        /// Performs an HTTP GET Request
        /// </summary>
        /// <returns>Pure response message</returns>
        Task<HttpResponseMessage> GetResponseAsync();
    }
}
