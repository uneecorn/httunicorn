using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttUnicorn.Interfaces
{
    public interface IHasHttpPostMethod
    {
        Task<TResponseContent> PostAsync<TResponseContent, TRequestContent>(TRequestContent obj);
    }
}
