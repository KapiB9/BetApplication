using System;
using System.Collections.Generic;
using System.Configuration;
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
    public partial class SigningUp : Window
    {
        AuthenticationSystem a;
        public SigningUp(AuthenticationSystem a)
        {
            this.a = a;
            InitializeComponent();
        }
        public void SigningUp_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Firstname.Text) ||
                string.IsNullOrWhiteSpace(Surname.Text) ||
                string.IsNullOrWhiteSpace(Pesel.Text) ||
                string.IsNullOrWhiteSpace(CreditCard.Text) ||
                string.IsNullOrWhiteSpace(Login.Text) ||
                string.IsNullOrWhiteSpace(Password.Text) ||
                string.IsNullOrWhiteSpace(Birth_Date.Text))
            {
                MessageBox.Show("Wszystkie pola muszą być wypełnione!", "Błąd");
                return;
            }

            try
            {
                BettingWindow bettingWindow = new BettingWindow(a.SignUp(Firstname.Text, Surname.Text, Pesel.Text, CreditCard.Text, Birth_Date.Text, Login.Text, Password.Text), a);
                bettingWindow.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd: {ex.Message}", "Błąd");
            }

        }
        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            // Otwórz okno rejestracji
            MainWindow mainW = new MainWindow();
            mainW.Show();  // Wyświetl okno rejestracji

            // Zamknij obecne okno (MainWindow)
            this.Close();
        }
    }
}

