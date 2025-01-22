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
            Stake = 1.5m;
            BettedOn = 0;
        }
        public Option(string name)
        {
            this.name = name;
        }

        public decimal BettedOn { get => bettedOn; set => bettedOn = value; }
        public decimal Stake { get => stake; set => stake = value; }
    }
}
