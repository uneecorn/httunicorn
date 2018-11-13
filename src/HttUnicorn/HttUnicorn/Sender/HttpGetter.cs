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
    public class HttpGetter : UnicornSender, IHttpGetter
    {
        public HttpGetter(UnicornConfig config) : base(config) { }

        /// <inheritdoc />
        public async Task<string> GetJsonAync()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    foreach (UnicornHeader header in Config.Headers)
                    {
                        client.DefaultRequestHeaders.Add(header.Name, header.Value);
                    }
                    using (HttpResponseMessage responseMessage = await client.GetAsync(Config.Url))
                    {
                        if (!responseMessage.IsSuccessStatusCode)
                        {
                            throw new HttpRequestUnicornException($"An error {responseMessage.StatusCode} ocurred while sending the request");
                        }
                        return await responseMessage.ReadContentAsStringAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <inheritdoc />
        public async Task<T> GetModelAsync<T>()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    foreach (UnicornHeader header in Config.Headers)
                    {
                        client.DefaultRequestHeaders.Add(header.Name, header.Value);
                    }
                    using (HttpResponseMessage responseMessage = await client.GetAsync(Config.Url))
                    {
                        if (!responseMessage.IsSuccessStatusCode)
                        {
                            throw new HttpRequestUnicornException($"An error {responseMessage.StatusCode} ocurred while sending the request");
                        }
                        return Serializer.Deserialize<T>(await responseMessage.ReadContentAsStringAsync());
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <inheritdoc />
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
