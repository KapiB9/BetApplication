using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BetApplication
{
    enum EnumPlec { Female, Male }
    internal class User
    {
        string firstName = string.Empty;
        string lastName = string.Empty;
        string pesel = string.Empty;
        string email = string.Empty;
        DateTime birthDate;
        EnumPlec plec;
        string creditCard = string.Empty;
        string login = string.Empty;
        string password = string.Empty;
        decimal balance;

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Pesel
        {
            get => pesel;
            set
            {
                if (!Regex.IsMatch(value, @"\d{11}"))
                {
                    throw new ArgumentException("");
                }
                pesel = value;
            }
        }
        public string Email { get => email; set => email = value; }
        public DateTime BirthDate { get => birthDate; set => birthDate = value; }
        public string CreditCard { get => creditCard; set => creditCard = value; }
        public string Login { get => login; set => login = value; }
        public string Password { get => password; set => password = value; }
        public decimal Balance { get => balance; set => balance = value; }

        public User(string firstName, string lastName, string pesel, string email,
            string birthDate, EnumPlec plec, string creditCard, string login, string password)
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
            this.plec = plec;
            CreditCard = creditCard;
            Login = login;
            Password = password;
            Balance = 0;
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