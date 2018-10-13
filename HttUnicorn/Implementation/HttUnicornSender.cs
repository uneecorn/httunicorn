using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using HttUnicorn.Converters;
using HttUnicorn.Helpers;
using HttUnicorn.Interfaces;

namespace HttUnicorn.Implementation
{
    public class HttUnicornSender : IHttUnicornSender
    {
        /// <summary>
        /// Request's address.
        /// Default value: ""
        /// </summary>
        public string Url { get; private set; }

        /// <summary>
        /// Optional request's headers.
        /// </summary>
        public List<UnicornHeader> Headers { get; private set; }

        /// <summary>
        /// Request's timeout.
        /// Default value: 20 seconds
        /// </summary>
        public TimeSpan Timeout { get; private set; }

        public HttUnicornSender()
        {
            Headers = new List<UnicornHeader>();
            Timeout = new TimeSpan(0, 0, 20);
        }

        /// <summary>
        /// Adds a header to the request
        /// </summary>
        /// <param name="name">Header's name</param>
        /// <param name="value">Header's value</param>
        /// <returns>Recycled HttUnicornSender (this)</returns>
        public IHttUnicornSender AddHttpRequestHeader(string name, string value)
        {
            Headers.Add(new UnicornHeader(name, value));
            return this;
        }

        /// <summary>
        /// Sets the request's Url
        /// </summary>
        /// <param name="url"></param>
        /// <returns>Recycled HttUnicornSender (this)</returns>
        public IHttUnicornSender SetUrl(string url)
        {
            Url = url;
            return this;
        }

        /// <summary>
        /// Sets the request's timeout.
        /// </summary>
        /// <param name="timeout">Timeout's value</param>
        /// <returns>Recycled HttUnicornSender (this)</returns>
        public IHttUnicornSender SetTimeout(TimeSpan timeout)
        {
            Timeout = timeout;
            return this;
        }

