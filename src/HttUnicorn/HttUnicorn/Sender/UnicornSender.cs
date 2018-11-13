using HttUnicorn.Config;

namespace HttUnicorn.Sender
{
    public class UnicornSender
    {
        public UnicornConfig Config { get; private set; }

        public UnicornSender(UnicornConfig config)
        {
            Config = config;
        }
    }
}
