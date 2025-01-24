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
    /// <summary>
    /// Logika interakcji dla klasy SigningUp.xaml
    /// </summary>
    
    public partial class SigningUp : Window
    {
        AuthenticationSystem a = new();
        public SigningUp()
        {
            InitializeComponent();
        }
        public void SigningUp_Click(object sender, RoutedEventArgs e)
        {
            //    if (string.IsNullOrWhiteSpace(Firstname.Text) ||
            //        string.IsNullOrWhiteSpace(Surname.Text) ||
            //        string.IsNullOrWhiteSpace(Pesel.Text) ||
            //        string.IsNullOrWhiteSpace(CreditCard.Text) ||
            //        string.IsNullOrWhiteSpace(Login.Text) ||
            //        string.IsNullOrWhiteSpace(Password.Text))
            //    {
            //        MessageBox.Show("Wszystkie pola muszą być wypełnione!", "Błąd");
            //        return;
            //    }

            //    try
            //    {
            //        // Dodaj debugowanie
            //        Console.WriteLine($"Rejestracja: {Firstname.Text}, {Surname.Text}, {Pesel.Text}, {CreditCard.Text}, {Login.Text}");
            //        a.SignUp(Firstname.Text, Surname.Text, Pesel.Text, CreditCard.Text, Login.Text, Password.Text);

            //        BettingWindow bettingWindow = new BettingWindow();
            //        bettingWindow.Show();
            //        this.Close();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show($"Błąd: {ex.Message}", "Błąd");
            //    }
            a.test();
            BettingWindow bettingWindow = new BettingWindow();
            bettingWindow.Show();
            this.Close();
        }
        


    }
}

