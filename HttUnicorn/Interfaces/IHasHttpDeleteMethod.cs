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
        Task DeleteAsync(object key);
    }
}
