namespace HttUnicorn.Config
{
    /// <summary>
    /// HttUnicorn's representation for HttpHeader
    /// </summary>
    public class UnicornHeader
    {
        /// <summary>
        /// Header name
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Header value
        /// </summary>
        public string Value { get; private set; }

        /// <summary>
        /// Creates a new header to use in the request
        /// </summary>
        /// <param name="name">Header name</param>
        /// <param name="value">Header value</param>
        public UnicornHeader(string name, string value)
        {
            Name = name;
            Value = value;
        }
    }
}
