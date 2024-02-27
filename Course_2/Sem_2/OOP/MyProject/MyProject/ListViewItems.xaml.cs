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
using System.IO;
using System.Xml.Serialization;
using System.ComponentModel;

using System.Drawing;
using System.Text.RegularExpressions;


namespace MyProject
{
    /// <summary>
    /// Логика взаимодействия для ListViewItems.xaml
    /// </summary>
    public partial class ListViewItems : Window
    {
        private static int count;
        private static Steps steps = new Steps();
        public static ItemsControl MyListViewSneakers { get; set; }
        public static Item selectedItem;
        public string userName {get; set;}
        public static List<Item> sneakers = new List<Item>()
        {
         //  new Item("Nike" ,"Air Force 1","force.jpg", "Running", 4.5, 43, 20, 300),
         // new Item("Vans", "OLD SKOOL","vans.jpg", "Casual", 3.0, 39, 5, 150),
         //  new Item("CAT","Intruder White","CAT.jpg", "Fashion", 5.0, 36, 8, 220),
         //  new Item("Adidas","Niteball (S24146) ","adidas.jpg", "Basketball", 4.1, 45, 3, 400),
         //  new Item("Puma","Carina Lift","puma.jpg", "Casual", 2.5, 34, 30, 100),
         //new Item("Puma","Future Richer Double","adidas1.jpeg", "Running", 3.5, 42, 100, 50)


        };
        public ListViewItems()
        {
            InitializeComponent();
            NameAdmin.Text = userName;
            this.Cursor = Cursors.Hand;
            XmlSerializer serializer = new XmlSerializer(typeof(Items));
            using (FileStream stream = new FileStream("book.xml", FileMode.Open))
            {
                Items list = (Items)serializer.Deserialize(stream);
                sneakers = list.list;
            }
            var products = GetProducts();  
            Step step = new Step();
            step.list = sneakers;
            steps.steplist.Add(step);
            count = steps.steplist.Count - 1;
            if (products.Count > 0) ListViewSneakers.ItemsSource = products;
          

        }
        private List<Item> GetProducts()
        {

            List<Item> list = new List<Item>();

            if (SearchBox.Text.Length != 0)
            {
                var query = from p in sneakers
                            orderby p.Name
                            select new
                            {
                                Name = p.Name,
                                FullName = p.FullName,
                                Image = p.Image,
                                Category = p.Category,
                                Rate = p.Rate,
                                Size = p.Size,
                                Count = p.Count,
                                Price = p.Price

                            };
                foreach (var item in query)
                {
                    if (item.FullName.ToUpper().IndexOf(SearchBox.Text.ToUpper()) >= 0) { list.Add(new Item(item.Name, item.FullName, item.Image, item.Category, item.Rate, item.Size, item.Count, item.Price)); }
                }
            }
            else list = sneakers;
            return list;
        }
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            Items qproducts = new Items();
            qproducts.list = sneakers;
            XmlSerializer serializer = new XmlSerializer(typeof(Items));
            using (FileStream stream = new FileStream("book.xml", FileMode.Create))
            {
                serializer.Serialize(stream, qproducts);
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UserInfo.Visibility = Visibility.Visible;
            titleitems.Visibility = Visibility.Hidden;
            Add.Visibility = Visibility.Hidden;
            MainWindow Reg = new MainWindow();
            Reg.Show();
            this.Close();
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var products = GetProducts();
            if (products.Count > 0) ListViewSneakers.ItemsSource = products;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SearchBox.Text = "";
            Add.Visibility = Visibility.Visible;
            Scroll.Visibility = Visibility.Visible;
            titleitems.Visibility = Visibility.Visible;
            UserInfo.Visibility = Visibility.Hidden;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Scroll.Visibility = Visibility.Hidden;
            titleitems.Visibility = Visibility.Hidden;
            UserInfo.Visibility = Visibility.Visible;
            Add.Visibility = Visibility.Hidden;
        }
        private void Delete_Account(object sender, RoutedEventArgs e)
        {
            BD bd = new BD();
            bd.DeleteUser();
            MainWindow Reg = new MainWindow();
            Reg.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Scroll.Visibility = Visibility.Hidden;
            titleitems.Visibility = Visibility.Hidden;
            UserInfo.Visibility = Visibility.Hidden;
            Add.Visibility = Visibility.Hidden;
            WindowRout windowRout = new WindowRout();
            windowRout.Show();
            this.Close();
        }
        private void Buy_Click(object sender, RoutedEventArgs e)
        {
            Buying buy = new Buying();
            buy.Show();
            this.Close();
        }

