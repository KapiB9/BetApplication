using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetApplication
{
    internal class wdlBet : Bet
    {
        Option win;
        Option lose;
        Option draw;

        public wdlBet(string o1, string o2) : base()
        {
            win = new Option(o1);
            lose = new Option(o2);
            draw = new Option("Draw");
        }

        public Option Win { get => win; set => win = value; }
        public Option Lose { get => lose; set => lose = value; }
        public Option Draw { get => draw; set => draw = value; }

        public override string ToString()
        {
            return $"{win.Name} vs {lose.Name}";
        }
        public string ShowStakes()
        {
            return $"{Win.Name}: {Win.Stake} || Remis: {Draw.Stake} || {Lose.Name}: {Lose.Stake}";
        }
    }
}
