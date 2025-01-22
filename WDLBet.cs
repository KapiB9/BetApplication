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

        public wdlBet() : base()
        {
            Draw1 = new Option("Draw");
        }
        public wdlBet(string o1, string o2) : base()
        {
            Win1 = new Option(o1);
            Lose1 = new Option(o2);
        }

        public    Option Win1 { get => Win; set => Win = value; }
        public Option Lose1 { get => Lose; set => Lose = value; }
        public Option Draw1 { get => Draw; set => Draw = value; }


        


        public override void AdjustStake()
        {
            decimal totalBettedOn = 0;
            if (Win1 != null) totalBettedOn += Win1.BettedOn;
            if (Lose1 != null) totalBettedOn += Lose1.BettedOn;
            if (Draw1 != null) totalBettedOn += Draw1.BettedOn;

            if (Win1 != null)
            {
                Win1.Stake = totalBettedOn > 0 ? totalBettedOn / Win1.BettedOn : 0; // Odwrotnoœæ proporcji
            }
            if (Lose1 != null)
            {
                Lose1.Stake = totalBettedOn > 0 ? totalBettedOn / Lose1.BettedOn : 0;
            }
            if (Draw1 != null)
            {
                Draw1.Stake = totalBettedOn > 0 ? totalBettedOn / Draw1.BettedOn : 0;
            }
        }
    }
}
