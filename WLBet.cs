using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetApplication
{
    internal class wlBet : Bet
    {
        Option win;
        Option lose;

        wlBet(string o1, string o2) : base()
        {
            Win = new Option(o1);
            Lose = new Option(o2);
        }

        internal Option Win { get => win; set => win = value; }
        internal Option Lose { get => lose; set => lose = value; }

        //public override void AdjustStake()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
