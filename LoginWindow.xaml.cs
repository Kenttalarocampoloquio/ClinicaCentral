using System.Windows;
using System.Windows.Controls;

namespace ClinicaCentral
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void TxtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            lblPasswordHint.Visibility = txtPassword.Password.Length == 0
                ? Visibility.Visible
                : Visibility.Collapsed;
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            string user = txtUsername.Text.Trim();
            string pass = txtPassword.Password;

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Please enter your username and password.",
                    "Login", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            bool isValid = user == "admin" && pass == "admin123"; 

            if (isValid)
            {
                MessageBox.Show("Login successful!", "Login");
            }
            else
            {
                MessageBox.Show("Invalid credentials.", "Login",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Open your Register window here.", "Register");
        }
    }
}
