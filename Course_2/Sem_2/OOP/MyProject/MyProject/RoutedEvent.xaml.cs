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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyProject
{
    /// <summary>
    /// Логика взаимодействия для RoutedEvent.xaml
    /// </summary>
    public partial class RoutedEvents : UserControl
    {
        public RoutedEvents()
        {
            InitializeComponent();
        }


        private void Bubbling_MouseDown(object sender, MouseButtonEventArgs e)
        {
            BubblingTextBlock.Text += "sender: " + sender.ToString() + "\n";
            BubblingTextBlock.Text += "source: " + e.Source.ToString() + "\n\n";
        }

        private void Tunelling_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TunellingTextBlock.Text += "sender: " + sender.ToString() + "\n";
            TunellingTextBlock.Text += "source: " + e.Source.ToString() + "\n\n";
        }
        private void Direct_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DirectTextBlock.Text += "sender: " + sender.ToString() + "\n";
            DirectTextBlock.Text += "source: " + e.Source.ToString() + "\n\n";
        }

    }
}
