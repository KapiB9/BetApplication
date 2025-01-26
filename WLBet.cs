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
            // Suma wszystkich zak�ad�w
            decimal totalBettedOn = 0;
            if (Win != null) totalBettedOn += Win.BettedOn;
            if (Lose != null) totalBettedOn += Lose.BettedOn;

            // Aktualizacja kurs�w na podstawie proporcji
            if (Win != null)
            {
                Win.Stake = totalBettedOn > 0 ? totalBettedOn / Win.BettedOn : 0; // Kurs = ca�kowita suma / stawka na Win
            }
            if (Lose != null)
            {
                Lose.Stake = totalBettedOn > 0 ? totalBettedOn / Lose.BettedOn : 0; // Kurs = ca�kowita suma / stawka na Lose
            }

        }

        public override string GetWinner()
        {
            Random random = new Random();

            // Losowanie liczby ca�kowitej 0 lub 1
            int result = random.Next(0, 3);
            if (result == 0) { return Win.Name; }
            else { return Lose.Name; }

        }

        public override string ToString()
        {
            return $"{Win.Name} vs {Lose.Name}";
        }
        public string ShowStakes()
        {
            return $"{Win.Name}: {Win.Stake} || {Lose.Name}: {Lose.Stake}";
        }
    }
}
