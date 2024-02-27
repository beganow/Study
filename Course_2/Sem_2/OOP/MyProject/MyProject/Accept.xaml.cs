using MyProject;
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
    /// Логика взаимодействия для Accept.xaml
    /// </summary>
    public partial class Accept : Window
    {
        public Accept()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ListViewItems listViewItem = new ListViewItems();
            listViewItem.Show();
            this.Close();
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            BD bd1 = new BD();
            bd1.AddSneacker();
            Items list = new Items();
            XmlSerializer serializer = new XmlSerializer(typeof(Items));
            using (FileStream stream = new FileStream("book.xml", FileMode.Open))
            {
                list = (Items)serializer.Deserialize(stream);
            }
            list.list.Add(new Item(Added.newfield1, Added.newfield2, Added.newfield3, Added.selectedValue, Double.Parse(Added.newfield5), Int32.Parse(Added.newfield6), Int32.Parse(Added.newfield7), Double.Parse(Added.newfield8)));
            using (FileStream stream = new FileStream("book.xml", FileMode.Create))
            {
                serializer.Serialize(stream, list);
            }
            ListViewItems listViewItem = new ListViewItems();
            listViewItem.Show();
            this.Close();
        }
    }
}
public partial class Added
{
}
