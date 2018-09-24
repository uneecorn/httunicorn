using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttUnicorn.Interfaces
{
    public interface IHasTimeoutSetter
    {
        IHttUnicorn SetTimeout(TimeSpan timeout);
    }
}
