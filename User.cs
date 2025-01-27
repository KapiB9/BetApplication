﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BetApplication
{
    public class User
    {
        string firstName = string.Empty;
        string lastName = string.Empty;
        string pesel = string.Empty;
        string creditCard = string.Empty;
        string login = string.Empty;
        string password = string.Empty;
        decimal balance;
        public List<Coupon> currentCoupons;
        public List<Coupon> previousCoupons;

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        [XmlAttribute]
        public string Pesel
        {
            get => pesel;
            set
            {
                if (!Regex.IsMatch(value, @"\d{11}"))
                {
                    throw new ArgumentException("Pesel musi zawierać 11 cyfr.");
                }
                pesel = value;
            }
        }

        public string CreditCard
        {
            get => creditCard;
            set
            {
                if (!Regex.IsMatch(value, @"\d{26}"))
                {
                    throw new ArgumentException("Number IBN musi zawierać 26 cyfr.");
                }
                creditCard = value;
            }
        }

        public string BalanceString (decimal balance)
        {
            return balance.ToString();
        }

        public string Login { get => login; set => login = value; }
        public string Password
        {
            get => password;
            set
            {
                if (!Regex.IsMatch(value, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$"))
                {
                    throw new ArgumentException("Hasło musi zawierać co najmniej jedną dużą literę, jedną małą literę oraz jedną cyfrę.");
                }
                password = value;
            }
        }

        public decimal Balance { get => balance; set => balance = value; }

        public User()
        {
            currentCoupons = new();
            previousCoupons = new();
            Balance = 0;
        }

        public User(string firstName, string lastName, string pesel, string creditCard, string login, string password) : base()
        {
            FirstName = firstName;
            LastName = lastName;
            Pesel = pesel;
            CreditCard = creditCard;
            Login = login;
            Password = password;
        }

  
        public void BalanceAdd(decimal amount)
        {
            Balance += amount;
        }
        public void BalanceSubstract(decimal amount)
        {
            Balance -= amount;
        }

        public void AddCurrentCoupon(Coupon coupon)
        {
            currentCoupons.Add(coupon);
        }

        public void CloneCoupon(Coupon c)
        {
            AddCurrentCoupon((Coupon)c.Clone());
        }

        public override string ToString()
        {
            return $"Name: {firstName} {lastName}\nBalance: {Balance}$";
        }
    }
}