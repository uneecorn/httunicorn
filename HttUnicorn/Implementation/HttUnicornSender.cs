using System;
using System.Net.Http;
using System.Threading.Tasks;
using HttUnicorn.Converters;
using HttUnicorn.Interfaces;

namespace HttUnicorn.Implementation
{
    public class HttUnicornSender : IHttUnicornSender
    {
        public string Url { get; private set; }

        readonly HttpClient Client;

        public HttUnicornSender()
        {
            Client = new HttpClient();
        }
        public IHttUnicornSender AddHttpRequestHeader(string name, string value)
        {
            Client.DefaultRequestHeaders.Add(name, value);
            return this;
        }

        public IHttUnicornSender SetUrl(string url)
        {
            Url = url;
            return this;
        }

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

        public IHttUnicornSender SetTimeout(TimeSpan timeout)
        {
            Client.Timeout = timeout;
            return this;
        }

        public async Task<string> GetJsonAsync()
        {
            try
            {
                using (HttpResponseMessage responseMessage = await GetResponseAsync())
                {
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        return await responseMessage.Content.ReadAsStringAsync();
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

        public async Task<HttpResponseMessage> GetResponseAsync()
        {
            try
            {
                HttpResponseMessage responseMessage = await Client.GetAsync(Url);
                return responseMessage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

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
    }
}
