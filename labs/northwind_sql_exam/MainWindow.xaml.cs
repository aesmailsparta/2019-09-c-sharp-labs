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
            //SELECT Region.RegionID, Region.RegionDescription, SUM([Order Details].Quantity * [Order Details].UnitPrice) AS 'Total Sales'
            //FROM Territories
            //INNER JOIN EmployeeTerritories
            //ON Territories.TerritoryID = EmployeeTerritories.TerritoryID
            //INNER JOIN Region
            //ON Region.RegionID = Territories.RegionID
            //INNER JOIN Orders
            //ON EmployeeTerritories.EmployeeID = Orders.EmployeeID
            //INNER JOIN[Order Details]
            //ON Orders.OrderID = [Order Details].OrderID
            //GROUP BY Region.RegionID, Region.RegionDescription
            //HAVING SUM([Order Details].Quantity * [Order Details].UnitPrice) > 1000000;

            using (var connection2 = new SqlConnection(connectionString))
            {
                connection2.Open();

                string SQLQuery = $"SELECT Region.RegionID, Region.RegionDescription, FORMAT(SUM([Order Details].Quantity * [Order Details].UnitPrice), 'C0') AS 'TotalSales'" +
                                    $" FROM Territories" +
                                    $" INNER JOIN EmployeeTerritories" +
                                    $" ON Territories.TerritoryID = EmployeeTerritories.TerritoryID" +
                                    $" INNER JOIN Region" +
                                    $" ON Region.RegionID = Territories.RegionID" +
                                    $" INNER JOIN Orders" +
                                    $" ON EmployeeTerritories.EmployeeID = Orders.EmployeeID" +
                                    $" INNER JOIN[Order Details]" +
                                    $" ON Orders.OrderID = [Order Details].OrderID" +
                                    $" GROUP BY Region.RegionID, Region.RegionDescription" +
                                    $" HAVING SUM([Order Details].Quantity * [Order Details].UnitPrice) > 1000000" +
                                    $" ORDER BY Region.RegionID";

                List<object> regions = new List<object>();

                using (var sqlcommand = new SqlCommand(SQLQuery, connection2))
                {
                    var reader = sqlcommand.ExecuteReader();
                    while (reader.Read())
                    {
                        var RegionID = reader["RegionID"].ToString();
                        var RegionDescription = reader["RegionDescription"].ToString();
                        var TotalSales = reader["TotalSales"].ToString();

                        var region = new
                        {
                            RegionID = RegionID,
                            RegionDescription = RegionDescription,
                            TotalSales = TotalSales
                        };

                        regions.Add(region);
                    }

                    Q6Results.ItemsSource = regions;
                }
            }
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

        private void RunQuery9_Click(object sender, RoutedEventArgs e)
        {
            //SELECT Employees.EmployeeID, CONCAT(Employees.FirstName, ' ', Employees.LastName) AS EmployeeName, CONCAT(Managers.FirstName, ' ', Managers.LastName) AS ReportTo
            //FROM Employees
            //INNER JOIN Employees AS Managers
            //ON Employees.ReportsTo = Managers.EmployeeID
            using (var connection2 = new SqlConnection(connectionString))
            {
                connection2.Open();

                string SQLQuery = $"SELECT Employees.EmployeeID, CONCAT(Employees.FirstName, ' ', Employees.LastName) AS 'EmployeeName', CONCAT(Managers.FirstName, ' ', Managers.LastName) AS 'ReportTo'" +
                                    $" FROM Employees" +
                                    $" JOIN Employees AS Managers" +
                                    $" ON Employees.ReportsTo = Managers.EmployeeID";

                List<object> employees = new List<object>();

                using (var sqlcommand = new SqlCommand(SQLQuery, connection2))
                {
                    var reader = sqlcommand.ExecuteReader();
                    while (reader.Read())
                    {
                        var EmployeeID = reader["EmployeeID"].ToString();
                        var EmployeeName = reader["EmployeeName"].ToString();
                        var ReportTo = reader["ReportTo"].ToString() == null ? "Nobody" : reader["ReportTo"].ToString();

                        var employee = new
                        {
                            EmployeeID = EmployeeID,
                            EmployeeName = EmployeeName,
                            ReportTo = ReportTo
                        };

                        employees.Add(employee);
                    }

                    Q9Results.ItemsSource = employees;
                }
            }
        }

        private void RunQuery10_Click(object sender, RoutedEventArgs e)
        {
            //SELECT Suppliers.SupplierID, Suppliers.CompanyName, FORMAT(SUM([Order Details].Quantity * [Order Details].UnitPrice * (1 -[Order Details].Discount)), 'C0', 'en-gb') AS 'TotalSales(Including Discount)'
            //FROM[Order Details]
            //JOIN Products
            //ON[Order Details].ProductID = Products.ProductID
            //JOIN Suppliers
            //ON Products.SupplierID = Suppliers.SupplierID
            //GROUP BY Suppliers.SupplierID, Suppliers.CompanyName
            //HAVING SUM([Order Details].Quantity * [Order Details].UnitPrice * (1 -[Order Details].Discount)) > 10000

            using (var connection2 = new SqlConnection(connectionString))
            {
                connection2.Open();

                string SQLQuery = $"SELECT Suppliers.SupplierID, Suppliers.CompanyName, FORMAT(SUM([Order Details].Quantity * [Order Details].UnitPrice * (1 -[Order Details].Discount)), 'C0', 'en-gb') AS 'TotalSales(Including Discount)'" +
                                    $" FROM[Order Details]" +
                                    $" JOIN Products" +
                                    $" ON[Order Details].ProductID = Products.ProductID" +
                                    $" JOIN Suppliers" +
                                    $" ON Products.SupplierID = Suppliers.SupplierID" +
                                    $" GROUP BY Suppliers.SupplierID, Suppliers.CompanyName" +
                                    $" HAVING SUM([Order Details].Quantity * [Order Details].UnitPrice * (1 -[Order Details].Discount)) > 10000";

                List<object> suppliers = new List<object>();

                using (var sqlcommand = new SqlCommand(SQLQuery, connection2))
                {
                    var reader = sqlcommand.ExecuteReader();
                    while (reader.Read())
                    {
                        var SupplierID = reader["SupplierID"].ToString();
                        var CompanyName = reader["CompanyName"].ToString();
                        var TotalSales = reader["TotalSales(Including Discount)"].ToString();

                        var supplier = new
                        {
                            SupplierID = SupplierID,
                            CompanyName = CompanyName,
                            TotalSales = TotalSales
                        };

                        suppliers.Add(supplier);
                    }

                    Q10Results.ItemsSource = suppliers;
                }
            }

        }
    }
}
