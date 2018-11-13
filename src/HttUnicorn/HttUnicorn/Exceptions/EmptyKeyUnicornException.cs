using System;

namespace HttUnicorn.Exceptions
{
    public class EmptyKeyUnicornException : Exception
    {
        /// <summary>
        /// Empty key name
        /// </summary>
        public string Key { get; private set; }

        /// <summary>
        /// Creates a new EmptyKeyUnicornException
        /// </summary>
        /// <param name="message">Exception's message</param>
        /// <param name="key">Empty key</param>
        public EmptyKeyUnicornException(string message, string key) : base(message)
        {
            Key = key;
        }
    }
}
