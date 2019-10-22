using System.Net.Http;
using System.Text;

namespace HttUnicorn.Convertion
{
    public static class ContentGenerator
    {
        public static StringContent Generate<T>(T obj)
        {
            return new StringContent(Serializer.Serialize(obj), Encoding.UTF8, "application/json");
        }
    }
}
