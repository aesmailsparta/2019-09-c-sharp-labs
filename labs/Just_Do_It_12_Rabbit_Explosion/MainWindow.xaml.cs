using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Windows.Threading;

namespace Just_Do_It_12_Rabbit_Explosion
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public DispatcherTimer s = new DispatcherTimer();
        public Queue<Image> images = new Queue<Image>();
        private List<Rabbit> rabbits = new List<Rabbit>();
        private TextBox updateNameText;
        private TextBox updateAgeText;
        private TextBlock updateValidation;
        private int timerSecondsToPause = 0;
        private string rabbitsList = "";
        private int currentRabbitID = -1;

        public MainWindow()
        {
            InitializeComponent();
            
            //Get and Display DB Data
            rabbits = updateRabbitList();
            RefreshData(RabbitsListBox);
            RefreshData(DisplayRabbit);

            //Disable List Buttons (Rabbit Controls)
            SetRabbitListControlsState(false);

            //Set up timer and bind to stop function
            s.Interval = TimeSpan.FromMilliseconds(1000);
            s.Tick += stopTimer;
        }

        private void NewRabbit_Click(object sender, RoutedEventArgs e)
        {
            ClearDisplay();
            int n = -1; //Set default age integer to an invalid value

            string Name = rName.Text;
            string Age = rAge.Text;
           
            bool isNumber = int.TryParse(Age, out n);

            TextBlock RabbitMessage = AddNewGridTextBlock(1, 0, 1, 2);

            if (Name.Length < 1)//Check if name entry is empty
            {
                RabbitMessage.Text = $"Oops looks like you didnt enter a name.";
            }
            else if (n < 0 || !isNumber)//Check if age is a valid value
            {
                RabbitMessage.Text = $"Oops looks you entered an invalid age";
            }
            else
            {
                
                Image rImage = createRabbit();
                images.Enqueue(rImage);
                newRabbit.IsEnabled = false;//Disable button whilst rabbit is being created

                addRabbitToDataBase(Name, Age);
                rabbits = updateRabbitList();

                rName.Text = "";
                rAge.Text = "";
                RefreshData(RabbitsListBox);
                RefreshData(DisplayRabbit);

                s.Start();
                RabbitMessage.Text = $"Hi my name is {Name}";
                //DisplayRabbit.Text = $"{Name} was born, Age {Age}";
            }
        }

        private void stopTimer(object sender, EventArgs e)
        {
            if (timerSecondsToPause > 0)
            {
                timerSecondsToPause--;
            }
            else
            {
                s.Stop();
                //Image rImage = images.Dequeue();
                ////mainCanvas.Children.Remove(rImage);
                //ImageGrid.Children.Remove(rImage);
                newRabbit.IsEnabled = true;
                ClearDisplay();
            }
        }

        public Image createRabbit()
        {
            Random r = new Random();
            Image BodyImage = new Image
            {
                Width = r.Next(50, 200),
                Height = r.Next(50, 200),
                Name = "myRabbit",
                Source = new BitmapImage(new Uri(@"C:/2019-09-c-sharp-labs/labs/lab_16_wpf_rabbit_explosion/media/rabbit.png", UriKind.RelativeOrAbsolute)),
            };

            //mainCanvas.Children.Add(BodyImage);
            ImageGrid.Children.Add(BodyImage);
            BodyImage.HorizontalAlignment = HorizontalAlignment.Center;
            BodyImage.VerticalAlignment = VerticalAlignment.Bottom;
            Grid.SetRow(BodyImage, 0);
            Grid.SetColumn(BodyImage, 0);
            Grid.SetColumnSpan(BodyImage, 2);
            //Canvas.SetTop(BodyImage, 100 - (BodyImage.ActualHeight/2));
            //Canvas.SetLeft(BodyImage, 325 - (BodyImage.ActualWidth / 2));

            return BodyImage;
        }

        //static string printRabbits(List<Rabbit> rabbits)
        //{
        //    string rabbitsList = $"{"ID",-5}" + $"{"Name",-12}{"Age"}\n";
        //    rabbits.ForEach(rabbit => rabbitsList += $"{rabbit.RabbitId,-5}" +
        //                    $"{rabbit.Name,-12}{rabbit.Age}\n");
        //    return rabbitsList;
        //}

        static List<Rabbit> updateRabbitList()
        {
            using (var db = new RabbitDbEntities())
            {
                return db.Rabbits.ToList();
            }
        }

        public void addRabbitToDataBase(string Name, string Age)
        {
            var newRabbit = new Rabbit()
            {
                Age = int.Parse(Age),
                Name = Name
            };

            using (var db = new RabbitDbEntities())
            {

                db.Rabbits.Add(newRabbit);
                db.SaveChanges();

            }
        }

        private void RefreshData(TextBlock container)
        {
            string rabbitsList = $"{"ID",-5}" + $"{"Name",-12}{"Age"}\n";
            rabbits.ForEach(rabbit => rabbitsList += $"{rabbit.RabbitId,-5}" +
                            $"{rabbit.Name,-12}{rabbit.Age}\n");
            container.Text = rabbitsList;
        }

        private void RefreshData(ListBox container)
        {
            container.ItemsSource = rabbits;
        }

        private void BtnDeleteSelection_Click(object sender, RoutedEventArgs e)
        {
            if (RabbitsListBox.SelectedIndex > -1) {

                int ID = rabbits[RabbitsListBox.SelectedIndex].RabbitId;

                using (var db = new RabbitDbEntities())
                {

                    db.Rabbits.Remove(db.Rabbits.Single(a => a.RabbitId == ID));
                    db.SaveChanges();

                }

                if(currentRabbitID == ID)
                {
                    ClearDisplay();
                }

                rabbits = updateRabbitList();

                RefreshData(RabbitsListBox);
                RefreshData(DisplayRabbit);
            }
        }

        private void RabbitsListBox_GotFocus(object sender, RoutedEventArgs e)
        {
            //Enable Rabbits Controls
            SetRabbitListControlsState(true);
        }

        private void RabbitsListBox_LostFocus(object sender, RoutedEventArgs e)
        {
            //Disable Rabbits Controls
            SetRabbitListControlsState(false);
        }

        private void SetRabbitListControlsState(bool state)
        {
           // btnShowSelectedItem.IsEnabled = state;
            btnDeleteSelection.IsEnabled = state;
            btnUpdateSelectedRabbit.IsEnabled = state;
        }

        private void BtnSelectAll_Click(object sender, RoutedEventArgs e)
        {

            RabbitsListBox.SelectionMode = SelectionMode.Extended;

            foreach (object obj in RabbitsListBox.Items)
            {
                RabbitsListBox.SelectedItems.Add(obj);
            }

        }

        private void BtnSelectNewestRabbit_Click(object sender, RoutedEventArgs e)
        {
            //Select last rabbit added
            RabbitsListBox.SelectedItem = RabbitsListBox.Items[RabbitsListBox.Items.Count - 1];
            RabbitsListBox.ScrollIntoView(RabbitsListBox.SelectedItem);
        }

        private void BtnShowSelectedItem_Click(object sender, RoutedEventArgs e)
        {
            if (RabbitsListBox.SelectedIndex > -1)
            {
                Rabbit foundRabbit = null;

                using (var db = new RabbitDbEntities())
                {
                    int ID = rabbits[RabbitsListBox.SelectedIndex].RabbitId;

                    //var selectedRabbit = new Rabbit
                    //{
                    //    RabbitId = ID
                    //};

                    foundRabbit = db.Rabbits.Find(ID);

                    //db.Rabbits.Where(b => b.RabbitId == ID)
                    // .First();
                }

                if (foundRabbit != null)
                {
                    showRabbit(foundRabbit);
                    currentRabbitID = foundRabbit.RabbitId;
                }
                else
                {
                    ClearDisplay();
                    AddNewGridTextBlock(0, 1, 1, 2,"Rabbit could not be found");
                }
            }
        }

        private void showRabbit(Rabbit rabbitToShow)
        {
            ClearDisplay();
            Random r = new Random();
            Image BodyImage = new Image
            {
                Width = r.Next(50, 200),
                Height = r.Next(50, 200),
                Name = "myRabbit",
                Source = new BitmapImage(new Uri(@"C:/2019-09-c-sharp-labs/labs/lab_16_wpf_rabbit_explosion/media/rabbit.png", UriKind.RelativeOrAbsolute)),
            };

            //mainCanvas.Children.Add(BodyImage);
            ImageGrid.Children.Add(BodyImage);
            BodyImage.HorizontalAlignment = HorizontalAlignment.Center;
            BodyImage.VerticalAlignment = VerticalAlignment.Bottom;
            Grid.SetRow(BodyImage, 0);
            Grid.SetColumn(BodyImage, 0);
            Grid.SetColumnSpan(BodyImage, 2);
            //Canvas.SetTop(BodyImage, 100 - (BodyImage.ActualHeight/2));
            //Canvas.SetLeft(BodyImage, 325 - (BodyImage.ActualWidth / 2));
            TextBlock RabbitName = AddNewGridTextBlock(1, 0, 1, 2, $"Hi, My name is {rabbitToShow.Name}, I am {rabbitToShow.Age} years old");

            //ImageGrid.Children.Add(RabbitName);
            //ImageGrid.Children.Add(RabbitAge);

            //RabbitName.Text = rabbitToShow.Name;
            //RabbitAge.Text = $"{rabbitToShow.Age} years";

            images.Enqueue(BodyImage);
        }

        private TextBlock AddNewGridTextBlock(int row, int col, int rowSpan, int colSpan, string messageContent = "")
        {
            TextBlock RabbitMessage = new TextBlock
            {
                Text = messageContent,
                TextAlignment = TextAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top,
                TextWrapping = TextWrapping.Wrap,
                Margin = new Thickness(0,5,0,0),
                Height = 25
            };

            Grid.SetRow(RabbitMessage, row);
            Grid.SetColumn(RabbitMessage, col);
            Grid.SetColumnSpan(RabbitMessage, colSpan);
            Grid.SetRowSpan(RabbitMessage, rowSpan);

            ImageGrid.Children.Add(RabbitMessage);

            return RabbitMessage;
        }

        private TextBox AddNewGridTextBox(int row, int col, int rowSpan, int colSpan, string messageContent = "")
        {
            TextBox RabbitMessage = new TextBox
            {
                Text = messageContent,
                TextAlignment = TextAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top,
                TextWrapping = TextWrapping.Wrap,
                Height = 25,
                Width = 100
            };

            Grid.SetRow(RabbitMessage, row);
            Grid.SetColumn(RabbitMessage, col);
            Grid.SetColumnSpan(RabbitMessage, colSpan);
            Grid.SetRowSpan(RabbitMessage, rowSpan);

            ImageGrid.Children.Add(RabbitMessage);

            return RabbitMessage;
        }


        private Label AddNewGridLabel(int row, int col, int rowSpan, int colSpan, string content = "")
        {
            Label label = new Label
            {
                Content = content,
                Height = 25,
                Width = 100
            };

            Grid.SetRow(label, row);
            Grid.SetColumn(label, col);
            Grid.SetColumnSpan(label, colSpan);
            Grid.SetRowSpan(label, rowSpan);

            ImageGrid.Children.Add(label);

            return label;
        }

        private void ClearDisplay()
        {
            images.Clear();
            ImageGrid.Children.Clear();
            currentRabbitID = -1;
        }

        private void RabbitsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RabbitsListBox.SelectedIndex > -1)
            {
                Rabbit foundRabbit = null;

                using (var db = new RabbitDbEntities())
                {
                    int ID = rabbits[RabbitsListBox.SelectedIndex].RabbitId;

                    //var selectedRabbit = new Rabbit
                    //{
                    //    RabbitId = ID
                    //};

                    foundRabbit = db.Rabbits.Find(ID);

                    //db.Rabbits.Where(b => b.RabbitId == ID)
                    // .First();
                }

                if (foundRabbit != null)
                {
                    showRabbit(foundRabbit);
                    currentRabbitID = foundRabbit.RabbitId;
                }
                else
                {
                    ClearDisplay();
                    AddNewGridTextBlock(0, 1, 1, 2, "Rabbit could not be found");
                }
            }

        }

        private void BtnUpdateSelectedRabbit_Click(object sender, RoutedEventArgs e)
        {
            ClearDisplay();
            Rabbit selectedRabbit = rabbits[RabbitsListBox.SelectedIndex];
            currentRabbitID = selectedRabbit.RabbitId;
            Label nameLabel = AddNewGridLabel(0, 0, 1, 1, "Name: ");
            Label ageLabel = AddNewGridLabel(0, 0, 1, 1, "Age: ");
            updateNameText = AddNewGridTextBox(0, 1, 1, 1, selectedRabbit.Name);
            updateAgeText = AddNewGridTextBox(0, 1, 1, 1, selectedRabbit.Age.ToString());

            updateNameText.Name = "updateName";
            updateAgeText.Name = "updateAge";

            updateNameText.VerticalAlignment = VerticalAlignment.Bottom;
            updateAgeText.VerticalAlignment = VerticalAlignment.Bottom;
            updateNameText.HorizontalAlignment = HorizontalAlignment.Left;
            updateAgeText.HorizontalAlignment = HorizontalAlignment.Left;

            nameLabel.VerticalAlignment = VerticalAlignment.Bottom;
            ageLabel.VerticalAlignment = VerticalAlignment.Bottom;
            nameLabel.HorizontalAlignment = HorizontalAlignment.Right;
            ageLabel.HorizontalAlignment = HorizontalAlignment.Right;

            Button UpdateRabbit = new Button
            {
                Content = "UPDATE",
                VerticalAlignment = VerticalAlignment.Bottom,
                HorizontalAlignment = HorizontalAlignment.Center,
                Height = 25,
                Width = 200
            };

            Grid.SetRow(UpdateRabbit, 0);
            Grid.SetColumn(UpdateRabbit, 0);
            Grid.SetColumnSpan(UpdateRabbit, 2);

            UpdateRabbit.Click += UpdateRabbit_Click;

            ImageGrid.Children.Add(UpdateRabbit);

            updateNameText.Margin = new Thickness(0, 0, 0, 60);
            nameLabel.Margin = new Thickness(0, 0, 0, 60);
            updateAgeText.Margin = new Thickness(0, 0, 0, 30);
            ageLabel.Margin = new Thickness(0, 0, 0, 30);
        }

        private void UpdateRabbit_Click(object sender, RoutedEventArgs e)
        {
            //Update Rabbit
            int n = -1; //Set default age integer to an invalid value

            int ID = currentRabbitID;
            string Name = updateNameText.Text;
            string Age = updateAgeText.Text;

            bool isNumber = int.TryParse(Age, out n);

            if (updateValidation == null) {
                updateValidation = AddNewGridTextBlock(1, 0, 1, 2);
            }

            if (Name.Length < 1)//Check if name entry is empty
            {
                updateValidation.Text = $"Oops looks like you didnt enter a name.";
            }
            else if (n < 0 || !isNumber)//Check if age is a valid value
            {
                updateValidation.Text = $"Oops looks you entered an invalid age";
            }
            else
            {

                updateRabbitDataBase(ID, Name, Age);
                rabbits = updateRabbitList();

                RefreshData(RabbitsListBox);
                RefreshData(DisplayRabbit);

                updateValidation.Text = $"{Name} was successfully updated";
                //DisplayRabbit.Text = $"{Name} was born, Age {Age}";
            }
        }

        private void updateRabbitDataBase(int ID, string name, string age)
        {
            //update rabbit
            using (var db = new RabbitDbEntities())
            {
                Rabbit rabbitUpdate = db.Rabbits.Single(a => a.RabbitId == ID);

                if (rabbitUpdate != null) {
                    rabbitUpdate.Name = name;
                    rabbitUpdate.Age = int.Parse(age);
                    db.SaveChanges();
                }

            }
        }
    }

}
