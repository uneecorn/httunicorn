using System.Threading.Tasks;

namespace HttUnicorn.Interfaces
{
    public interface IHttUnicorn :
        IHasUrlSetter,
        IHasHttpRequestHeadersSetter,
        IHasTimeoutSetter,
        IHasHttpGetMethod,
        IHasHttpPostMethod
    {
    }
}
