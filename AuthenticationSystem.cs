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
        public List<User> users = new List<User>();

        public AuthenticationSystem()
        {
            users = LoadUsers(xmlfile);
        }

        public User SignUp(string firstName, string lastName, string pesel, string creditCard, string login, string password)
        {
            User user = new(firstName, lastName, pesel, creditCard, login, password);
            users.Add(user);
            SaveUsers(xmlfile);
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

        public void SaveUsers(string fileName)
        {
            try
            {
                using StreamWriter sw = new(fileName);
                XmlSerializer xs = new(typeof(List<User>));
                xs.Serialize(sw, users);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd podczas zapisywania pliku XML: {ex.Message}");
            }
        }

        public static List<User> LoadUsers(string fileName)
        {
            try
            {
                if (!File.Exists(fileName))
                {
                    return new List<User>();
                }
                using StreamReader sr = new(fileName);
                XmlSerializer xs = new(typeof(List<User>));
                return (List<User>)xs.Deserialize(sr);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd podczas wczytywania pliku XML: {ex.Message}");
                return new List<User>();
            }
        }
    }
}
