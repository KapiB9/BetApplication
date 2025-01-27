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
    public partial class BettingWindow : Window
    {
        public User user;
        public AuthenticationSystem a;
        private List<Bet> activeBets = new List<Bet>
        {
            new wdlBet("Team A", "Team B"),
            new wlBet("Player A", "Player B")
        };

        public BettingWindow(User u, AuthenticationSystem a)
        {
            this.a = a;
            user = u;
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ActiveBets.ItemsSource = activeBets.Select(b => b.ToString()).ToList();
        }
        private void ActiveBets_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Sum.Text = "0.00";
            int selectedIndex = ActiveBets.SelectedIndex;

            if (selectedIndex >= 0 && selectedIndex < activeBets.Count)
            {
                var selectedBet = activeBets[selectedIndex];

                if (selectedBet is wdlBet wdl)
                {
                    BetChoice.ItemsSource = new List<Option> { wdl.Win, wdl.Lose, wdl.Draw };
                    Stake.Content = wdl.ShowStakes();
                }
                else if (selectedBet is wlBet wl)
                {
                    BetChoice.ItemsSource = new List<Option> { wl.Win, wl.Lose };
                    Stake.Content = wl.ShowStakes();
                }
            }
        }

        private void PlaceBet_Click(object sender, RoutedEventArgs e)
        {
            int selectedBetIndex = ActiveBets.SelectedIndex;
            Option selectedOption = BetChoice.SelectedItem as Option;

            if (selectedBetIndex >= 0 && selectedOption != null && decimal.TryParse(Sum.Text, out decimal potentialWin) && potentialWin > 0)
            {
                if (decimal.TryParse(cashPlaced.Text, out decimal bettedAmount) && bettedAmount > 0)
                {
                    // Sprawdzenie, czy użytkownik ma wystarczające środki na koncie
                    if (user.Balance >= bettedAmount)
                    {
                        Bet selectedBet = activeBets[selectedBetIndex];
                        selectedBet.AddCoupon(user, bettedAmount, selectedOption);
                        //selectedBet.AdjustStake();

                        MessageBox.Show($"Postawiłeś zakład: {selectedOption.Name}, Kwota: {bettedAmount} zł, Potencjalna wygrana: {potentialWin:0.00} zł!");
                    }
                    else
                    {
                        MessageBox.Show("Nie masz wystarczających środków na koncie, aby postawić zakład!");
                    }
                }
                else
                {
                    MessageBox.Show("Nieprawidłowa kwota zakładu! Wprowadź wartość większą niż 0.");
                }
            }
            else
            {
                MessageBox.Show("Wybierz zakład i opcję przed obstawieniem!");
            }
        }


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (decimal.TryParse(cashPlaced.Text, out decimal bettedAmount) && bettedAmount > 0)
            {
                Option selectedOption = BetChoice.SelectedItem as Option;

                if (selectedOption != null)
                {
                    decimal potentialWin = bettedAmount * 0.88m * selectedOption.Stake;
                    Sum.Text = potentialWin.ToString("0.00");
                }
                else
                {
                    Sum.Text = "0.00";
                }
            }
            else
            {
                Sum.Text = "0.00";
            }
        }

        public void Quit_Click(object sender, RoutedEventArgs e)
        {
            a.SaveUsers("users.xml");
            MainWindow mainW = new MainWindow();
            mainW.Show(); 
            this.Close();
        }
        private void Profil_Click(object sender, RoutedEventArgs e)
        {
            ProfilWindow ProfilW = new ProfilWindow(user, a);
            ProfilW.Show();  
            this.Close();
        }

    }
}
