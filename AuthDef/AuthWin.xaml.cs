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

namespace AuthDef
{
    /// <summary>
    /// Логика взаимодействия для AuthWin.xaml
    /// </summary>
    public partial class AuthWin : Window
    {
        AppContext DB;

        public AuthWin()
        {
            InitializeComponent();
        }

        private void btnAuthClick(object sender, RoutedEventArgs e)
        {
            string login = loginTextBox.Text.Trim();
            string pass = passwordPasBox.Password.Trim();

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
            else
            {
                loginTextBox.ToolTip = null;
                passwordPasBox.ToolTip = null;

                loginTextBox.Background = Brushes.Transparent;
                passwordPasBox.Background = Brushes.Transparent;

                User authUser = null;
                using (AppContext context = new AppContext())
                {
                    authUser = context.Users.Where(b => b.Login == login && b.Password == pass).FirstOrDefault();
                }

                if (authUser != null)
                {
                    MessageBox.Show("OK!");

                    DB = new AppContext();

                    List<User> users = DB.Users.ToList();

                    string email = "";

                    foreach(User user in users)
                    {
                        if (login == user.Login)
                            email = user.Email;
                    }

                    UsersProfile usersProfile = new UsersProfile(login, email);
                    
                    this.Hide();
                    usersProfile.Show();
                }
                else
                    MessageBox.Show("Dont OK!");
            }
        }

        private void BtnWinRegClick(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            this.Hide();
            mw.Show();
        }
    }
}
