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
using System.IO;
using System.Data.SqlClient;

namespace lab_24_Customers_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<StackPanel> panels = new List<StackPanel>();
        static List<Customer> customers = new List<Customer>();
        static List<Order> orders = new List<Order>();
        //static List<Order_Detail> order_details = new List<Order_Detail>();
        int currentStackIndex = 0;
        static Customer selectedCustomer = null;
        static Order currentSelectedOrder = null;
        public MainWindow()
        {
            InitializeComponent();
            Initialise();
        }

        private void Initialise()
        {
            panels.Add(StackPanel01);
            panels.Add(StackPanel02);
            panels.Add(StackPanel03);
            SetNewPanel();

            using(var db = new NorthwindEntities())
            {
                customers = db.Customers.ToList();
                orders = db.Orders.OrderByDescending(o => o.OrderDate).ToList();
                //order_details = db.Order_Details.ToList();

                ListBoxOrders.ItemsSource = orders;
                ListBoxCustomers.ItemsSource = customers;
                //ListBoxOrderDetail.ItemsSource = order_details;
            }
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            if (currentStackIndex > 0)
            {
                currentStackIndex--;
                SetNewPanel();
            }
        }

        private void ButtonForward_Click(object sender, RoutedEventArgs e)
        {
            if (currentStackIndex < panels.Count - 1)
            {
                currentStackIndex++;
                SetNewPanel();
            }
        }

        private void SetNewPanel()
        {
            for(int x = 0; x < panels.Count; x++)
            {
                if(x == currentStackIndex)
                {
                    panels[x].Visibility = Visibility.Visible;
                }
                else
                {
                    panels[x].Visibility = Visibility.Hidden;
                }
            }
        }

        private void CustomerSearch_KeyUp(object sender, KeyEventArgs e)
        {

            ListBoxCustomers.ItemsSource = customers.Where
                (c => c.ContactName.ToLower().Contains(CustomerSearch.Text.ToLower()) && c.City.ToLower().Contains(CitySearch.Text.ToLower())).ToList();

            //using(var db = new NorthwindEntities())
            //{
            //    customers = db.Customers.Where(c => c.ContactName.Contains(CustomerSearch.Text)).ToList();

            //    ListBoxCustomers.ItemsSource = customers;
            //}
        }

        private void CustomerNameFilter_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void CitySearch_KeyUp(object sender, KeyEventArgs e)
        {
            ListBoxCustomers.ItemsSource = customers.Where
               (c => c.ContactName.ToLower().Contains(CustomerSearch.Text.ToLower()) && c.City.ToLower().Contains(CitySearch.Text.ToLower())).ToList();
        }

        private void ListBoxCustomers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedCustomer = (Customer)ListBoxCustomers.SelectedItem;
            if(selectedCustomer != null){
                StackPanel02Label01.Content = $"{selectedCustomer.ContactName} : Previous Orders";

                selectedCustomerName.Text = selectedCustomer.ContactName;
                selectedCustomerContactTitle.Text = selectedCustomer.ContactTitle;
                selectedCustomerCompanyName.Text = selectedCustomer.CompanyName;
            }
            //MessageBox.Show(selectedCustomer.CustomerID);
        }

        private void ListBoxCustomers_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            selectedCustomer = (Customer)ListBoxCustomers.SelectedItem;
            if (selectedCustomer != null)
            {
                ListBoxOrders.ItemsSource = orders.Where
                   (o => o.CustomerID.Equals(selectedCustomer.CustomerID)).ToList();

                selectedCustomerName.Text = selectedCustomer.ContactName;
                selectedCustomerContactTitle.Text = selectedCustomer.ContactTitle;
                selectedCustomerCompanyName.Text = selectedCustomer.CompanyName;

                StackPanel02Label01.Content = $"{selectedCustomer.ContactName} : Previous Orders";
            }
            currentStackIndex = 1;
            SetNewPanel();
        }

        private void OrderIDSearch_KeyUp(object sender, KeyEventArgs e)
        {
            
            if (selectedCustomer == null)
            {
                ListBoxOrders.ItemsSource = orders.Where
                   (o => o.OrderID.ToString().Contains(OrderIDSearch.Text)).ToList();
            }
            else
            {
                ListBoxOrders.ItemsSource = orders.Where
                   (o => o.OrderID.ToString().Contains(OrderIDSearch.Text) && o.CustomerID.Equals(selectedCustomer.CustomerID)).ToList();
            }

        }

        private void ListBoxOrders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentSelectedOrder = (Order)ListBoxOrders.SelectedItem;
            if (currentSelectedOrder != null)
            {
                if (selectedCustomer != null)
                {
                    StackPanel03Label01.Content = $"{selectedCustomer.ContactName} : Order - {currentSelectedOrder.OrderID}";
                }
                else
                {
                    StackPanel03Label01.Content = $"Order - {currentSelectedOrder.OrderID}";
                }
            }
            //MessageBox.Show(currentSelectedOrder.OrderID.ToString());
        }

        private void ListBoxOrders_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            currentSelectedOrder = (Order)ListBoxOrders.SelectedItem;
            if (currentSelectedOrder != null)
            {
                using (var db = new NorthwindEntities()) {

                    ListBoxOrderDetail.ItemsSource = (from od in db.Order_Details
                                  join o in db.Orders
                                  on od.OrderID equals o.OrderID
                                  join p in db.Products
                                  on od.ProductID equals p.ProductID
                                  select new { od.OrderID, p.ProductName, od.UnitPrice, p.UnitsInStock }).Where(
                        od => od.OrderID.Equals(currentSelectedOrder.OrderID)).ToList();

                    
                }
                if (selectedCustomer != null)
                {
                    StackPanel03Label01.Content = $"{selectedCustomer.ContactName} : Order - {currentSelectedOrder.OrderID}";
                }
            }
            currentStackIndex = 2;
            SetNewPanel();
        }

        private void RefreshNorthwind_Click(object sender, RoutedEventArgs e)
        {

            //if (File.Exists(filePath))

            //{

            //    FileInfo file = new FileInfo(filePath);

            //    string script = file.OpenText().ReadToEnd();

            //    using ( SqlConnection conn = new SqlConnection(connectionString))

            //    {

            //        Server server = new Server(new ServerConnection(conn));

            //        ReturnValue = server.ConnectionContext.ExecuteNonQuery(script);

            //    }

            //    file.OpenText().Close();

            //}
        }
    }
}
