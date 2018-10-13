using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttUnicorn.Interfaces
{
    public interface IHasHttpDeleteMethod
    {
        Task<TResponseContent> DeleteAsync<TResponseContent>(object key);
        Task<TResponseContent> DeleteAsync<TResponseContent>();
        Task DeleteAsync(object key);
        Task DeleteAsync();
        Task DeleteAsync<TRequestContent>(TRequestContent obj);
        Task<TResponseContent> DeleteAsync<TRequestContent, TResponseContent>(TRequestContent obj);
    }
}
