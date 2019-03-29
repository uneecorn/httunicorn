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
        public async Task<string> GetStringAync()
        {
            return await new UnicornGetter(Config).GetStringAync();
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
        public async Task<string> PostStringAsync<TRequestBody>(TRequestBody obj)
        {
            return await new UnicornPoster(Config).PostStringAsync(obj);
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

        /// <summary>
        /// Performs an HTTP DELETE Request
        /// </summary>
        /// <typeparam name="T">Response body's type</typeparam>
        /// <param name="key">Identifier</param>
        /// <returns>Response body deserialized to the specified type</returns>
        public async Task<T> DeleteModelAsync<T>(object key)
        {
            return await new UnicornDeleter(Config).DeleteModelAsync<T>(key);
        }

        /// <summary>
        /// Performs an HTTP DELETE Request
        /// </summary>
        /// <param name="key">Identifier</param>
        /// <returns>Pure response message</returns>
        public async Task<HttpResponseMessage> DeleteResponseAsync(object key)
        {
            return await new UnicornDeleter(Config).DeleteResponseAsync(key);
        }

        /// <summary>
        /// Performs an HTTP DELETE Request
        /// </summary>
        /// <param name="key">Identifier</param>
        /// <returns>Response body read as string</returns>
        public async Task<string> DeleteStringAsync(object key)
        {
            return await new UnicornDeleter(Config).DeleteStringAsync(key);
        }

        /// <summary>
        /// Performs an HTTP PUT Request
        /// </summary>
        /// <typeparam name="T">Model's type</typeparam>
        /// <param name="obj">Model</param>
        /// <param name="key">Identifier</param>
        /// <returns>Response body deserialized to the specified type</returns>
        public async Task<TResponseBody> PutModelAsync<TRequestBody, TResponseBody>(TRequestBody obj, object key)
        {
            return await new UnicornPutter(Config).PutModelAsync<TRequestBody, TResponseBody>(obj, key);
        }

        /// <summary>
        /// Performs an HTTP PUT Request
        /// </summary>
        /// <typeparam name="T">Model's type</typeparam>
        /// <param name="obj">Model</param>
        /// <param name="key">Identifier</param>
        /// <returns>Pure response message</returns>
        public async Task<HttpResponseMessage> PutResponseAsync<T>(T obj, object key)
        {
            return await new UnicornPutter(Config).PutResponseAsync(obj, key);
        }

        /// <summary>
        /// Performs an HTTP PUT Request
        /// </summary>
        /// <typeparam name="T">Model's type</typeparam>
        /// <param name="obj">Model</param>
        /// <param name="key">Identifier</param>
        /// <returns>Response body read as string</returns>
        public async Task<string> PutStringAsync<T>(T obj, object key)
        {
            return await new UnicornPutter(Config).PutStringAsync(obj, key);
        }
    }
}
