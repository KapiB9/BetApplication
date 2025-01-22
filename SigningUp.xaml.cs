using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;



namespace BetApplication
{
    /// <summary>
    /// Logika interakcji dla klasy SigningUp.xaml
    /// </summary>
    public partial class SigningUp : Window
    {
        public SigningUp()
        {
            InitializeComponent();
        }
        public void SigningUp_Click(object sender, RoutedEventArgs e)
        {
            // Walidacja danych
            if (string.IsNullOrWhiteSpace(Firstname.Text) ||
                string.IsNullOrWhiteSpace(Surname.Text) ||
                string.IsNullOrWhiteSpace(Pesel.Text) ||
                string.IsNullOrWhiteSpace(CreditCard.Text) ||
                string.IsNullOrWhiteSpace(Login.Text) ||
                string.IsNullOrWhiteSpace(Password.Text))
            {
                MessageBox.Show("Wszystkie pola muszą być wypełnione!", "Błąd");
                return;
            }



            try
            {



                // Tworzenie użytkownika
                User u1 = new User(Firstname.Text, Surname.Text, Pesel.Text, CreditCard.Text, Login.Text, Password.Text);

                // Otwieranie nowego okna
                BettingWindow bettingWindow = new BettingWindow();
                bettingWindow.Show();

                // Zamknięcie aktualnego okna
                this.Close();
            }
            catch 
            {
                MessageBox.Show("Wszystkie pola muszą być wypełnione!", "Błąd");
                return;
            }
            
        }

    }
}

