using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetApplication
{
    internal class BetList
    {
        public List<Bet> activeBets = new List<Bet>
        {
            new wdlBet("Team A", "Team B"),
            new wlBet("Player A", "Player B")

        };

        public BetList()
        {
            Console.WriteLine("Baza przykladowych kuponow");
        }

        public void closeBets(User user)
        {
            foreach(Bet b in activeBets)
            {
                string winner = b.GetWinner();
                b.CloseBet(user, winner);
            }
        }
    }
}
