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
        public ProfilWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Recharge RW = new Recharge();
            RW.Show();
;
        }
        private void Comeback_Click(object sender, RoutedEventArgs e)
        {

            BettingWindow BetW = new BettingWindow();
            BetW.Show();  
            this.Close();
        }
    }
}
