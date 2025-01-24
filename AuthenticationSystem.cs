using System;
using System.Collections.Generic;
using System.Configuration;
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
        public List<User> users =   new List<User>      {
            new User("Jan", "Kowalski", "12345678901", "11112222333344445555666677", "jk", "Jk1"),
            new User("Adam", "Nowak", "09876543211", "22223333444455556666777788", "an", "An1")
        };
            public void test()
        {
            SignUp("John", "D", "12343212341", "11112222333344445555666678", "asd", "As1");
        }
        public AuthenticationSystem()
        {
            LoadUsers();
        }
        public void SignUp(string firstName, string lastName, string pesel, string creditCard, string login, string password)
        {
            User user = new(firstName, lastName, pesel, creditCard, login, password);
            users.Add(user);
            SaveUsers();
            //return user;
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
