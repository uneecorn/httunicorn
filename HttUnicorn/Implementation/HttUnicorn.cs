using System;
using System.Net.Http;
using System.Threading.Tasks;
using HttUnicorn.Converters;
using HttUnicorn.Enum;
using HttUnicorn.Interfaces;

namespace HttUnicorn.Implementation
{
    public class HttUnicorn : IHttUnicorn
    {
        public string Url { get; private set; }

        readonly HttpClient Client;

        public HttUnicorn()
        {
            Client = new HttpClient();
        }
        public IHttUnicorn AddHttpRequestHeader(string name, string value)
        {
            Client.DefaultRequestHeaders.Add(name, value);
            return this;
        }

        public IHttUnicorn SetUrl(string url)
        {
            Url = url;
            return this;
        }

        public async Task<TResponseContent> GetAsync<TResponseContent>()
        {
            try
            {
                using (HttpResponseMessage responseMessage = await Client.GetAsync(Url))
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

        public async Task<TResponseContent> PostAsync<TResponseContent, TRequestContent>(TRequestContent obj)
        {
            try
            {
                using (HttpResponseMessage responseMessage = await Client.PostAsync(Url, ContentFactory.CreateContent(obj)))
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

        public IHttUnicorn SetTimeout(TimeSpan timeout)
        {
            Client.Timeout = timeout;
            return this;
        }
    }
}
