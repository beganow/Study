using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public int value;
        public static DateTime order_date;
        public static DateTime order_delivery;
        public Buying()
        {
            InitializeComponent();
        }

     

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
        }

        private void paymentmetohod_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (((ComboBoxItem)paymentmetohod.SelectedItem).Content.ToString() == "Card")
            {
                value = 1;
            }
            else if (((ComboBoxItem)paymentmetohod.SelectedItem).Content.ToString() == "Cash")
            {
                value = 2;
            }
        }
        private bool ContainsDigits(string input)
        {
            // Проверяем, содержит ли строка хотя бы одну цифру
            foreach (char c in input)
            {
                if (char.IsDigit(c))
                {
                    return true;
                }
            }
            return false;
        }
        private bool ContainsLetter(string input)
        {
            // Проверяем, содержит ли строка хотя бы одну букву
            return input.Any(char.IsLetter);
        }

        private bool StartsAndEndsWithPlus(string input)
        {
            // Проверяем, начинается ли и заканчивается ли строка символом '+'
            return input.StartsWith("+");
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ContainsDigits(Country.Text))
            {
                MessageBox.Show("Ошибка: Текстовое поле не должно содержать цифры.");
            }
            if (!ContainsLetter(Phone.Text) && StartsAndEndsWithPlus(Phone.Text))
            {
               string s1 = Country.Text + ',' + Address.Text;
             BD bd1 = new BD();
            order_date =DateTime.Now;
            order_delivery = DateTime.Now.AddDays(2);
             bd1.AddOrder(ListViewItemsForUser.id_s, value, s1, order_delivery);
            bd1.AddOwnOrder(2, ListViewItemsForUser.id_s);
             MessageBox.Show("Заявка успешно отправлена");
            ListViewItemsForUser listViewItems = new ListViewItemsForUser();
            listViewItems.NameAdmin.Text = ListViewItemsForUser.userlog;
            listViewItems.Show();
            this.Close();
            }
            else
            {
                MessageBox.Show("Ошибка: Текстовое поле должно начинаться с '+' и содержать хотя бы одну букву.");
            }
           
           
        }
    }
}
