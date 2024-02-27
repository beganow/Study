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
    /// Логика взаимодействия для Edit.xaml
    /// </summary>
    public partial class Edit : Window
    {
        public static string selectedValue;
        public Edit()
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
        public void Button_Click(object sender1, RoutedEventArgs e)
        {

            BD bd1 = new BD();
           
            Items list = new Items();
            XmlSerializer serializer = new XmlSerializer(typeof(Items));
            using (FileStream stream = new FileStream("book.xml", FileMode.Open))
            {
                list = (Items)serializer.Deserialize(stream);
            }


            var list2 = ListViewItems.MyListViewSneakers.ItemsSource as List<Item>;
            // Найти индекс выбранного элемента в списке
            int index = list2.IndexOf(Item.selectedItem);

            Item.selectedItem.Name = newfield1;
            Item.selectedItem.FullName = newfield2;
            Item.selectedItem.Image = newfield3;
            Item.selectedItem.Category = selectedValue;
            Item.selectedItem.Rate = Double.Parse(newfield5);
            Item.selectedItem.Size = Int32.Parse(newfield6);
            Item.selectedItem.Count = Int32.Parse(newfield7);
            Item.selectedItem.Price = Double.Parse(newfield8);
            list.list[index] = Item.selectedItem;
            using (FileStream stream = new FileStream("book.xml", FileMode.Create))
            {
                serializer.Serialize(stream, list);
            } 
            bd1.EditSneacker(index);
            ListViewItems.MyListViewSneakers.ItemsSource = list.list;
            ListViewItems.sneakers = list.list;  
            ListViewItems editer = new ListViewItems();
            editer.NameAdmin.Text = ListViewItems.userlog;
            editer.Show();
            this.Close();

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
