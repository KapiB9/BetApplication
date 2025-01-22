﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BetApplication
{
    enum EnumGender { Kobieta, Mężczyzna }
    internal class User
    {
        string firstName = string.Empty;
        string lastName = string.Empty;
        string pesel = string.Empty;
        string email = string.Empty;
        DateTime birthDate;
        EnumGender gender;
        string creditCard = string.Empty;
        string login = string.Empty;
        string password = string.Empty;
        decimal balance;
        List<Coupon> currentCoupons;
        List<Coupon> previousCoupons;

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
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
        public string Email { get => email; set => email = value; }
        public DateTime BirthDate
        {
            get => birthDate;
            set
            {
                var age = DateTime.Today.Year - value.Year;
                if (value > DateTime.Today.AddYears(-age))
                {
                    age--;
                }
                if (age < 18)
                {
                    throw new ArgumentException("Użytkownik musi być pełnoletni, aby założyć konto.");
                }
                birthDate = value;
            }
        }
        public string CreditCard
        {
            get => creditCard;
            set
            {
                if (!Regex.IsMatch(value, @"\d{26}"))
                {
                    throw new ArgumentException("");
                }
                pesel = creditCard;
            }
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

        public User(string firstName, string lastName, string pesel, string email,
            string birthDate, EnumGender gender, string creditCard, string login, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Pesel = pesel;
            Email = email;
            if (!DateTime.TryParseExact(birthDate, "dd-MM-yyyy", null,
                System.Globalization.DateTimeStyles.None, out DateTime bD))
            {
                throw new InvalidOperationException("Błędna format daty urodzenia!");
            }
            BirthDate = bD;
            this.gender = gender;
            CreditCard = creditCard;
            Login = login;
            Password = password;
            Balance = 0;
            currentCoupons = new();
            previousCoupons = new();

        }
        public void BalanceAdd(decimal amount)
        {
            Balance += amount;
        }
        public void BalanceSubstract(decimal amount)
        {
            Balance -= amount;
        }
        public override string ToString()
        {
            return $"Name: {firstName} {lastName}\nBalance: {Balance}$";
        }
    }
}