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
        private List<Bet> activeBets = new List<Bet>
        {
        new wdlBet("Team A", "Team B"),
        new wlBet("Player A", "Player B")

        };
        wdlBet xd = new wdlBet("pop", "ggg");



        public BettingWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Wypełnienie listy zakładów w ComboBox
            ActiveBets.ItemsSource = activeBets.Select(b => b.GetType().Name).ToList();
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
                    BetChoice.ItemsSource = new List<string> { ".Win", "wdl.Lose1", "Draw" };
                }
                else if (selectedBet is wlBet wl)
                {
                    BetChoice.ItemsSource = new List<string> { "Win", "Lose" };
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
                    User currentUser = new User("John", "Doe", "1234567890", "1234567812345678", "johndoe", "password");
                    currentUser.BalanceAdd(1000); // Dodanie środków na potrzeby testów

                    // Dodaj zakład
                    selectedBet.AddCoupon(currentUser, bettedAmount, selectedOption);

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
            ProfilWindow ProfilW = new ProfilWindow();
            ProfilW.Show();  // Wyświetl okno rejestracji

            // Zamknij obecne okno (MainWindow)
            this.Close();
        }
        
    }
}
