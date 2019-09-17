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

namespace lab_28_ListView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<Rabbit> rabbits;
        public MainWindow()
        {
            InitializeComponent();
            Initialise();

        }

        void Initialise()
        {
            using(var db = new RabbitDbEntities())
            {
                rabbits = db.Rabbits.ToList();

                RabbitsList.ItemsSource = rabbits;
            }
        }
    }
}
