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

namespace lab_18_Rabbit_Database_CRUD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        static List<Rabbit> rabbits;
        static Rabbit rabbit = new Rabbit();

        public MainWindow()
        {
            InitializeComponent();
            initialise();
        }

        void initialise()
        {

            //auto clean up
            using (var db = new RabbitDbEntities())
            {
                rabbits = db.Rabbits.ToList();
            }

            //  Manual METHOD
            //  rabbits.ForEach(rabbit => ListBoxRabbits.Items.Add(rabbit));

            //BINDING METHOD : BIND LISTBOX TO DATABASE
            //ListBoxRabbits.DisplayMemberPath = "Name";
            ListBoxRabbits.ItemsSource = rabbits;

            //ReadOnly TextBoxes
            TextBoxName.IsReadOnly = true;
            TextBoxAge.IsReadOnly = true;

            //Disable Edit and Delete
            ButtonEdit.IsEnabled = false;
            ButtonDelete.IsEnabled = false;
        }

        private void ListBoxRabbits_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBoxRabbits.SelectedItem != null)
            {
                rabbit = (Rabbit)ListBoxRabbits.SelectedItem;
                //MessageBox.Show(rabbit.Name);

                TextBoxName.Text = rabbit.Name;
                TextBoxAge.Text = rabbit.Age.ToString();

                ButtonEdit.IsEnabled = true;
                ButtonDelete.IsEnabled = true;
            }
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Hey, We are adding");
            if (ButtonAdd.Content.Equals("Add"))
            {
                ButtonAdd.Style = (Style)FindResource("red");
                ButtonAdd.Content = "Save";
                //ButtonEdit.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F6C8B8"));

                //ButtonEdit.Style = Resources["btnImportant"] as Style;

                TextBoxName.Text = "";
                TextBoxAge.Text = "";

                TextBoxName.IsReadOnly = false;
                TextBoxAge.IsReadOnly = false;

                ButtonEdit.IsEnabled = false;
                ButtonDelete.IsEnabled = false;
            }
            else
            {
                ButtonAdd.Content = "Add";
                ButtonAdd.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#CFE8DC"));
                ButtonEdit.Style = (Style)FindResource("general");
                //ButtonEdit.Style = Resources["btnRegular"] as Style;

                TextBoxName.IsReadOnly = true;
                TextBoxAge.IsReadOnly = true;

                if ((TextBoxAge.Text.Length > 0) && (TextBoxName.Text.Length > 0))
                {
                    if (rabbit != null)
                    {
                        rabbit.Name = TextBoxName.Text;
                        if (int.TryParse(TextBoxAge.Text, out int age))
                        {
                            rabbit.Age = age;
                        }

                        using (var db = new RabbitDbEntities())
                        {
                            Rabbit rabbitToAdd = new Rabbit {
                                Name = rabbit.Name,
                                Age = rabbit.Age
                            };

                            db.Rabbits.Add(rabbitToAdd);
                            db.SaveChanges();

                            ListBoxRabbits.ItemsSource = null;
                            ListBoxRabbits.Items.Clear();

                            rabbits = db.Rabbits.ToList();
                            ListBoxRabbits.ItemsSource = rabbits;

                        }


                    }
                }
            }
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Hey, We are editing");
            if(ButtonEdit.Content.Equals("Edit"))
            {
                ButtonEdit.Content = "Save";
                //ButtonEdit.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F6C8B8"));
                //Style style = (Style)Resources["btn"];
                ButtonEdit.Style = (Style)FindResource("red");
                //ButtonEdit.Style = FindResource("red") as Style;

                TextBoxName.IsReadOnly = false;
                TextBoxAge.IsReadOnly = false;

                ButtonAdd.IsEnabled = false;
            }
            else
            {
                ButtonEdit.Content = "Edit";
                ButtonEdit.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#CFE8DC"));
                ButtonEdit.Style = (Style)FindResource("general");
                //ButtonEdit.Style = Resources["btnRegular"] as Style;

                TextBoxName.IsReadOnly = true;
                TextBoxAge.IsReadOnly = true;

                if ((TextBoxAge.Text.Length > 0) && (TextBoxName.Text.Length > 0))
                {
                    if (rabbit != null)
                    {
                        rabbit.Name = TextBoxName.Text;
                        if(int.TryParse(TextBoxAge.Text, out int age))
                        {
                            rabbit.Age = age;
                        }

                        using (var db = new RabbitDbEntities())
                        {

                            Rabbit rabbitToUpdate = db.Rabbits.Find(rabbit.RabbitId);
                            rabbitToUpdate.Name = rabbit.Name;
                            rabbitToUpdate.Age = rabbit.Age;
                            db.SaveChanges();

                            ListBoxRabbits.ItemsSource = null;
                            ListBoxRabbits.Items.Clear();

                            rabbits = db.Rabbits.ToList();
                            ListBoxRabbits.ItemsSource = rabbits;

                        }

                    }
                }

                ButtonAdd.IsEnabled = true;
            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Hey, We are deleting");
            if (ButtonDelete.Content.Equals("Delete"))
            {
                ButtonDelete.Style = (Style)FindResource("red");
                ButtonDelete.Content = "Confirm Delete";
                //ButtonEdit.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F6C8B8"));

                //ButtonEdit.Style = Resources["btnImportant"] as Style;
                ButtonAdd.IsEnabled = false;
            }
            else
            {
                ButtonDelete.Content = "Delete";
                ButtonDelete.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#CFE8DC"));
                ButtonEdit.Style = (Style)FindResource("general");
                //ButtonEdit.Style = Resources["btnRegular"] as Style;


                using (var db = new RabbitDbEntities())
                {
                    if (rabbit != null)
                    {
                        //var rtodel = db.Rabbits.Find(rabbit.RabbitId);
                        //db.Rabbits.Remove(rtodel);
                        db.Rabbits.Remove(db.Rabbits.Single(a => a.RabbitId == rabbit.RabbitId));
                        //db.Rabbits.Remove(rabbit);
                        db.SaveChanges();

                        TextBoxName.Text = "";
                        TextBoxAge.Text = "";

                        ListBoxRabbits.ItemsSource = null;
                        ListBoxRabbits.Items.Clear();

                        rabbits = db.Rabbits.ToList();
                        ListBoxRabbits.ItemsSource = rabbits;
                    }
                }

                ButtonDelete.IsEnabled = false;
                ButtonAdd.IsEnabled = true;
            }
        }
    }
}
