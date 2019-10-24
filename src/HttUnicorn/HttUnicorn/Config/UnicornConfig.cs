using HttUnicorn.Util;
using HttUnicorn.Validations;
using System;
using System.Collections.Generic;

namespace HttUnicorn.Config
{
    /// <summary>
    /// HttUnicorn's config class
    /// </summary>
    public class UnicornConfig
    {
        string _url;
        /// <summary>
        /// Request's url
        /// </summary>
        public string Url
        {
            get => _url;
            private set
            {
                Validation.ValidateEmptyKey("Url", value);
                _url = value;
            }
        }

        /// <summary>
        /// Request's timeout
        /// </summary>
        public TimeSpan Timeout { get; private set; }

        /// <summary>
        /// Request's headers
        /// </summary>
        public IList<UnicornHeader> Headers { get; private set; }

        public static class UnicornConfigFactory
        {
            /// <summary>
            /// Creates a new config object
            /// </summary>
            /// <param name="url">Request's url</param>
            /// <param name="timeout">Request's timeout</param>
            /// <param name="headers">Request's headers</param>
            /// <returns>New instance of UnicornConfig class</returns>
            public static UnicornConfig NewInstance(string url,
                TimeSpan? timeout = null,
                IList<UnicornHeader> headers = null)
            {
                return new UnicornConfig
                {
                    Url = url,
                    Timeout = GetTimeout(timeout),
                    Headers = GetHeaders(headers),
                };
            }

            static TimeSpan GetTimeout(TimeSpan? timeout = null) => timeout ?? Constants.DEFAULT_TIMEOUT_VALUE;
            static IList<UnicornHeader> GetHeaders(IList<UnicornHeader> headers = null) => headers ?? Constants.DEFAULT_HEADERS;
        }

        private UnicornConfig() { }
    }
}
