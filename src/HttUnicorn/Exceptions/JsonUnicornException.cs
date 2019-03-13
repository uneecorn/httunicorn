using System;
using Newtonsoft.Json;

namespace HttUnicorn.Exceptions
{
    /// <summary>
    /// The exception thrown when an error occurs during JSON serialization or deserialization.
    /// </summary>
    public class JsonUnicornException : Exception
    {
        public JsonSerializationException PreviousException { get; private set; }

        public JsonUnicornException(string message) : base(message)
        {
        }

        public JsonUnicornException(string message, JsonSerializationException previousException) : base(message)
        {
            PreviousException = previousException;
        }
    }
}
