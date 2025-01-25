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
        Option option;

        public Coupon(User user, decimal bettedMoney, Option option) : base()
        {
            this.user = user;
            this.bettedMoney = bettedMoney;
            this.option = option;
        }

        public decimal BettedMoney { get => bettedMoney; set => bettedMoney = value; }
        
        internal User User { get => user; set => user = value; }
        internal Option Option { get => option; set => option = value; }

        public void EndCoupon()
        {
            decimal winValue = 0.88m * bettedMoney * Option.Stake;
            User.BalanceAdd(winValue);
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
