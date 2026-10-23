using System;
using System.Windows;
using System.Windows.Controls;

namespace ClinicaCentral
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();

            if (!Database.TestConnection(out string err))
            {
                MessageBox.Show("Cannot reach the database. Is MySQL running in Laragon?\n\n" + err,
                    "Database error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                Database.EnsureDefaultAdmin(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not prepare the users table:\n\n" + ex.Message,
                    "Database error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void TxtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            lblPasswordHint.Visibility = txtPassword.Password.Length == 0
                ? Visibility.Visible
                : Visibility.Collapsed;
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            string login = txtUsername.Text.Trim();
            string pass = txtPassword.Password;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Please enter your username and password.",
                    "Login", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                if (Database.Authenticate(login, pass, out string username, out string role))
                {
                    var dashboard = new DashboardWindow(username, role);
                    dashboard.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Invalid username or password.", "Login",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login failed:\n\n" + ex.Message, "Login",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Registration page coming soon.", "Register");
        }
    }
}