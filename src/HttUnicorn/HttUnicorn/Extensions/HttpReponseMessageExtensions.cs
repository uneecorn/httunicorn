using System.Threading.Tasks;

namespace System.Net.Http
{
    public static class HttpReponseMessageExtensions
    {
        public static async Task<string> ReadContentAsStringAsync(this HttpResponseMessage responseMessage)
        {
            return await responseMessage.Content.ReadAsStringAsync();
        }
    }
}