        #region GET
        /// <summary>
        /// Performs an HttpGet Request.
        /// </summary>
        /// <typeparam name="TResponseContent">The type of the response body</typeparam>
        /// <returns>The response body deserialized to the specified type</returns>
        public async Task<TResponseContent> GetAsync<TResponseContent>()
        {
            try
            {
                string responseString = await GetAsync();
                return Serializer.Deserialize<TResponseContent>(responseString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Performs an HttpGet Request.
        /// </summary>
        /// <returns>The response body parsed as a JSON</returns>
        public async Task<string> GetAsync()
        {
            try
            {
                using (HttpResponseMessage responseMessage = await GetOnlyResponseAsync())
                {
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        string json = await responseMessage.Content.ReadAsStringAsync();
                        responseMessage.Dispose();
                        return json;
                    }
                    throw new HttpRequestException(
                        $"Status Code: {responseMessage.StatusCode}. Reason Phrase: {responseMessage.ReasonPhrase}"
                    );
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Performs an HttpGet Request.
        /// </summary>
        /// <returns>The pure response for the request</returns>
        public async Task<HttpResponseMessage> GetOnlyResponseAsync()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    foreach (UnicornHeader header in Headers)
                    {
                        client.DefaultRequestHeaders.Add(header.Name, header.Value);
                    }
                    return await client.SendAsync(new HttpRequestMessage
                    {
                        Method = HttpMethod.Get,
                        RequestUri = new Uri(Url)
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region POST

        public async Task<TResponseContent> PostAsync<TResponseContent, TRequestContent>(TRequestContent obj)
        {
            try
            {
                using (var request = new HttpRequestMessage
                {
                    Content = ContentFactory.CreateContent(obj),
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(Url)
                })
                {
                    using (var client = new HttpClient())
                    {
                        foreach (UnicornHeader header in Headers)
                        {
                            client.DefaultRequestHeaders.Add(header.Name, header.Value);
                        }
                        using (var responseMessage = await client.SendAsync(request))
                        {
                            if (responseMessage.IsSuccessStatusCode)
                            {
                                string responseString = await responseMessage.Content.ReadAsStringAsync();
                                return Serializer.Deserialize<TResponseContent>(responseString);
                            }
                            throw new HttpRequestException(
                                $"Status Code: {responseMessage.StatusCode}. Reason Phrase: {responseMessage.ReasonPhrase}"
                            );
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region PUT
        public async Task<TResponseContent> PutAsync<TResponseContent, TRequestContent>(TRequestContent obj)
        {
            try
            {
                using (var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Put,
                    RequestUri = new Uri(Url)
                })
                {
                    using (var client = new HttpClient())
                    {
                        foreach (UnicornHeader header in Headers)
                        {
                            client.DefaultRequestHeaders.Add(header.Name, header.Value);
                        }
                        using (var responseMessage = await client.SendAsync(request))
                        {
                            if (responseMessage.IsSuccessStatusCode)
                            {
                                string responseString = await responseMessage.Content.ReadAsStringAsync();
                                return Serializer.Deserialize<TResponseContent>(responseString);
                            }
                            throw new HttpRequestException(
                                $"Status Code: {responseMessage.StatusCode}. Reason Phrase: {responseMessage.ReasonPhrase}"
                            );
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region DELETE
        public async Task<TResponseContent> DeleteAsync<TResponseContent>(object key)
        {
            try
            {
                using (var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Delete,
                    RequestUri = new Uri($"{Url}/{key}")
                })
                {
                    using (HttpClient client = new HttpClient())
                    {
                        using (HttpResponseMessage responseMessage =
                            await client.SendAsync(request))
                        {
                            if (responseMessage.IsSuccessStatusCode)
                            {
                                string responseString = await responseMessage.Content.ReadAsStringAsync();
                                return Serializer.Deserialize<TResponseContent>(responseString);
                            }
                            throw new HttpRequestException(
                                $"Status Code: {responseMessage.StatusCode}. Reason Phrase: {responseMessage.ReasonPhrase}"
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteAsync(object key)
        {
            try
            {
                using (var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Delete,
                    RequestUri = new Uri($"{Url}/{key}")
                })
                {
                    using (HttpClient client = new HttpClient())
                    {
                        using (HttpResponseMessage responseMessage =
                        await client.SendAsync(request))
                        {
                            if (!responseMessage.IsSuccessStatusCode)
                            {
                                throw new HttpRequestException(
                                    $"Status Code: {responseMessage.StatusCode}. Reason Phrase: {responseMessage.ReasonPhrase}"
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TResponseContent> DeleteAsync<TResponseContent>()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage responseMessage =
                    await client.SendAsync(new HttpRequestMessage
                    {
                        Method = HttpMethod.Delete,
                        RequestUri = new Uri(Url)
                    }))
                    {
                        if (responseMessage.IsSuccessStatusCode)
                        {
                            string responseString = await responseMessage.Content.ReadAsStringAsync();
                            return Serializer.Deserialize<TResponseContent>(responseString);
                        }
                        throw new HttpRequestException(
                            $"Status Code: {responseMessage.StatusCode}. Reason Phrase: {responseMessage.ReasonPhrase}"
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteAsync()
        {
            try
            {
                using (var request = new HttpRequestMessage
                {
                    RequestUri = new Uri(Url),
                    Method = HttpMethod.Delete
                })
                {
                    using (HttpClient client = new HttpClient())
                    {
                        using (HttpResponseMessage responseMessage =
                        await client.SendAsync(request))
                        {
                            if (!responseMessage.IsSuccessStatusCode)
                            {
                                throw new HttpRequestException(
                                    $"Status Code: {responseMessage.StatusCode}. Reason Phrase: {responseMessage.ReasonPhrase}"
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteAsync<TRequestContent>(TRequestContent obj)
        {
            try
            {
                using (var request = new HttpRequestMessage
                {
                    Content = ContentFactory.CreateContent(obj),
                    Method = HttpMethod.Delete,
                    RequestUri = new Uri(Url)
                })
                {
                    using (var client = new HttpClient())
                    {
                        foreach (UnicornHeader header in Headers)
                        {
                            client.DefaultRequestHeaders.Add(header.Name, header.Value);
                        }
                        using (var responseMessage = await client.SendAsync(request))
                        {
                            if (!responseMessage.IsSuccessStatusCode)
                            {
                                throw new HttpRequestException(
                                    $"Status Code: {responseMessage.StatusCode}. Reason Phrase: {responseMessage.ReasonPhrase}"
                                );
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TResponseContent> DeleteAsync<TRequestContent, TResponseContent>(TRequestContent obj)
        {
            try
            {
                using (var request = new HttpRequestMessage
                {
                    Content = ContentFactory.CreateContent(obj),
                    Method = HttpMethod.Delete,
                    RequestUri = new Uri(Url)
                })
                {
                    using (var client = new HttpClient())
                    {
                        foreach (UnicornHeader header in Headers)
                        {
                            client.DefaultRequestHeaders.Add(header.Name, header.Value);
                        }
                        using (var responseMessage = await client.SendAsync(request))
                        {
                            if (responseMessage.IsSuccessStatusCode)
                            {
                                string responseString = await responseMessage.Content.ReadAsStringAsync();
                                return Serializer.Deserialize<TResponseContent>(responseString);
                            }
                            throw new HttpRequestException(
                                    $"Status Code: {responseMessage.StatusCode}. Reason Phrase: {responseMessage.ReasonPhrase}"
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
