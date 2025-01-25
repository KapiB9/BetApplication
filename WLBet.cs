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

        public wlBet(string o1, string o2) : base()
        {
            Win = new Option(o1);
            Lose = new Option(o2);
        }

        internal Option Win { get => win; set => win = value; }
        internal Option Lose { get => lose; set => lose = value; }

        public override void AdjustStake()
        {
            // Suma wszystkich zak³adów
            decimal totalBettedOn = 0;
            if (Win != null) totalBettedOn += Win.BettedOn;
            if (Lose != null) totalBettedOn += Lose.BettedOn;

            // Aktualizacja kursów na podstawie proporcji
            if (Win != null)
            {
                Win.Stake = totalBettedOn > 0 ? totalBettedOn / Win.BettedOn : 0; // Kurs = ca³kowita suma / stawka na Win
            }
            if (Lose != null)
            {
                Lose.Stake = totalBettedOn > 0 ? totalBettedOn / Lose.BettedOn : 0; // Kurs = ca³kowita suma / stawka na Lose
            }

        }
        public override string ToString()
        {
            return $"{win.Name} vs {lose.Name}";
        }
    }
}
