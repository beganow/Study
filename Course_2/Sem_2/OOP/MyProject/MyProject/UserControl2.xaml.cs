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
    /// Логика взаимодействия для UserControl2.xaml
    /// </summary>
   public partial class UserControl2 : UserControl
{
    public static readonly DependencyProperty SliderValueProperty =
        DependencyProperty.Register("SliderValue", typeof(double), typeof(UserControl2), new PropertyMetadata(0.0, OnSliderValueChanged));

    public double SliderValue
    {
        get { return (double)GetValue(SliderValueProperty); }
        set { SetValue(SliderValueProperty, value); }
    }

    private List<Color> Colors;

    public UserControl2()
    {
        InitializeComponent();
        DataContext = this;

        Colors = new List<Color>()
        {
            System.Windows.Media.Colors.Red,
            System.Windows.Media.Colors.Orange,
            System.Windows.Media.Colors.Yellow,
            System.Windows.Media.Colors.Green,
            System.Windows.Media.Colors.Blue,
            System.Windows.Media.Colors.Indigo,
            System.Windows.Media.Colors.Violet,
            System.Windows.Media.Colors.Purple,
            System.Windows.Media.Colors.Pink,
            System.Windows.Media.Colors.Magenta
        };
    }

    private static void OnSliderValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        UserControl2 userControl = (UserControl2)d;
        double value = (double)e.NewValue;
        int colorIndex = (int)Math.Floor(value / 10); // Определяем индекс цвета на основе значения ползунка
        if (colorIndex < 0 || colorIndex >= userControl.Colors.Count)
            return;

        Color color = userControl.Colors[colorIndex]; // Получаем цвет по индексу
        userControl.Background = new SolidColorBrush(color);
    }
}
}
