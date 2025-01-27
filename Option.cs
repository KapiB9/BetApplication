using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetApplication
{
    public class Option
    {
        string name;
        decimal stake;
        decimal bettedOn;

        public Option()
        {
            Stake = 1.5m;
            BettedOn = 0;
        }
        public Option(string name) : base()
        {
            this.Name = name;
            Random random = new Random();
            decimal min = 1.5m;
            decimal max = 3.20m;
            decimal res = (decimal)random.NextDouble() * (max - min) + min;
            Stake = Math.Round(res, 2);
        }

        public override string ToString()
        {
            return $"{name}";
        }

        public decimal BettedOn { get => bettedOn; set => bettedOn = value; }
        public decimal Stake { get => stake; set => stake = value; }
        public string Name { get => name; set => name = value; }
    }
}
