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
   
    public partial class EditUserInfo : Window
    {
        public static string login;
        public EditUserInfo()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(UserName.Text)) {
                    if (!string.IsNullOrEmpty (UserName1.Text)) {
                        if (!string.IsNullOrEmpty(UserPassword2.Password))
                        {
                            login = UserName.Text;
                            BD bd1 = new BD();
                            bd1.EditUserInfo(login, UserName1.Text, UserPassword2.Password);
                            MessageBox.Show("Пользователь успешно изменен.");
                            ListViewItems listViewItems = new ListViewItems();
                            listViewItems.NameAdmin.Text = ListViewItems.userlog;
                            
                            listViewItems.Show();
                            this.Close();

                        }
                        else
                    {
                        MessageBox.Show("Введите значение New Password");
                    }
                    
                    }
                    else
                {
                    MessageBox.Show("Введите значение New Login");
                }
                
            }
            else
            {
                MessageBox.Show("Введите значение Login");
            }
     
 
          
        }
    }
}
