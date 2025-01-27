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
            string password = PasswordBox.Password;

            try
            {
                User user = a.LogIn(login, password);
                BettingWindow bettingWindow = new BettingWindow(user, a);
                bettingWindow.Show();

                this.Close();
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show("Błędny login lub hasło.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            SigningUp signingUpWindow = new SigningUp(a);
            signingUpWindow.Show();  
            this.Close();
        }
        void Full_Quit(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

            