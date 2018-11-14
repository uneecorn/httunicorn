using System.Net.Http;
using System.Threading.Tasks;
using HttUnicorn.Config;
using HttUnicorn.Interfaces;

namespace HttUnicorn.Sender
{
    public class Unicorn : IUnicorn
    {
        readonly UnicornConfig Config;

        /// <summary>
        /// Creates a new Unicorn instance
        /// </summary>
        /// <param name="config">Config object</param>
        public Unicorn(UnicornConfig config)
        {
            Config = config;
        }

        /// <summary>
        /// Performs an HTTP GET Request
        /// </summary>
        /// <returns>Response body read as string</returns>
        public async Task<string> GetJsonAync()
        {
            return await new UnicornGetter(Config).GetJsonAync();
        }

        /// <summary>
        /// Performs an HTTP GET Request
        /// </summary>
        /// <typeparam name="T">Model's Type</typeparam>
        /// <returns>Response body deserialized to the specified type</returns>
        public async Task<T> GetModelAsync<T>()
        {
            return await new UnicornGetter(Config).GetModelAsync<T>();
        }

        /// <summary>
        /// Performs an HTTP GET Request
        /// </summary>
        /// <returns>Pure response message</returns>
        public async Task<HttpResponseMessage> GetResponseAsync()
        {
            return await new UnicornGetter(Config).GetResponseAsync();
        }

        /// <summary>
        /// Performs an HTTP POST Request
        /// </summary>
        /// <typeparam name="TRequestBody">Request body's type</typeparam>
        /// <param name="obj">Request body</param>
        /// <returns>Response body read as string</returns>
        public async Task<string> PostJsonAsync<TRequestBody>(TRequestBody obj)
        {
            return await new UnicornPoster(Config).PostJsonAsync(obj);
        }

        /// <summary>
        /// Performs an HTTP POST Request
        /// </summary>
        /// <typeparam name="TRequestBody">Request body's type</typeparam>
        /// <typeparam name="TResponseBody">Response body's type</typeparam>
        /// <param name="obj">Request body</param>
        /// <returns>Response body deserialized to the specified type</returns>
        public async Task<TResponseBody> PostModelAsync<TRequestBody, TResponseBody>(TRequestBody obj)
        {
            return await new UnicornPoster(Config).PostModelAsync<TRequestBody, TResponseBody>(obj);
        }

        /// <summary>
        /// Performs an HTTP POST Request
        /// </summary>
        /// <typeparam name="TRequestBody">Request body's type</typeparam>
        /// <param name="obj">Request body</param>
        /// <returns>Pure response message</returns>
        public async Task<HttpResponseMessage> PostRespnseAsync<TRequestBody>(TRequestBody obj)
        {
            return await new UnicornPoster(Config).PostRespnseAsync(obj);
        }
    }
}
