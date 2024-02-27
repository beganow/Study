
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace MyProject
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       public static  bool language = false;
        public static bool theme = true;
        public static string username;
        public static string password;
        public MainWindow()
        {
            InitializeComponent();
            Name = tb1.Text;
        }
        private void Image_MouseDown_Cross(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Image_MouseDown_Collapse(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void ToolBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (RightGrid.Visibility == Visibility.Hidden)
            {
                RightGrid.Visibility = Visibility.Visible;
             
            }
            else
            {
                RightGrid.Visibility = Visibility.Hidden;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            username = tb1.Text;
            password = tb2.Password;
   
            BD bd1 = new BD();
         

            if (tb1.Text == "Имя" || tb1.Text=="Name" || tb1.Text == "" || tb1.Text.Length>10)
            {
                MessageBox.Show("Введите настоящее имя");
                tb1.BorderBrush = Brushes.Red;
            }
            else
            {
                if (!char.IsUpper(tb1.Text[0]))
                {
                    MessageBox.Show("Первая буква в логине должна быть заглавной!");
                    tb1.BorderBrush = Brushes.Red;
                }
                else if (tb2.Password.Length < 8)
                {
                    tb1.BorderBrush = Brushes.Black;
                    MessageBox.Show("Пароль должен содержать минимум 8 символов!");
                    tb2.BorderBrush = Brushes.Red;
                }
                else
                {
                    tb2.BorderBrush = Brushes.Black;
                    tb1.BorderBrush = Brushes.Black;
                    bd1.InsertUser();
                    ListViewItems listView = new ListViewItems();
                    listView.NameAdmin.Text = tb1.Text;
                    listView.Show();
                    this.Close();
                }
            }
        }
        private void TextBlock_GotFocus(object sender, RoutedEventArgs e)
        {
            tb1.Text = "";
        }
        private void tb1_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tb1.Text))
            {
                tb1.SetResourceReference(TextBox.TextProperty, "name");
            }
        }
        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            if (language) language = false;
            else language = true;
            if (!language)
            {
                var uri = new Uri("Eng.xaml", UriKind.Relative);
                ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
                Application.Current.Resources.Clear();
                Application.Current.Resources.MergedDictionaries.Add(resourceDict);

            }
            else
            {
                var uri = new Uri("Rus.xaml", UriKind.Relative);
                ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
                Application.Current.Resources.Clear();
                Application.Current.Resources.MergedDictionaries.Add(resourceDict);
            }
        }
        private void Button_Click_22(object sender, RoutedEventArgs e)
        {
            {
                var uri = new Uri("Standart.xaml", UriKind.Relative);
                ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
                Application.Current.Resources.Clear();
                Application.Current.Resources.MergedDictionaries.Add(resourceDict);

            }
        }
        private void Button_Click_23(object sender, RoutedEventArgs e)
        {
            {
                var uri = new Uri("Brown.xaml", UriKind.Relative);
                ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
                Application.Current.Resources.Clear();
                Application.Current.Resources.MergedDictionaries.Add(resourceDict);

            }
        }
        private void Button_Click_24(object sender, RoutedEventArgs e)
        {
            {
                var uri = new Uri("Indigo.xaml", UriKind.Relative);
                ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
                Application.Current.Resources.Clear();
                Application.Current.Resources.MergedDictionaries.Add(resourceDict);

            }
        }
    }
}
