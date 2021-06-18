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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AuthDef
{
    public partial class MainWindow : Window
    {
        AppContext DB;
        public MainWindow()
        {
            InitializeComponent();

            DB = new AppContext();
        }

        private void btnRegClick(object sender, RoutedEventArgs e)
        {
            string login = loginTextBox.Text.Trim();
            string pass = passwordPasBox.Password.Trim();
            string pass2 = password2PasBox.Password.Trim();
            string email = emailTextBox.Text.Trim().ToLower();

            if (login.Length < 5)
            {
                loginTextBox.ToolTip = "Введите логин от 5 символов";
                loginTextBox.Background = Brushes.Red;
            }
            else if (pass.Length < 6)
            {
                passwordPasBox.ToolTip = "Введите пароль от 6 символов";
                passwordPasBox.Background = Brushes.Red;
            }
            else if (pass != pass2)
            {
                password2PasBox.ToolTip = "Пароль не совпадает";
                password2PasBox.Background = Brushes.Red;
            }
            else if (email.Length < 5 || !email.Contains("@") || !email.Contains("."))
            {
                emailTextBox.ToolTip = "Введите корректный email";
                emailTextBox.Background = Brushes.Red;
            }
            else
            {
                loginTextBox.ToolTip = null;
                passwordPasBox.ToolTip = null;
                password2PasBox.ToolTip = null;
                emailTextBox.ToolTip = null;

                loginTextBox.Background = Brushes.Transparent;
                passwordPasBox.Background = Brushes.Transparent;
                password2PasBox.Background = Brushes.Transparent;
                emailTextBox.Background = Brushes.Transparent;

                MessageBox.Show("OK!");

                User user = new User(login, pass, email);

                DB.Users.Add(user);
                DB.SaveChanges();
            }
        }

        private void btnWinAuthClick(object sender, RoutedEventArgs e)
        {
            AuthWin authWin = new AuthWin();

            this.Hide();
            authWin.Show();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            foreach (Window w in App.Current.Windows)
                w.Close();
        }
    }
}
