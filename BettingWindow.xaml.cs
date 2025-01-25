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
    /// Logika interakcji dla klasy BettingWindow.xaml
    /// </summary>
    public partial class BettingWindow : Window
    {
        public User user;

        private List<Bet> activeBets = new List<Bet>
        {
        new wdlBet("Team A", "Team B"),
        new wlBet("Player A", "Player B")

        };

        public BettingWindow(User u)
        {
            user = u;
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Wypełnienie listy zakładów w ComboBox
            ActiveBets.ItemsSource = activeBets.Select(b => b.ToString()).ToList();
        }
        private void ActiveBets_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Pobierz wybrany zakład
            int selectedIndex = ActiveBets.SelectedIndex;
            if (selectedIndex >= 0 && selectedIndex < activeBets.Count)
            {
                var selectedBet = activeBets[selectedIndex];

                // Wypełnij opcje w BetChoice w zależności od zakładu
                if (selectedBet is wdlBet wdl)
                {
                    wdlBet b = (wdlBet)selectedBet;
                    BetChoice.ItemsSource = new List<string> { b.Win.Name, b.Lose.Name, "Draw" };
                }
                else if (selectedBet is wlBet wl)
                {
                    wlBet b = (wlBet)selectedBet;
                    BetChoice.ItemsSource = new List<string> { b.Win.Name, b.Lose.Name };
                }
            }
        }
        private void PlaceBet_Click(object sender, RoutedEventArgs e)
        {
            // Pobierz wybrany zakład i opcję
            int selectedBetIndex = ActiveBets.SelectedIndex;
            string selectedOption = BetChoice.SelectedItem as string;

            if (selectedBetIndex >= 0 && !string.IsNullOrEmpty(selectedOption))
            {
                // Pobierz wybrany zakład
                Bet selectedBet = activeBets[selectedBetIndex];

                // Pobierz kwotę zakładu
                if (decimal.TryParse(cashPlaced.Text, out decimal bettedAmount))
                {
                    // Przykładowy użytkownik
                    // Dodaj zakład
                    selectedBet.AddCoupon(user, bettedAmount, selectedOption);

                    MessageBox.Show($"Postawiłeś zakład: {selectedOption}, Kwota: {bettedAmount}!");
                }
                else
                {
                    MessageBox.Show("Nieprawidłowa kwota zakładu!");
                }
            }
            else
            {
                MessageBox.Show("Wybierz zakład i opcję!");
            }
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Obsługa zdarzenia, np. weryfikacja wprowadzonych danych
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                string input = textBox.Text;

                // Opcjonalnie: sprawdzanie poprawności wprowadzanych danych
                if (!decimal.TryParse(input, out decimal result))
                {
                    MessageBox.Show("Wprowadź poprawną kwotę zakładu!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }
        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            // Otwórz okno rejestracji
            MainWindow mainW = new MainWindow();
            mainW.Show();  // Wyświetl okno rejestracji

            // Zamknij obecne okno (MainWindow)
            this.Close();
        }
        private void Profil_Click(object sender, RoutedEventArgs e)
        {
            // Otwórz okno rejestracji
            ProfilWindow ProfilW = new ProfilWindow(user);
            ProfilW.Show();  // Wyświetl okno rejestracji

            // Zamknij obecne okno (MainWindow)
            this.Close();
        }
        
    }
}
