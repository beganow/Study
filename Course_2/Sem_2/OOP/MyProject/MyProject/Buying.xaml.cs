using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для Buying.xaml
    /// </summary>
    public partial class Buying : Window
    {
        public Buying()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {  
            Phone.Text = "";
            Country.Text = "";
            string s5 = Phone.Text;
            string s1 = Country.Text;
            if (!Regex.IsMatch(s1, "^[a-zA-Zа-яА-ЯёЁ ]*$"))
            {
                MessageBox.Show("Error");
                Country.BorderBrush = Brushes.Red;
            }
            if (Regex.IsMatch(s5, "^[a-zA-Zа-яА-ЯёЁ]*$"))
            {
                MessageBox.Show("Error");
                Phone.BorderBrush = Brushes.Red;
            }
            else
            {
             MessageBox.Show("Заявка успешно отправлена");
            ListViewItems listViewItems = new ListViewItems();
            listViewItems.Show();
            this.Close();
            }
           
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            string s1 = Country.Text;
            if (!Regex.IsMatch(s1, "^[a-zA-Zа-яА-ЯёЁ ]*$"))
            {
                MessageBox.Show("Error");
                Country.BorderBrush = Brushes.Red;
            }
            else
            {
               
            }
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
        
            string s5 = Phone.Text;
            if (Regex.IsMatch(s5, "^[a-zA-Zа-яА-ЯёЁ]*$"))
            {
                MessageBox.Show("Error");
                Phone.BorderBrush = Brushes.Red;
            }
            else
            {
              
            }
        }
    }
}
