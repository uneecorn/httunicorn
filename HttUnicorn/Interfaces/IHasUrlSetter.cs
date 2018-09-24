using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttUnicorn.Interfaces
{
    internal interface IHasUrlSetter
    {
        IHttUnicornSender SetUrl(string url);
    }
}
