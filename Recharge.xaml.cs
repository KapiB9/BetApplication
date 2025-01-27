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
    /// Logika interakcji dla klasy Recharge.xaml
    /// </summary>
    public partial class Recharge : Window
    {
        private User user;
        public event Action BalanceUpdated;

        public Recharge(User u)
        {
            InitializeComponent();
            user = u;
        }

        private void AddBalance_Click(object sender, RoutedEventArgs e)
        {
            if (decimal.TryParse(Money.Text, out decimal amount) && amount > 0)
            {
                user.BalanceAdd(amount); 
                MessageBox.Show($"Dodano {amount:C} do Twojego konta.", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);

                BalanceUpdated?.Invoke(); 
                this.Close(); 
            }
            else
            {
                MessageBox.Show("Podaj poprawną kwotę.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
