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

        /// <summary>
        /// Creates a new config object with default timeout (20 seconds),
        /// default header list (empty list), specified url and method.
        /// </summary>
        /// <param name="url">Request's url</param>
        public UnicornConfig(string url)
        {
            Url = url;
            Timeout = Constants.DEFAULT_TIMEOUT_VALUE;
            Headers = Constants.DEFAULT_HEADERS;
        }

        /// <summary>
        /// Creates a new config object with default header list (empty list),
        /// specified url, method and timeout
        /// </summary>
        /// <param name="url">Request's url</param>
        /// <param name="timeout">Request's timeout</param>
        public UnicornConfig(string url, TimeSpan timeout)
        {
            Url = url;
            Timeout = timeout;
            Headers = Constants.DEFAULT_HEADERS;
        }

        /// <summary>
        /// Creates a new config object with default header list (empty list),
        /// specified url, method and timeout
        /// </summary>
        /// <param name="url">Request's url</param>
        /// <param name="timeout">Request's timeout</param>
        public UnicornConfig(string url, short timeoutSeconds)
        {
            Url = url;
            Timeout = TimeSpan.FromSeconds(timeoutSeconds);
            Headers = Constants.DEFAULT_HEADERS;
        }

        /// <summary>
        /// Creates a new config object with default timeout (20 seconds),
        /// specified url, method and header list
        /// </summary>
        /// <param name="url">Request's url</param>
        /// <param name="headers">Request's headers</param>
        public UnicornConfig(string url, IList<UnicornHeader> headers)
        {
            Url = url;
            Headers = headers;
            Timeout = Constants.DEFAULT_TIMEOUT_VALUE;
        }

        /// <summary>
        /// Creates a new config object with specified url, 
        /// method, timeout and header list
        /// </summary>
        /// <param name="url">Request's url</param>
        /// <param name="timeout">Request's timeout</param>
        /// <param name="headers">Request's headers</param>
        public UnicornConfig(string url, TimeSpan timeout, IList<UnicornHeader> headers)
        {
            Url = url;
            Timeout = timeout;
            Headers = headers;
        }
    }
}
