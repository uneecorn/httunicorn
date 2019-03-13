using System;

namespace HttUnicorn.Exceptions
{
    public class HttpRequestUnicornException : Exception
    {
        public HttpRequestUnicornException(string message) : base(message)
        {
        }
    }
}
