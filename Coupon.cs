using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetApplication
{
    public class Coupon
    {
        User user;
        decimal bettedMoney;
        string bettedOn;
        decimal stake;

        public Coupon(User user, decimal bettedMoney, string bettedOn, decimal stake) : base()
        {
            this.user = user;
            this.bettedMoney = bettedMoney;
            this.bettedOn = bettedOn;
            this.Stake = stake;
        }

        public decimal BettedMoney { get => bettedMoney; set => bettedMoney = value; }
        public string BettedOn { get => bettedOn; set => bettedOn = value; }
        public decimal Stake { get => stake; set => stake = value; }
        internal User User { get => user; set => user = value; }


        public void EndCoupon()
        {
            decimal winValue = bettedMoney * Stake;
            User.BalanceAdd(winValue);

        }

        public decimal PossibleWin()
        {
            return bettedMoney * Stake;
        }
    }
}
