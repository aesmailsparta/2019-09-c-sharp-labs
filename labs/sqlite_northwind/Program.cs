using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace sqlite_northwind
{
    class Program
    {
        static List<dynamic> customers = new List<dynamic>();
        static void Main(string[] args)
        {
            var connectionString = @"data source=C:\SQLite\Northwind.db;version=3;New=True;Compress=True;";

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new SQLiteCommand("SELECT * FROM Customers", conn))
                {
                    using (var coreReader = cmd.ExecuteReader())
                    {

                        while (coreReader.Read())
                        {
                            var CustomerID = coreReader["CustomerID"].ToString();
                            var ContactName = coreReader["ContactName"].ToString();
                            var CompanyName = coreReader["CompanyName"].ToString();
                            var City = coreReader["City"].ToString();

                           // var customer = new Customer(CustomerID, ContactName, CompanyName, City);

                            var customer = new
                            {
                                CustomerID = CustomerID,
                                ContactName = ContactName,
                                CompanyName = CompanyName,
                                City = City
                            };

                            customers.Add(customer);
                        }
                    }
                }
                customers.ForEach(c => Console.WriteLine($"{c.CustomerID,-10}{c.ContactName,-30}{c.CompanyName,-25}{c.City}"));
            }

            Console.ReadLine();
        }
    }

    class Customer
    {

        public Customer(string CustomerID, string ContactName, string CompanyName, string City)
        {
            this.CustomerID = CustomerID;
            this.ContactName = ContactName;
            this.CompanyName = CompanyName;
            this.City = City;
        }

        public string CustomerID { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
    }
}
