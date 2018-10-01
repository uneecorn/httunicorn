using System.Net.Http;

namespace HttUnicorn.Interfaces
{
    public interface IHasHttpMethodSetter
    {
        IHttUnicornSender SetHttpMethod(HttpMethod method);
    }
}
