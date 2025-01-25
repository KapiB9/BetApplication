using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void CloseBet(User user, string winner)
        {
            active = false;
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

        public abstract void AdjustStake();

        public virtual string ShowStakes()
        {
            return "Stawki";
        }

    }
}
