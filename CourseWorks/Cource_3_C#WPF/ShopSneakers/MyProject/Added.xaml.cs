using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml.Serialization;

namespace MyProject
{
    /// <summary>
    /// Логика взаимодействия для Added.xaml
    /// </summary>
    public partial class Added : Window
    {
        public static string selectedValue;
        public Added()
        {
            InitializeComponent();
   
        }
        private void Install_Image(object sender, RoutedEventArgs e)
        {
            // Создаем диалоговое окно для выбора файла
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Устанавливаем фильтр для выбора только изображений
            dlg.DefaultExt = ".jpg|.jpeg|.png";
            dlg.Filter = "Image files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png";

            // Открываем диалоговое окно и проверяем, что пользователь нажал кнопку "OK"
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                // Получаем путь к выбранному файлу и сохраняем его в строку
                string filename = dlg.FileName;
                field10.Text = filename;
            }
        }
        private void Image_MouseDown_Cross(object sender, MouseButtonEventArgs e)
        {
            ListViewItems listViewItem = new ListViewItems();
            listViewItem.Show();
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
        private void field4_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem comboBoxItem = (ComboBoxItem)field4.SelectedItem;
            selectedValue = comboBoxItem.Content.ToString();
        }
        public void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(field1.Text)) {
                MessageBox.Show("Пожалуйста заполните все поля!!!");
            }
            else if (Convert.ToDouble(field5.Text)>5 || Convert.ToDouble(field5.Text) < 1)
            {
                MessageBox.Show("Рейтинг может быть в диапазоне от 1 до 5");
            }
            else if (Convert.ToInt32(field7.Text) < 1)
            {
                MessageBox.Show("Количество не может быть отрицательно");
            }
            else if (Convert.ToDecimal(field8.Text) < 1){
                MessageBox.Show("Цена не может быть отрицательной");
            }
            else {
                Accept accept = new Accept();
                accept.Show();
                this.Close();
            }
        }
        public static string newfield1, newfield2, newfield3;

        private void field2_TextChanged(object sender, TextChangedEventArgs e)
        {
            newfield2 = field2.Text;
        }

        private void field10_TextChanged(object sender, TextChangedEventArgs e)
        {
            newfield3 = field10.Text;
        }

        private void field5_TextChanged(object sender, TextChangedEventArgs e)
        {
     
            newfield5 = field5.Text;
        }

        private void field6_TextChanged(object sender, TextChangedEventArgs e)
        {
            newfield6 = field6.Text;
        }

        private void field7_TextChanged(object sender, TextChangedEventArgs e)
        {
            newfield7 = field7.Text;
        }

        private void field8_TextChanged(object sender, TextChangedEventArgs e)
        {
            newfield8 = field8.Text;
        }

       public static string newfield5, newfield8;
       public static string newfield6, newfield7;

        private void field1_TextChanged(object sender, TextChangedEventArgs e)
        {
             newfield1 = field1.Text;
        }
    }
}
