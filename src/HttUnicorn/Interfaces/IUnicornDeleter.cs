using System.Net.Http;
using System.Threading.Tasks;

namespace HttUnicorn.Interfaces
{
    public interface IUnicornDeleter
    {
        /// <summary>
        /// Performs an HTTP DELETE Request
        /// </summary>
        /// <typeparam name="T">Response body's type</typeparam>
        /// <param name="key">Identifier</param>
        /// <returns>Response body deserialized to the specified type</returns>
        Task<T> DeleteModelAsync<T>(object key);

        /// <summary>
        /// Performs an HTTP DELETE Request
        /// </summary>
        /// <param name="key">Identifier</param>
        /// <returns>Pure response message</returns>
        Task<HttpResponseMessage> DeleteResponseAsync(object key);

        /// <summary>
        /// Performs an HTTP DELETE Request
        /// </summary>
        /// <param name="key">Identifier</param>
        /// <returns>Response body read as string</returns>
        Task<string> DeleteStringAsync(object key);
    }
}
