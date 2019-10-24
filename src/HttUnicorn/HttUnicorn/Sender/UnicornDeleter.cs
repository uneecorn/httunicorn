using HttUnicorn.Config;
using HttUnicorn.Convertion;
using HttUnicorn.Exceptions;
using HttUnicorn.Interfaces;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttUnicorn.Sender
{
    /// <summary>
    /// Provides methods to perform DELETE requests
    /// </summary>
    public class UnicornDeleter : UnicornSender, IUnicornDeleter
    {
        public UnicornDeleter(UnicornConfig config) : base(config)
        {
        }

        /// <summary>
        /// Performs an HTTP DELETE Request
        /// </summary>
        /// <typeparam name="T">Response body's type</typeparam>
        /// <param name="key">Identifier</param>
        /// <returns>Response body deserialized to the specified type</returns>
        public async Task<T> DeleteModelAsync<T>(object key)
        {
            return Serializer.Deserialize<T>(await DeleteStringAsync(key));
        }

        /// <summary>
        /// Performs an HTTP DELETE Request
        /// </summary>
        /// <param name="key">Identifier</param>
        /// <returns>Pure response message</returns>
        public async Task<HttpResponseMessage> DeleteResponseAsync(object key)
        {
            using (HttpClient client = new HttpClient())
            {
                foreach (UnicornHeader header in Config.Headers)
                {
                    client.DefaultRequestHeaders.Add(header.Name, header.Value);
                }
                return await client.DeleteAsync(Config.Url + "/" + key);
            }
        }

        /// <summary>
        /// Performs an HTTP DELETE Request
        /// </summary>
        /// <param name="key">Identifier</param>
        /// <returns>Response body read as string</returns>
        public async Task<string> DeleteStringAsync(object key)
        {
            using (HttpResponseMessage responseMessage = await DeleteResponseAsync(key))
            {
                if (!responseMessage.IsSuccessStatusCode)
                {
                    throw new HttpRequestUnicornException($"An error {responseMessage.StatusCode} ocurred while sending the request");
                }
                return await responseMessage.ReadContentAsStringAsync();
            }
        }
    }
}
