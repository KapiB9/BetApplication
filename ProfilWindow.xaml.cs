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
    /// Logika interakcji dla klasy ProfilWindow.xaml
    /// </summary>
    public partial class ProfilWindow : Window
    {
        User user;
        public ProfilWindow(User u)
        {
            user = u;
            InitializeComponent();
            Login.Content = u.Login;
            Balance.Text = u.BalanceString(u.Balance);
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Recharge RW = new Recharge(user);
            RW.BalanceUpdated += () =>
            {
                // Odśwież balans na widoku po zamknięciu okna Recharge
                Balance.Text = user.Balance.ToString();
            };
            RW.Show();
            
            
        }
        private void Comeback_Click(object sender, RoutedEventArgs e)
        {

            BettingWindow BetW = new BettingWindow(user);
            BetW.Show();  
            this.Close();
        }
        
    }
}
