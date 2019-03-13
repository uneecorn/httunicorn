using System;
using HttUnicorn.Exceptions;
using Newtonsoft.Json;

namespace HttUnicorn.Convertion
{
    /// <summary>
    /// JsonConvert helper
    /// </summary>
    public static class Serializer
    {
        /// <summary>
        /// Serializes an object
        /// </summary>
        /// <typeparam name="T">Object type</typeparam>
        /// <param name="obj">Object</param>
        /// <returns>Json String</returns>
        public static string Serialize<T>(T obj)
        {
            try
            {
                return JsonConvert.SerializeObject(obj);
            }
            catch (JsonSerializationException ex)
            {
                throw new SerializationUnicornException(ex);
            }
            catch (Exception ex)
            {
                throw new SerializationUnicornException(ex.Message);
            }
        }

        /// <summary>
        /// Deserializes an object
        /// </summary>
        /// <typeparam name="T">Object type</typeparam>
        /// <param name="jsonString">Json String</param>
        /// <returns>Desetialized object</returns>
        public static T Deserialize<T>(string jsonString)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(jsonString);
            }
            catch (JsonSerializationException ex)
            {
                throw new DeserializationUnicornException(ex);
            }
            catch (Exception ex)
            {
                throw new DeserializationUnicornException(ex.Message);
            }
        }
    }
}
