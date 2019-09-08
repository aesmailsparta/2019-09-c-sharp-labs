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
using System.Diagnostics;
using System.Windows.Threading;

namespace lab_16_wpf_rabbit_explosion
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public Random r = new Random();
        public DispatcherTimer s = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            initialise();

            Image simpleImage = new Image();
            simpleImage.Width = 200;
            simpleImage.Margin = new Thickness(5);

            BitmapImage bi = new BitmapImage();

            bi.BeginInit();
            bi.UriSource = new Uri(@"C:/2019-09-c-sharp-labs/labs/lab_16_wpf_rabbit_explosion/media/rabbit02.jpg", UriKind.RelativeOrAbsolute);
            bi.EndInit();

            simpleImage.Source = bi;
            Grid.SetColumn(simpleImage, 2);
            Grid.SetRow(simpleImage, 1);
            GridMain.Children.Add(simpleImage);

            //MediaElement newRabbit = new MediaElement();
            //GridMain.Children.Add(newRabbit);
            //newRabbit.HorizontalAlignment = HorizontalAlignment.Left;
            //newRabbit.VerticalAlignment = VerticalAlignment.Top;
            //newRabbit.Height = 1080;
            //newRabbit.Width = 1920;
            //newRabbit.Source = new Uri("/media/rabbit.png", UriKind.Relative);

            //newRabbit.LoadedBehavior = MediaState.Manual;

        }

        void initialise()
        {
            Button01.Content = "Click Here";
            s.Interval = TimeSpan.FromSeconds(1);
            s.Tick += change_color;
            s.Start();

           // rabbit.Source = ImageSource;
        }

        static int counter = 0;

        private void Button01_Click(object sender, RoutedEventArgs e)
        {
            //s.Start();
            //Color color = new Color();
            //color.B = (byte)r.Next(0, 255);
            //color.G = (byte)r.Next(0, 255);
            //color.B = (byte)r.Next(0, 255);

            //counter++;
            //Button01.Content = $"{counter} Times";

            //Label01.Background = new SolidColorBrush(Color.FromRgb((byte)r.Next(0, 255), (byte)r.Next(0, 255), (byte)r.Next(0, 255)));

            rabbit.Visibility = (rabbit.Visibility == Visibility.Visible) ? Visibility.Hidden : Visibility.Visible;
        }

        void change_color(object sender, EventArgs e)
        {
            Label01.Background = new SolidColorBrush(Color.FromRgb((byte)r.Next(0, 255), (byte)r.Next(0, 255), (byte)r.Next(0, 255)));
        }
    }
}
