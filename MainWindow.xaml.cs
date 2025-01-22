using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BetApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            

        }
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text;
            string password = PasswordBox.Text;

            try
            {
                // Użyj systemu autoryzacji
                AuthenticationSystem authSystem = new AuthenticationSystem();
                User user = authSystem.LogIn(login, password);

                // Otwórz BettingWindow
                BettingWindow bettingWindow = new BettingWindow();
                bettingWindow.Show();

                // Zamknij LoginWindow
                this.Close();
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show("Błędny login lub hasło.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            // Otwórz okno rejestracji
            SigningUp signingUpWindow = new SigningUp();
            signingUpWindow.Show();  // Wyświetl okno rejestracji

            // Zamknij obecne okno (MainWindow)
            this.Close();
        }
    }
}