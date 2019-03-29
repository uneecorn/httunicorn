using System;
using System.Collections.Generic;
using HttUnicorn.Config;

namespace HttUnicorn.Request
{
    /// <summary>
    /// Represents an HttpRequest
    /// </summary>
    public class UnicornRequest
    {
        readonly UnicornConfig Config;

        /// <summary>
        /// Request headers
        /// </summary>
        public IList<UnicornHeader> Headers => Config.Headers;

        /// <summary>
        /// Request url
        /// </summary>
        public string Url => Config.Url;

        /// <summary>
        /// Request timeout
        /// </summary>
        public TimeSpan Timeout => Config.Timeout;

        /// <summary>
        /// Creates a request, to perform the request you must to call the Send() method
        /// </summary>
        /// <param name="config"></param>
        public UnicornRequest(UnicornConfig config)
        {
            Config = config;
        }
    }
}
