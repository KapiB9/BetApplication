using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BetApplication
{
    public class Coupon : IComparable<Coupon>
   {
        User user;
        decimal bettedMoney;
        public Option option;
        public decimal stakeOnBetting;

        public Coupon(User user, decimal bettedMoney, Option option) : base()
        {
            this.user = user;
            this.bettedMoney = bettedMoney;
            this.option = option;
            stakeOnBetting = option.Stake;
        }

        public decimal BettedMoney { get => bettedMoney; set => bettedMoney = value; }
        
        internal User User { get => user; set => user = value; }
        internal Option Option { get => option; set => option = value; }

        public void EndCoupon()
        {
            Random random = new Random();
            int result = random.Next(0, 2);

            decimal winValue = 0.88m * bettedMoney * stakeOnBetting * result;
            User.BalanceAdd(winValue);
        }


        public Coupon() { }

        public override string ToString()
        {
            return $"{option} - {bettedMoney:C2}, stawka: {stakeOnBetting}, pot. wygrana {stakeOnBetting * bettedMoney* 0.88m:C2}";
        }


        public int CompareTo(Coupon other)
        {
            if (other == null) return 1;

            return other.BettedMoney.CompareTo(this.BettedMoney);
        }
    }
}
