using HttUnicorn.Config;
using HttUnicorn.Convertion;
using HttUnicorn.Exceptions;
using HttUnicorn.Interfaces;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttUnicorn.Sender
{
    public class UnicornPutter : UnicornSender, IUnicornPutter
    {
        public UnicornPutter(UnicornConfig config) : base(config)
        {
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
            return Serializer.Deserialize<TResponseBody>(await PutStringAsync(obj, key));
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
            using (HttpClient client = new HttpClient())
            {
                foreach (UnicornHeader header in Config.Headers)
                {
                    client.DefaultRequestHeaders.Add(header.Name, header.Value);
                }
                return await client
                    .PutAsync(Config.Url + "/" + key,
                    ContentGenerator.Generate(obj));
            }
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
            using (HttpResponseMessage responseMessage =
                await PutResponseAsync(obj, key))
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
