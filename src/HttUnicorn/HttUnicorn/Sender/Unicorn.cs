using HttUnicorn.Config;

namespace HttUnicorn.Sender
{
    public class Unicorn : HttpGetter
    {
        public Unicorn(UnicornConfig config) : base(config)
        {
        }
    }
}
