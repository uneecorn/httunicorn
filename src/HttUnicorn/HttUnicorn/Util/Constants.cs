using HttUnicorn.Config;
using System;
using System.Collections.Generic;

namespace HttUnicorn.Util
{
    public static class Constants
    {
        public static readonly short DEFAULT_TIMEOUT_SECONDS = 20;
        public static readonly TimeSpan DEFAULT_TIMEOUT_VALUE = TimeSpan.FromSeconds(DEFAULT_TIMEOUT_SECONDS);
        public static readonly IList<UnicornHeader> DEFAULT_HEADERS = new List<UnicornHeader>();
    }
}
