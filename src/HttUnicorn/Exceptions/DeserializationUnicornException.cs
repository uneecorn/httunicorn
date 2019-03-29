using Newtonsoft.Json;

namespace HttUnicorn.Exceptions
{
    /// <summary>
    /// The exception thrown when an error occurs during JSON deserialization.
    /// </summary>
    public class DeserializationUnicornException : JsonUnicornException
    {
        public DeserializationUnicornException(
            JsonSerializationException ex,
            string message = "An error ocurred while serializing object") : base(message)
        {
        }

        public DeserializationUnicornException(
            string message = "An error ocurred while serializing object"
        ) : base(message)
        {
        }
    }
}
