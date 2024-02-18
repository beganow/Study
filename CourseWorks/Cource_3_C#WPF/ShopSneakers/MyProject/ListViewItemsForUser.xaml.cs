using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xml.Serialization;

namespace MyProject
{
    /// <summary>
    /// Логика взаимодействия для ListViewItemsForUser.xaml
    /// </summary>
    public partial class ListViewItemsForUser : Window
    {
        int i = 1;
        public int status;
        public static string login;
        public static int id_s;
        public static ItemsControl MyListViewSneakers { get; set; }
        public static Item selectedItem;
        public static string userlog;
        private DispatcherTimer timer;
        public string userName { get; set; }
        public static List<Item> sneakers = new List<Item>()
        {
            //  new Item("Nike" ,"Air Force 1","force.jpg", "Running", 4.5, 43, 20, 300),
            // new Item("Vans", "OLD SKOOL","vans.jpg", "Casual", 3.0, 39, 5, 150),
            //  new Item("CAT","Intruder White","CAT.jpg", "Fashion", 5.0, 36, 8, 220),
            //  new Item("Adidas","Niteball (S24146) ","adidas.jpg", "Basketball", 4.1, 45, 3, 400),
            //  new Item("Puma","Carina Lift","puma.jpg", "Casual", 2.5, 34, 30, 100),
            //new Item("Puma","Future Richer Double","adidas1.jpeg", "Running", 3.5, 42, 100, 50)


        };
        public static List<Item> fil = new List<Item>();
        public ListViewItemsForUser()
        {
            InitializeComponent();
            this.Cursor = Cursors.Hand;
            XmlSerializer serializer = new XmlSerializer(typeof(Items));
            using (FileStream stream = new FileStream("book.xml", FileMode.Open))
            {
                Items list = (Items)serializer.Deserialize(stream);
                sneakers = list.list;
            }
            var products = GetProducts();
            if (products.Count > 0) ListViewSneakers.ItemsSource = products;
            Scroll.Visibility = Visibility.Hidden;
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(5);
            timer.Tick += Timer_Tick;
            timer.Start();
         
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
                    fil = list;
                }
            }
            else { list = sneakers;
            fil = sneakers;
            }
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
            Scroll.Visibility = Visibility.Visible;
            titleitems.Visibility = Visibility.Visible;
            BorderDataGrid.Visibility = Visibility.Collapsed;
            DataButton.Visibility = Visibility.Collapsed;
            PicHolder.Visibility = Visibility.Collapsed;
            leftHolder.Visibility = Visibility.Collapsed;
            rigthHolder.Visibility = Visibility.Collapsed;

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Scroll.Visibility = Visibility.Hidden;
            titleitems.Visibility = Visibility.Hidden;
            BorderDataGrid.Visibility = Visibility.Collapsed;
            DataButton.Visibility = Visibility.Collapsed;
            PicHolder.Visibility = Visibility.Visible;
            leftHolder.Visibility = Visibility.Visible;
            rigthHolder.Visibility = Visibility.Visible;

        }
        private void Delete_Account(object sender, RoutedEventArgs e)
        {
            BD bd = new BD();
            userlog = NameAdmin.Text;
            bd.DeleteUser();
            
            MainWindow Reg = new MainWindow();
            Reg.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Scroll.Visibility = Visibility.Hidden;
            titleitems.Visibility = Visibility.Hidden;
            BorderDataGrid.Visibility = Visibility.Collapsed;
            DataButton.Visibility = Visibility.Collapsed;
            PicHolder.Visibility = Visibility.Collapsed;
            leftHolder.Visibility = Visibility.Collapsed;
            rigthHolder.Visibility = Visibility.Collapsed;
            this.Close();
        }
        private void Buy_Click(object sender, RoutedEventArgs e)
        {
            userlog = NameAdmin.Text;
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
            id_s = index;
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
                        where p.Price < Double.Parse(PriceBar.Text)
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
            ComboCat.SelectedItem = ComboCat.Items.Cast<ComboBoxItem>().FirstOrDefault(item => item.Name == "All");
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
                if (item.Category == ((ComboBoxItem)ComboCat.SelectedItem).Content.ToString())
                {
                    list.Add(new Item(item.Name, item.FullName, item.Image, item.Category, item.Rate, item.Size, item.Count, item.Price));
                }
                else if (((ComboBoxItem)ComboCat.SelectedItem).Name == "All")
                {
                    ListViewSneakers.ItemsSource = sneakers;
                    return;
                }
            }
            ListViewSneakers.ItemsSource = list;
        }
        public void Update_Account(object sender, RoutedEventArgs e)
        {
            userlog = NameAdmin.Text;
            EditUser editUser = new EditUser();
            editUser.Show();
            this.Close();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
          BD bd1 = new BD();
           bd1.UpdateDate();
            ListOrders list = new ListOrders();
            string username = NameAdmin.Text;
            list.LoadDataFromDatabaseUser(username);
            Scroll.Visibility = Visibility.Collapsed;
            BorderDataGrid.Visibility = Visibility.Visible;
            DataButton.Visibility = Visibility.Visible;
            dataGrid.ItemsSource = list;
            PicHolder.Visibility = Visibility.Collapsed;
            leftHolder.Visibility = Visibility.Collapsed;
            rigthHolder.Visibility = Visibility.Collapsed;
        }
        private void GoBack(object sender, RoutedEventArgs e)
        {
            i--;
            if (i < 1)
            {
                i = 5;
            }
            PicHolder.Source = new BitmapImage(new Uri(@"Slider/" + i + ".jpg", UriKind.Relative));
        }
        private void GoNext(object sender, RoutedEventArgs e)
        {
            i++;
            if (i > 5)
            {
                i = 1;
            }
            PicHolder.Source = new BitmapImage(new Uri(@"Slider/" + i + ".jpg", UriKind.Relative));
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            i++;
            if (i > 5)
            {
                i = 1;
            }
            PicHolder.Source = new BitmapImage(new Uri(@"Slider/" + i + ".jpg", UriKind.Relative));
        }
    }
}
