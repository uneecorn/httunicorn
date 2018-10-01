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
        public string Url { get; private set; }
        public List<UnicornHeader> Headers { get; private set; }
        public TimeSpan Timeout { get; private set; }
        public HttpMethod Method { get; private set; }

        readonly HttpClient Client;

        public HttUnicornSender()
        {
            Headers = new List<UnicornHeader>();
            //Client = new HttpClient();
        }
        public IHttUnicornSender AddHttpRequestHeader(string name, string value)
        {
            //Client.DefaultRequestHeaders.Add(name, value);
            Headers.Add(new UnicornHeader(name, value));
            return this;
        }

        public IHttUnicornSender SetUrl(string url)
        {
            Url = url;
            return this;
        }

        #region GET

        public async Task<TResponseContent> GetAsync<TResponseContent>()
        {
            try
            {
                string responseString = await GetJsonAsync();
                return Serializer.Deserialize<TResponseContent>(responseString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<string> GetJsonAsync()
        {
            try
            {
                HttpResponseMessage responseMessage = await GetResponseAsync();
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<HttpResponseMessage> GetResponseAsync()
        {
            try
            {
                HttpRequestMessage request = new HttpRequestMessage
                {
                    Method = Method,
                    RequestUri = new Uri(Url)
                };
                HttpClient client = new HttpClient();
                foreach (UnicornHeader header in Headers)
                {
                    client.DefaultRequestHeaders.Add(header.Name, header.Value);
                }
                HttpResponseMessage responseMessage = await client.SendAsync(request);
                client.Dispose();
                request.Dispose();
                return responseMessage;
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
                using (HttpResponseMessage responseMessage =
                    await Client.PostAsync(Url, ContentFactory.CreateContent(obj)))
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
                using (HttpResponseMessage responseMessage =
                    await Client.PutAsync(Url, ContentFactory.CreateContent(obj)))
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
                using (HttpResponseMessage responseMessage =
                    await Client.DeleteAsync($"{Url}/{key}"))
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteAsync(object key)
        {
            try
            {
                using (HttpResponseMessage responseMessage =
                    await Client.DeleteAsync($"{Url}/{key}"))
                {
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        string responseString = await responseMessage.Content.ReadAsStringAsync();
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
        #endregion

        public IHttUnicornSender SetTimeout(TimeSpan timeout)
        {
            Timeout = timeout;
            return this;
        }




        public IHttUnicornSender SetHttpMethod(HttpMethod method)
        {
            Method = method;
            return this;
        }
    }
}
