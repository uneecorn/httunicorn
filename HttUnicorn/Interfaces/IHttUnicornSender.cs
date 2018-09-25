namespace HttUnicorn.Interfaces
{
    public interface IHttUnicornSender :
        IHasUrlSetter,
        IHasHttpRequestHeadersSetter,
        IHasTimeoutSetter,
        IHasHttpGetMethod,
        IHasHttpPostMethod,
        IHasHttpPutMethod,
        IHasHttpDeleteMethod
    {
    }
}
