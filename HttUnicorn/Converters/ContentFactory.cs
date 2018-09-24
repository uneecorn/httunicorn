using System;
using System.Net.Http;
using System.Text;

namespace HttUnicorn.Converters
{
    public static class ContentFactory
    {
        public static StringContent CreateContent<T>(
            T obj,
            Encoding encoding = null,
            string mediaType = "application/json"
        )
        {
            try
            {
                return new StringContent(Serializer.Serialize(obj), encoding ?? Encoding.UTF8, mediaType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
