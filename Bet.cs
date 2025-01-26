using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BetApplication
{

    abstract class Bet
    {
        private string name;
        bool active = true;

        public Bet() { }



        public  virtual void AddCoupon(User u, decimal bettedMoney, Option option)
        {
            // dodać sprawdzenie czy bettedOn jest na liście pot. zwycięzców
            if (u.Balance >= bettedMoney && bettedMoney > 0)
            {
                Coupon c = new Coupon(u, bettedMoney, option);
                u.BalanceSubstract(bettedMoney);
                u.AddCurrentCoupon(c);
            }
            else
            {
                Console.WriteLine("Nieprawidłowa kwota zakładu lub niewystarczające środki.");
            }
        }

        public virtual string GetWinner()
        {
            Random random = new Random();

            // Losowanie liczby całkowitej 0 lub 1
            int result = random.Next(0, 2);
            return result.ToString();
        }

        public void CloseBet(User user, string winner)
        {
            active = false;
            if (user.currentCoupons.Count == 0)
            {
                MessageBox.Show("Brak zakladow do roztrzygniecia");
            }
            else
            {
                //tu wywala nieobsusługiwany wyjątek
                foreach (Coupon c in user.currentCoupons)
                {
                    if (c.Option.Name != winner)
                    {
                        c.Option.Stake = 0;
                    }
                    c.EndCoupon();
                    user.MoveCouponToPrevious(c);
                }
            }
        }

        public abstract void AdjustStake();

        public virtual string ShowStakes()
        {
            return "Stawki";
        }

    }
}
