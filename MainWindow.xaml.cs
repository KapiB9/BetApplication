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
        AuthenticationSystem a;
        

        public MainWindow()
        {
            InitializeComponent();
            a = new AuthenticationSystem();

        }
        public MainWindow(AuthenticationSystem a) : base()
        {
            this.a = a;
        }
        void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text;
            string password = PasswordBox.Text;

            try
            {
                // Użyj systemu autoryzacji
                User user = a.LogIn(login, password);

                // Otwórz BettingWindow
                BettingWindow bettingWindow = new BettingWindow(user);
                bettingWindow.Show();

                // Zamknij LoginWindow
                this.Close();
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show("Błędny login lub hasło.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            // Otwórz okno rejestracji
            SigningUp signingUpWindow = new SigningUp(a);
            signingUpWindow.Show();  // Wyświetl okno rejestracji

            // Zamknij obecne okno (MainWindow)
            this.Close();
        }
        void Full_Quit(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}

            