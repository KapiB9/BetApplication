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

        public override void AdjustStake()
        {
            decimal totalBettedOn = 0;
            if (Win != null) totalBettedOn += Win.BettedOn;
            if (Lose != null) totalBettedOn += Lose.BettedOn;
            if (Draw != null) totalBettedOn += Draw.BettedOn;

            if (Win != null)
            {
                Win.Stake = totalBettedOn > 0 ? totalBettedOn / Win.BettedOn : 0; // Odwrotnoœæ proporcji
            }
            if (Lose != null)
            {
                Lose.Stake = totalBettedOn > 0 ? totalBettedOn / Lose.BettedOn : 0;
            }
            if (Draw != null)
            {
                Draw.Stake = totalBettedOn > 0 ? totalBettedOn / Draw.BettedOn : 0;
            }
        }
    }
}
