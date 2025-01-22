using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace BetApplication
{
    public class AuthenticationSystem
    {
        private string xmlfile = "users.xml";
        private List<User> users = new();
        public AuthenticationSystem()
        {
            LoadUsers();
        }
        public User SignUp(string firstName, string lastName, string pesel, string email,
            string birthDate, EnumGender gender, string creditCard, string login, string password)
        {
            User user = new(firstName, lastName, pesel, email, birthDate, gender, creditCard, login, password);
            users.Add(user);
            SaveUsers();
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

        private void SaveUsers()
        {
            XmlSerializer xs = new(typeof(List<User>));
            using FileStream fileStream = new(xmlfile, FileMode.Create);
            xs.Serialize(fileStream, users);
        }
        private void LoadUsers()
        {
            if (File.Exists(xmlfile))
            {
                XmlSerializer xs = new(typeof(List<User>));
                using FileStream fileStream = new(xmlfile, FileMode.Open);
                users = (List<User>)xs.Deserialize(fileStream) ?? new List<User>();
            }
        }
    }
}
