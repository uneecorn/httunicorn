using HttUnicorn.Config;

namespace HttUnicorn.Sender
{
    public class HttUnicorn : HttpGetter
    {
        public HttUnicorn(UnicornConfig config) : base(config)
        {
        }
    }
}
