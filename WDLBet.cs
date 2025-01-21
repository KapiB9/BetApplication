using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetApplication
{
    internal class wdlBet : Bet
    {
        Option Win;
        Option Lose;
        Option Draw;

        wdlBet() : base()
        {
            Draw = new Option("Draw");
        }
        wdlBet(string o1, string o2) : base()
        {
            Win = new Option(o1);
            Lose = new Option(o2);

        }

        //public override void AdjustStake()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
