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
using System.Data.Sql;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace northwind_sql_exam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        static string connectionString = @"Data Source=(localdb)\mssqllocaldb; Initial Catalog=Northwind;";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RunQuery1_Click(object sender, RoutedEventArgs e)
        {
            using (var connection2 = new SqlConnection(connectionString))
            {
                connection2.Open();

                string SQLQuery =   $"SELECT CustomerID, CompanyName, Address, City, Region, PostalCode, Country" +
                                    $" FROM Customers" +
                                    $" WHERE LOWER(City) = 'paris' OR LOWER(City) = 'london'";

                List<object> customers = new List<object>();

                using (var sqlcommand = new SqlCommand(SQLQuery, connection2))
                {
                    var reader = sqlcommand.ExecuteReader();
                    while (reader.Read())
                    {
                        var CustomerID = reader["CustomerID"].ToString();
                        var CompanyName = reader["CompanyName"].ToString();
                        var Address = reader["Address"].ToString();
                        var City = reader["City"].ToString();
                        var Region = reader["Region"].ToString();
                        var PostalCode = reader["PostalCode"].ToString();
                        var Country = reader["Country"].ToString();

                        var customer = new {
                            CustomerID = CustomerID,
                            CompanyName = CompanyName, 
                            Address = Address, 
                            City = City,
                            Region = Region,
                            PostalCode = PostalCode, 
                            Country = Country
                        };

                        customers.Add(customer);
                    }

                    Q1Results.ItemsSource = customers;
                }
            }
        }

        private void RunQuery2_Click(object sender, RoutedEventArgs e)
        {
            using (var connection2 = new SqlConnection(connectionString))
            {
                connection2.Open();

                string SQLQuery = $"SELECT *" +
                                    $" FROM Products" +
                                    $" WHERE QuantityPerUnit LIKE '%bottle%'";

                List<object> products = new List<object>();

                using (var sqlcommand = new SqlCommand(SQLQuery, connection2))
                {
                    var reader = sqlcommand.ExecuteReader();
                    while (reader.Read())
                    {
                        var ProductID = reader["ProductID"].ToString();
                        var ProductName = reader["ProductName"].ToString();
                        var QuantityPerUnit = reader["QuantityPerUnit"].ToString();
                        var UnitPrice = reader["UnitPrice"].ToString();
                        var UnitsInStock = reader["UnitsInStock"].ToString();

                        var product = new
                        {
                            ProductID = ProductID,
                            ProductName = ProductName,
                            QuantityPerUnit = QuantityPerUnit,
                            UnitPrice = UnitPrice,
                            UnitsInStock = UnitsInStock
                        };

                        products.Add(product);
                    }

                    Q2Results.ItemsSource = products;
                }
            }
        }

        private void RunQuery3_Click(object sender, RoutedEventArgs e)
        {
            //SELECT Products.*, Suppliers.CompanyName, Suppliers.Country
            //FROM Products
            //JOIN Suppliers
            //ON Products.SupplierID = Suppliers.SupplierID
            //WHERE QuantityPerUnit LIKE '%bottle%' 
            using (var connection2 = new SqlConnection(connectionString))
            {
                connection2.Open();

                string SQLQuery = $"SELECT Products.*, Suppliers.CompanyName, Suppliers.Country" +
                                    $" FROM Products" +
                                    $" JOIN Suppliers" +
                                    $" ON Products.SupplierID = Suppliers.SupplierID" +
                                    $" WHERE QuantityPerUnit LIKE '%bottle%'";

                List<object> products = new List<object>();

                using (var sqlcommand = new SqlCommand(SQLQuery, connection2))
                {
                    var reader = sqlcommand.ExecuteReader();
                    while (reader.Read())
                    {
                        var ProductID = reader["ProductID"].ToString();
                        var ProductName = reader["ProductName"].ToString();
                        var QuantityPerUnit = reader["QuantityPerUnit"].ToString();
                        var UnitPrice = reader["UnitPrice"].ToString();
                        var UnitsInStock = reader["UnitsInStock"].ToString();
                        var CompanyName = reader["CompanyName"].ToString();
                        var Country = reader["Country"].ToString();

                        var product = new
                        {
                            ProductID = ProductID,
                            ProductName = ProductName,
                            QuantityPerUnit = QuantityPerUnit,
                            UnitPrice = UnitPrice,
                            UnitsInStock = UnitsInStock,
                            CompanyName = CompanyName,
                            Country = Country
                        };

                        products.Add(product);
                    }

                    Q3Results.ItemsSource = products;
                }
            }
        }

        private void RunQuery4_Click(object sender, RoutedEventArgs e)
        {
            //SELECT Categories.CategoryName, COUNT(Categories.CategoryName) AS 'Number Of Products'
            //FROM Products
            //JOIN Categories
            //ON Products.CategoryID = Categories.CategoryID
            //GROUP BY Categories.CategoryName
            //ORDER BY[Number Of Products] DESC

            using (var connection2 = new SqlConnection(connectionString))
            {
                connection2.Open();

                string SQLQuery = $"SELECT Categories.CategoryName, COUNT(Categories.CategoryName) AS 'Number Of Products'" +
                                    $" FROM Products" +
                                    $" JOIN Categories" +
                                    $" ON Products.CategoryID = Categories.CategoryID" +
                                    $" GROUP BY Categories.CategoryName" +
                                    $" ORDER BY[Number Of Products] DESC";

                List<object> categories = new List<object>();

                using (var sqlcommand = new SqlCommand(SQLQuery, connection2))
                {
                    var reader = sqlcommand.ExecuteReader();
                    while (reader.Read())
                    {
                        var CategoryName = reader["CategoryName"].ToString();
                        var NumberOfProducts = reader["Number Of Products"].ToString();

                        var category = new
                        {
                            CategoryName = CategoryName,
                            NumberOfProducts = NumberOfProducts
                        };

                        categories.Add(category);
                    }

                    Q4Results.ItemsSource = categories;
                }
            }
        }

        private void RunQuery5_Click(object sender, RoutedEventArgs e)
        {

            //SELECT CONCAT(ContactTitle, ' ', ContactName) AS fullname, City
            //FROM Customers
            //WHERE Country = 'UK';
            using (var connection2 = new SqlConnection(connectionString))
            {
                connection2.Open();

                string SQLQuery = $"SELECT CONCAT(ContactTitle, ' ', ContactName) AS FullName, City" +
                                    $" FROM Customers" +
                                    $" WHERE Country = 'UK'";

                List<object> customers = new List<object>();

                using (var sqlcommand = new SqlCommand(SQLQuery, connection2))
                {
                    var reader = sqlcommand.ExecuteReader();
                    while (reader.Read())
                    {
                        var FullName = reader["FullName"].ToString();
                        var City = reader["City"].ToString();

                        var customer = new
                        {
                            FullName = FullName,
                            City = City
                        };

                        customers.Add(customer);
                    }

                    Q5Results.ItemsSource = customers;
                }
            }
        }

        private void RunQuery6_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RunQuery7_Click(object sender, RoutedEventArgs e)
        {

            //SELECT COUNT(*) FROM Orders
            //WHERE Freight > 100 AND(ShipCountry = 'USA' OR ShipCountry = 'UK');
            using (var connection2 = new SqlConnection(connectionString))
            {
                connection2.Open();

                string SQLQuery = $"SELECT COUNT(*) AS OrderCount" +
                                    $" FROM Orders" +
                                    $" WHERE Freight > 100 AND(ShipCountry = 'USA' OR ShipCountry = 'UK')";

                using (var sqlcommand = new SqlCommand(SQLQuery, connection2))
                {
                    var reader = sqlcommand.ExecuteReader();
                    while (reader.Read())
                    {
                        var OrderCount = reader["OrderCount"].ToString();
                        Q7Results.Content = OrderCount;
                    }

                }
            }
        }

        private void RunQuery8_Click(object sender, RoutedEventArgs e)
        {
            //SELECT TOP 1 OrderID, Discount, ((UnitPrice * Quantity) * Discount) AS 'DiscountApplied' FROM[Order Details]
            //ORDER BY 'DiscountApplied' DESC, Discount DESC
            using (var connection2 = new SqlConnection(connectionString))
            {
                connection2.Open();

                string SQLQuery = $"SELECT TOP 1 OrderID, (Discount * 100) AS DiscountPercentage, ((UnitPrice * Quantity) * Discount) AS 'DiscountApplied' " +
                                    $" FROM[Order Details]" +
                                    $" ORDER BY 'DiscountApplied' DESC, Discount DESC";

                using (var sqlcommand = new SqlCommand(SQLQuery, connection2))
                {
                    var reader = sqlcommand.ExecuteReader();
                    while (reader.Read())
                    {
                        var OrderID = reader["OrderID"].ToString();
                        var DiscountPercentage = reader["DiscountPercentage"].ToString();
                        var DiscountApplied = reader["DiscountApplied"].ToString();
                        Q8Results.Content = "Order ID: " + OrderID;
                        Q8Discount.Content = "Discount: " + DiscountPercentage + "%";
                        Q8DiscountAmount.Content = "Discount Amount: " + DiscountApplied;
                    }

                }
            }

        }

        private void NavHomeButton_Click(object sender, RoutedEventArgs e)
        {
            Q1.IsSelected = true;
            //SELECT TOP 1 OrderID, Discount, ((UnitPrice * Quantity) * Discount) AS 'DiscountApplied' FROM[Order Details]
            //ORDER BY 'DiscountApplied' DESC, Discount DESC

        }
    }
}
