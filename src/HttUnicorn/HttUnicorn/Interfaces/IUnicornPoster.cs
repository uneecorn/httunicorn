using System.Net.Http;
using System.Threading.Tasks;

namespace HttUnicorn.Interfaces
{
    public interface IUnicornPoster
    {
        /// <summary>
        /// Performs an HTTP POST Request
        /// </summary>
        /// <typeparam name="TRequestBody">Request body's type</typeparam>
        /// <typeparam name="TResponseBody">Response body's type</typeparam>
        /// <param name="obj">Request body</param>
        /// <returns>Response body deserialized to the specified type</returns>
        Task<TResponseBody> PostModelAsync<TRequestBody, TResponseBody>(TRequestBody obj);

        /// <summary>
        /// Performs an HTTP POST Request
        /// </summary>
        /// <typeparam name="TRequestBody">Request body's type</typeparam>
        /// <param name="obj">Request body</param>
        /// <returns>Pure response message</returns>
        Task<HttpResponseMessage> PostRespnseAsync<TRequestBody>(TRequestBody obj);

        /// <summary>
        /// Performs an HTTP POST Request
        /// </summary>
        /// <typeparam name="TRequestBody">Request body's type</typeparam>
        /// <param name="obj">Request body</param>
        /// <returns>Response body read as string</returns>
        Task<string> PostStringAsync<TRequestBody>(TRequestBody obj);
    }
}