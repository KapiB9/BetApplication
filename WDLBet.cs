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

        public    Option Win { get => win; set => win = value; }
        public Option Lose { get => lose; set => lose = value; }
        public Option Draw { get => draw; set => draw = value; }


        


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
