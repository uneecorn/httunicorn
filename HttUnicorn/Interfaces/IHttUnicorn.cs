using System.Threading.Tasks;

namespace HttUnicorn.Interfaces
{
    public interface IHttUnicorn :
        IHasUrlSetter,
        IHasHttpRequestHeadersSetter,
        IHasTimeoutSetter
    {
        Task<TResponseContent> Get<TResponseContent>();
        Task<TResponseContent> Post<TResponseContent, TRequestContent>(TRequestContent obj);
    }
}
