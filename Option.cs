using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetApplication
{
    internal class Option
    {
        string name;
        decimal stake;
        decimal bettedOn;

        public Option()
        {
            stake = 1.5m;
            bettedOn = 0;
        }
        public Option(string name)
        {
            this.name = name;
        }
    }
}
