using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetApplication
{
    internal class AuthenticationSystem
    {
        private List<User> users = new();
        public User SignUp(string firstName, string lastName, string pesel, string email,
            string birthDate, EnumPlec plec, string creditCard, string login, string password)
        {
            User user = new(firstName, lastName, pesel, email, birthDate, plec, creditCard, login, password);
            users.Add(user);
            return user;
        }

        public User LogIn(string login, string password)
        {
            User? user = users.Find(u => u.Login == login && u.Password == password);
            if (user == null)
            {
                throw new UnauthorizedAccessException("Error");
            }
            return user;
        }
    }
}
