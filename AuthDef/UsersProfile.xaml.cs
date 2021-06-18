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
    public partial class UsersProfile : Window
    {
        private string login;
        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string Login
        {
            get { return login; }
            set { login = value; }
        }

        public UsersProfile(string login, string email)
        {
            this.login = login;
            this.email = email;

            InitializeComponent();

            lgnTextBlock.Text += Login;
            emailTextBlock.Text += email;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            foreach (Window w in App.Current.Windows)
                w.Close();
        }
    }
}
