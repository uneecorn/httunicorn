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
    public class UnicornPoster : UnicornSender, IUnicornPoster
    {
        public UnicornPoster(UnicornConfig config) : base(config)
        {
        }

        /// <summary>
        /// Performs an HTTP POST Request
        /// </summary>
        /// <typeparam name="TRequestBody">Request body's type</typeparam>
        /// <param name="obj">Request body</param>
        /// <returns>Response body read as string</returns>
        public async Task<string> PostStringAsync<TRequestBody>(TRequestBody obj)
        {
            try
            {
                using (HttpResponseMessage responseMessage =
                    await PostRespnseAsync(obj))
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
        /// Performs an HTTP POST Request
        /// </summary>
        /// <typeparam name="TRequestBody">Request body's type</typeparam>
        /// <typeparam name="TResponseBody">Response body's type</typeparam>
        /// <param name="obj">Request body</param>
        /// <returns>Response body deserialized to the specified type</returns>
        public async Task<TResponseBody> PostModelAsync<TRequestBody, TResponseBody>(TRequestBody obj)
        {
            try
            {
                return Serializer.Deserialize<TResponseBody>(await PostStringAsync(obj));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Performs an HTTP POST Request
        /// </summary>
        /// <typeparam name="TRequestBody">Request body's type</typeparam>
        /// <param name="obj">Request body</param>
        /// <returns>Pure response message</returns>
        public async Task<HttpResponseMessage> PostRespnseAsync<TRequestBody>(TRequestBody obj)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    foreach (UnicornHeader header in Config.Headers)
                    {
                        client.DefaultRequestHeaders.Add(header.Name, header.Value);
                    }
                    return await client.PostAsync(Config.Url, ContentGenerator.Generate(obj));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
