using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttUnicorn.Helpers
{
    public class UnicornHeader
    {
        public string Name { get; private set; } 
        public string Value { get; private set; }

        public UnicornHeader(string name, string value)
        {
            Name = name;
            Value = value;
        }
    }
}
