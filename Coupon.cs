using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

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
            return bettedMoney * 0.88m * Stake;
        }

        // Metoda do serializacji klasy Coupon jako czêœæ wiêkszej struktury danych
        public void SerializeToXml(XmlSerializer serializer, Stream stream)
        {
            try
            {
                serializer.Serialize(stream, this);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"B³¹d podczas serializacji kuponu: {ex.Message}");
            }
        }

        // Konstruktor bezparametrowy wymagany do serializacji
        public Coupon() { }
    }
}
