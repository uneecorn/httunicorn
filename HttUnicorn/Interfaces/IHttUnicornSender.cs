namespace HttUnicorn.Interfaces
{
    internal interface IHttUnicornSender :
        IHasUrlSetter,
        IHasHttpRequestHeadersSetter,
        IHasTimeoutSetter,
        IHasHttpGetMethod,
        IHasHttpPostMethod
    {
    }
}
