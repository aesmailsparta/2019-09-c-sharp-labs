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

namespace do_it_wpf_rabbits
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            initialise();
            //Image simpleImage = new Image();
            //simpleImage.Width = 200;
            //simpleImage.Margin = new Thickness(5);

            //BitmapImage bi = new BitmapImage();

            //bi.BeginInit();
            //bi.UriSource = new Uri(@"C:/2019-09-c-sharp-labs/labs/lab_16_wpf_rabbit_explosion/media/rabbit02.jpg", UriKind.RelativeOrAbsolute);
            //bi.EndInit();

            //simpleImage.Source = bi;
            //Canvas.
            //Canvas.Children.Add(simpleImage);

            
        }

        public initialise()
        {
            var rabbitGrower = new RabbitsGrowth(mainCanvas);

           // rabbitGrower.Exp
        }

        public void createRabbit()
        {
            Random r = new Random();
            Image BodyImage = new Image
            {
                Width = 200,
                Height = 200,
                Name = "myRabbit",
                Source = new BitmapImage(new Uri(@"C:/2019-09-c-sharp-labs/labs/lab_16_wpf_rabbit_explosion/media/rabbit02.jpg", UriKind.RelativeOrAbsolute)),
            };

            mainCanvas.Children.Add(BodyImage);
            Canvas.SetTop(BodyImage,r.Next(800));
            Canvas.SetLeft(BodyImage,r.Next(1200));
        }

        private void CreateRabbit_Click(object sender, RoutedEventArgs e)
        {
            createRabbit();
        }
    }

    public class RabbitsGrowth
    {
        static List<Rabbit> Rabbits = new List<Rabbit>();
        public Canvas canvas;

        public RabbitsGrowth(Canvas canvas)
        {
            this.canvas = canvas;
        }

        public static (int years, int population) ExponentialGrowth(int maxPopulation)
        {

           // string LogFile = "Log.txt";
            //var s = new Stopwatch();
            int proCreationAge = 3;

            int count = 0;

            int iterationCount = 0;
            //s.Start();
            while (Rabbits.Count < maxPopulation)
            {
                if (count == 0)
                {
                    Rabbits.Add(SpawnRabbit(count));
                    count++;
                }
                else
                {
                    int cycles = Rabbits.Count;
                    for (int i = 0; i < cycles; i++)
                    {
                        Rabbits[i].Age++;

                        if (Rabbits[i].Age >= proCreationAge)
                        {
                            if (Rabbits.Count < maxPopulation)
                            {
                                Rabbit r = SpawnRabbit(count);
                                Rabbits.Add(r);
                                //File.WriteAllText(LogFile, $"New Rabbit Called {r.Name}, Born at {DateTime.Now} {Environment.NewLine}");
                                count++;
                            }
                            else
                            {
                                Console.WriteLine("LIMIT HAS BEEN REACHED");
                                //s.Stop();
                                break;
                            }
                        }

                    }
                }


                iterationCount += (maxPopulation != Rabbits.Count) ? 1 : 0;

            }

            //foreach (Rabbit r in Rabbits)
            //{
            //    Console.WriteLine($"Name: {r.Name}, Age: {r.Age}");
            //}


            //Console.WriteLine(File.ReadAllText(LogFile));


            //Console.WriteLine($"{iterationCount} Iterations Taken \n\n");
            //Console.WriteLine($"Total time elapsed: {s.ElapsedMilliseconds}ms");

            return (iterationCount, Rabbits.Count);
        }

        static Rabbit SpawnRabbit(int count)
        {
            var rabbit = new Rabbit($"Rabbit{count:D2}", 0);
            return rabbit;
        }

        public void createRabbit()
        {
            Random r = new Random();
            Image BodyImage = new Image
            {
                Width = 200,
                Height = 200,
                Name = "myRabbit",
                Source = new BitmapImage(new Uri(@"C:/2019-09-c-sharp-labs/labs/lab_16_wpf_rabbit_explosion/media/rabbit02.jpg", UriKind.RelativeOrAbsolute)),
            };

            this.canvas.Children.Add(BodyImage);
            Canvas.SetTop(BodyImage, r.Next(400));
            Canvas.SetLeft(BodyImage, r.Next(700));
        }
    }

    class Rabbit
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Rabbit(string Name, int Age)
        {
            this.Name = Name;
            this.Age = Age;
        }

    }
}
