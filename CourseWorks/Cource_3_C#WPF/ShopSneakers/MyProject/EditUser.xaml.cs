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

namespace MyProject
{
    /// <summary>
    /// Логика взаимодействия для EditUser.xaml
    /// </summary>
    public partial class EditUser : Window
    {
        public static string login;
        public static string password;
        public EditUser()
        {
            InitializeComponent();
        }

        private void UserName_TextChanged(object sender, TextChangedEventArgs e)
        {
            login = UserName.Text;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            password = UserPassword.Password;
            BD bd1 = new BD();
            ListViewItemsForUser l1 = new ListViewItemsForUser();
            l1.NameAdmin.Text = login;
            ListViewItemsForUser.userlog = login;
            ListViewItems.login = login;
            bd1.UpdateUser();
            this.Close();    
            l1.Show();
        }
    }
}
