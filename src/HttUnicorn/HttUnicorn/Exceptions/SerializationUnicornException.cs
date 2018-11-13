using Newtonsoft.Json;

namespace HttUnicorn.Exceptions
{
    /// <summary>
    /// The exception thrown when an error occurs during JSON serialization.
    /// </summary>
    public class SerializationUnicornException : JsonUnicornException
    {
        public SerializationUnicornException(
            JsonSerializationException ex,
            string message = "An error ocurred while serializing object") : base(message)
        {
        }

        public SerializationUnicornException(
            string message = "An error ocurred while serializing object"
        ) : base(message)
        {
        }
    }
}
