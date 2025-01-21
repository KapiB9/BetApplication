using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetApplication
{
    internal class Bet
    {
        class Bet
        {
            private string name;
            private List<Coupon> coupons;
            bool active = true;
            //dodać listę możliwych opcji

            public Bet()
            {
                coupons = new List<Coupon>();
            }

            public Bet(string name) : base()
            {
                this.name = name;
                this.coupons = new List<Coupon>();
            }

            public void AddCoupon(User u, decimal bettedMoney, string bettedOn)
            {
                // dodać sprawdzenie czy bettedOn jest na liście pot. zwycięzców
                if (u.balance >= bettedMoney && bettedMoney > 0)
                {
                    Coupon c = new Coupon(u, bettedMoney, bettedOn, 2);
                    u.balance -= bettedMoney;
                    coupons.Add(c);
                }
                else
                {
                    Console.WriteLine("Nieprawidłowa kwota zakładu lub niewystarczające środki.");
                }
            }

            public void CloseBet(string winner)
            {
                active = false;
                foreach (Coupon c in coupons)
                {
                    if (c.BettedOn != winner)
                    {
                        c.Stake = 0;
                    }
                    c.EndCoupon();
                }
            }

            //public abstract void AdjustStake();

        }
    }
