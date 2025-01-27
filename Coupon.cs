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

        // Metoda do serializacji klasy Coupon jako czêœæ wiêkszej struktury danych
        //public void SerializeToXml(XmlSerializer serializer, Stream stream)
        //{
        //    try
        //    {
        //        serializer.Serialize(stream, this);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"B³¹d podczas serializacji kuponu: {ex.Message}");
        //    }
        //}

        // Konstruktor bezparametrowy wymagany do serializacji
        public Coupon() { }

        public override string ToString()
        {
            return $"{option} - {bettedMoney} z³, stawka: {stakeOnBetting}, potencjalna wygrana {stakeOnBetting * bettedMoney* 0.88m}";
        }

        //public object Clone()
        //{
        //    return new Coupon(this.user, this.bettedMoney, this.option);
        //}
        public int CompareTo(Coupon other)
        {
            if (other == null) return 1;

            // Porównanie na podstawie kwoty zak³adu w kolejnoœci malej¹cej
            return other.BettedMoney.CompareTo(this.BettedMoney);
        }
    }
}
