using System;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Collections.Generic;


namespace lab_38_core
{
    class Program
    {
        static List<Customer> customers = new List<Customer>();
        static void Main(string[] args)
        {
            //RAW SQL CONNECTIONS

            string connectionString = @"Data Source=localhost; Initial Catalog=Northwind; Persist Security Info=True; User ID=SA; Password=Passw0rd2018";


            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine(connection.State);
            }

            string connectionString2 = @"Data Source=(localdb)\mssqllocaldb; Initial Catalog=Northwind;";

            using(var connection2 = new SqlConnection(connectionString2))
            {
                connection2.Open();
                Console.WriteLine(connection2.State);

                string SQLQuery = "SELECT * FROM Customers";

                using(var sqlcommand = new SqlCommand(SQLQuery, connection2))
                {
                    var reader = sqlcommand.ExecuteReader();
                    while (reader.Read())
                    {
                        var CustomerID = reader["CustomerID"].ToString();
                        var ContactName = reader["ContactName"].ToString();
                        var CompanyName = reader["CompanyName"].ToString();
                        var City = reader["City"].ToString();
                        var Country = reader["Country"].ToString();

                        var customer = new Customer(CustomerID, ContactName, CompanyName, City, Country);

                        customers.Add(customer);
                    }
                }

                Console.WriteLine(customers.Count);

                Console.WriteLine($"\n\n{"CustomerID", -15}{"ContactName", -25}{"Company Name", -38}{"City", -16}{"Country", -13}");
                customers.ForEach(c => Console.WriteLine($"{c.CustomerID,-15}{c.ContactName,-25}{c.CompanyName,-38}{c.City,-16}{c.Country,-13}"));
            }
        }
    }

    class Customer
    {

        public Customer(string CustomerID, string ContactName, string CompanyName, string City, string Country)
        {
            this.CustomerID = CustomerID;
            this.ContactName = ContactName;
            this.CompanyName = CompanyName;
            this.City = City;
            this.Country = Country;
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
