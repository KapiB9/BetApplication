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
            this.Name = name;
        }

        public decimal BettedOn { get => bettedOn; set => bettedOn = value; }
        public decimal Stake { get => stake; set => stake = value; }
        public string Name { get => name; set => name = value; }
    }
}
