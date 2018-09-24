using HttUnicorn.Interfaces;
using Newtonsoft.Json;
using System;

namespace HttUnicorn.Serializer
{
    public class Serializer : ISerializer
    {
        public T Deserialize<T>(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Serialize<T>(T obj)
        {
            try
            {
                return JsonConvert.SerializeObject(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
