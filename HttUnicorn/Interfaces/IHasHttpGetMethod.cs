using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HttUnicorn.Interfaces
{
    public interface IHasHttpGetMethod
    {
        Task<HttpResponseMessage> GetOnlyResponseAsync();
        Task<string> GetAsync();
        Task<TResponseContent> GetAsync<TResponseContent>();
    }
}
