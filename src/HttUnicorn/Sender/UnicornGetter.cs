using System;
using System.Net.Http;
using System.Threading.Tasks;
using HttUnicorn.Config;
using HttUnicorn.Convertion;
using HttUnicorn.Exceptions;
using HttUnicorn.Interfaces;

namespace HttUnicorn.Sender
{
    /// <summary>
    /// Provides methods to perform GET requests
    /// </summary>
    public class UnicornGetter : UnicornSender, IUnicornGetter
    {
        public UnicornGetter(UnicornConfig config) : base(config) { }

        /// <summary>
        /// Performs an HTTP GET Request
        /// </summary>
        /// <returns>Response body read as string</returns>
        public async Task<string> GetStringAync()
        {
            try
            {
                using (HttpResponseMessage responseMessage = await GetResponseAsync())
                {
                    if (!responseMessage.IsSuccessStatusCode)
                    {
                        throw new HttpRequestUnicornException($"An error {responseMessage.StatusCode} ocurred while sending the request");
                    }
                    return await responseMessage.ReadContentAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Performs an HTTP GET Request
        /// </summary>
        /// <typeparam name="T">Model's Type</typeparam>
        /// <returns>Response body deserialized to the specified type</returns>
        public async Task<T> GetModelAsync<T>()
        {
            try
            {
                return Serializer.Deserialize<T>(await GetStringAync());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Performs an HTTP GET Request
        /// </summary>
        /// <returns>Pure response message</returns>
        public async Task<HttpResponseMessage> GetResponseAsync()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    foreach (UnicornHeader header in Config.Headers)
                    {
                        client.DefaultRequestHeaders.Add(header.Name, header.Value);
                    }
                    return await client.GetAsync(Config.Url);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