        private void SliderBox_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            PriceBar.Text = SliderBox.Value.ToString();
        }
    

        private void PriceBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<Item> list = new List<Item>();



            var query = from p in sneakers
                        orderby p.Price
                        where p.Price<Double.Parse(PriceBar.Text)
                        select new
                        {
                            Name = p.Name,
                            FullName = p.FullName,
                            Image = p.Image,
                            Category = p.Category,
                            Rate = p.Rate,
                            Size = p.Size,
                            Count = p.Count,
                            Price = p.Price

                        };
            foreach (var item in query)
            {
                
                    list.Add(new Item(item.Name, item.FullName, item.Image, item.Category, item.Rate, item.Size, item.Count, item.Price));
                
            }
            if (list.Count != 0) ListViewSneakers.ItemsSource = list;
        }
    
        private void ComboCat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Item> list = new List<Item>();



            var query = from p in sneakers
                        orderby p.Name
                        select new
                        {
                            Name = p.Name,
                            FullName = p.FullName,
                            Image = p.Image,
                            Category = p.Category,
                            Rate = p.Rate,
                            Size = p.Size,
                            Count = p.Count,
                            Price = p.Price

                        };
            foreach (var item in query)
            {
                if (ComboCat.SelectedItem != null && item.Category == ((ComboBoxItem)ComboCat.SelectedItem).Content.ToString())
                {
                    list.Add(new Item(item.Name, item.FullName, item.Image, item.Category, item.Rate, item.Size, item.Count, item.Price));
                }
            }
            if (list.Count != 0) ListViewSneakers.ItemsSource = list;
        }
        private void AddItem_Click(object sender, RoutedEventArgs e)
        {
            Added added = new Added();
            added.Show();
            this.Close();
        }
        private void DelItem_Click(object sender, RoutedEventArgs e)
        {
            BD bd1 = new BD();
            bd1.DeleteSneacker();
            Items list = new Items();
            XmlSerializer serializer = new XmlSerializer(typeof(Items));
            using (FileStream stream = new FileStream("book.xml", FileMode.Open))
            {
                list = (Items)serializer.Deserialize(stream);
            }

            selectedItem = (sender as Button).DataContext as Item;

            var list1 = ListViewSneakers.ItemsSource as List<Item>;
            // Найти индекс выбранного элемента в списке
            int index = list1.IndexOf(selectedItem);

            // Удалить выбранный элемент из списка
            list.list.RemoveAt(index);

            using (FileStream stream = new FileStream("book.xml", FileMode.Create))
            {
                serializer.Serialize(stream, list);
            }
            ListViewSneakers.ItemsSource = list.list;
            sneakers = list.list;
        }
        private void EditItem_Click(object sender, RoutedEventArgs e)
        {
            Item.selectedItem = (sender as Button).DataContext as Item;
            selectedItem = Item.selectedItem;
            MyListViewSneakers = (ItemsControl)FindName("ListViewSneakers");
            Edit edit = new Edit();
            edit.Show();
            this.Close();
        }
        public void Redo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                count++;
                var items = steps.steplist[count].list;
                ListViewSneakers.ItemsSource = items;
            }
            catch
            {
                int current = steps.steplist.Count - 1;
                var items = steps.steplist[current].list;
                ListViewSneakers.ItemsSource = items;
            }
        }
        public void Undo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                count--;
                var items = steps.steplist[count].list;
                ListViewSneakers.ItemsSource = items;
            }
            catch
            {
                int current = 0;
                var items = steps.steplist[current].list;
                ListViewSneakers.ItemsSource = items;
            }
        }

        public void Update_Account (object sender, RoutedEventArgs e)
        {
            EditUser editUser = new EditUser();
            editUser.Show();
            this.Close();
        }
      

    }
}
