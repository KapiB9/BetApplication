﻿using System;
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

        public virtual string ShowStakes()
        {
            return "Stawki";
        }

    }
}
