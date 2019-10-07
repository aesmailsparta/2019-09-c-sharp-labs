using System;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Collections.Generic;


namespace lab_38_core
{
    class Program
    {
        static List<Customer> customers = new List<Customer>();
        static string connectionString2 = @"Data Source=(localdb)\mssqllocaldb; Initial Catalog=Northwind;";
        static void Main(string[] args)
        {
            //RAW SQL CONNECTIONS

            var secret = Environment.GetEnvironmentVariable("SamsSecretPassword");
            connectionString2 = @$"Data Source=localhost; Initial Catalog=Northwind; Persist Security Info=True; User ID=SA; Password={secret}";

            string connectionString = @"Data Source=localhost; Initial Catalog=Northwind; Persist Security Info=True; User ID=SA; Password=Passw0rd2018";


            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine(connection.State);
            }

            InsertCustomer();
            UpdateCustomer();
            DeleteCustomer();
            GetCustomers();
        }

        static void GetCustomers()
        {
            Console.WriteLine($"\n***********************\nRETRIEVING ALL CUSTOMERS\n***********************\n");

            using (var connection2 = new SqlConnection(connectionString2))
            {
                connection2.Open();
                Console.WriteLine(connection2.State);

                string SQLQuery = "SELECT * FROM Customers ORDER BY CompanyName";

                using (var sqlcommand = new SqlCommand(SQLQuery, connection2))
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


                Console.WriteLine($"\n\n{"CustomerID",-15}{"ContactName",-25}{"Company Name",-38}{"City",-16}{"Country",-13}");
                customers.ForEach(c => Console.WriteLine($"{c.CustomerID,-15}{c.ContactName,-25}{c.CompanyName,-38}{c.City,-16}{c.Country,-13}"));


                Console.WriteLine($"\n{customers.Count} customers found");
            }

        }

        static void InsertCustomer()
        {
            Console.WriteLine($"\n***********************\nINSERTING NEW CUSTOMER\n***********************\n");

            using (var connection2 = new SqlConnection(connectionString2))
            {
                connection2.Open();
                var randomCustomerID = GenerateRandomID();
                var customer = new Customer(randomCustomerID, "Melony Long", "Sykes LTD", "London", "UK");

                string SQLQuery = "INSERT INTO Customers (CustomerID, ContactName, CompanyName, City, Country)" +
                    $" VALUES('{customer.CustomerID}','{customer.ContactName}','{customer.CompanyName}','{customer.City}','{customer.Country}')";

                using (var sqlcommand = new SqlCommand(SQLQuery, connection2))
                {
                    var affected = sqlcommand.ExecuteNonQuery();
                    Console.WriteLine($"{affected} rows inserted");
                }


                randomCustomerID = GenerateRandomID();
                var sqlquery02 = "INSERT INTO Customers (CustomerID, ContactName, CompanyName, City, Country)" +
                    $" VALUES(@CustomerID,@ContactName,@CompanyName,@City, @Country)";
                using (var insertWithParameters = new SqlCommand(sqlquery02, connection2))
                {
                    insertWithParameters.Parameters.AddWithValue("@CustomerID", randomCustomerID);
                    insertWithParameters.Parameters.AddWithValue("@ContactName", "Melony Long");
                    insertWithParameters.Parameters.AddWithValue("@CompanyName", "Sykes LLC");
                    insertWithParameters.Parameters.AddWithValue("@City", "London");
                    insertWithParameters.Parameters.AddWithValue("@Country", "UK");
                    var sqlreader = insertWithParameters.ExecuteReader();
                }
            }

        }
        static void UpdateCustomer()
        {
            using (var connection = new SqlConnection(connectionString2))
            {

                connection.Open();

                var customerIDToUpdate = "ALFKI";
                var SQLQuery = $"UPDATE Customers SET City = 'Paris' WHERE CustomerID = '{customerIDToUpdate}'";

                using (var sqlcommand = new SqlCommand(SQLQuery, connection))
                {
                    var affected = sqlcommand.ExecuteReader();
                    Console.WriteLine($"Number of records updated: {affected}");
                }
            }

        }

        static void DeleteCustomer()
        {
            using (var connection = new SqlConnection(connectionString2))
            {
                connection.Open();

                var customerIDToUpdate = "BUQRJ";
                var SQLQuery = $"DELETE FROM Customers WHERE CustomerID = '{customerIDToUpdate}' AND EXISTS(SELECT * FROM Customers WHERE CustomerID = '{customerIDToUpdate}')";

                using (var sqlcommand = new SqlCommand(SQLQuery, connection))
                {
                    var affected = sqlcommand.ExecuteReader();
                    Console.WriteLine($"Number of records deleted: {affected}");
                }
            }
        }

        static string GenerateRandomID()
            {
                bool duplicate = true;
                string ID = "";
                Random r = new Random();

                while (duplicate)
                {
                    string alphabet = "ABCDEFGHIJKLMNOPQRSTUVXYZABCDEFGHIJKLMNOPQRSTUVXYZ";
                    ID = "";

                    for (int i = 0; i < 5; i++)
                    {
                        ID += alphabet[r.Next(0, alphabet.Length - 1)];
                    }

                    //Search to check if duplicate key
                    using(var con = new SqlConnection(connectionString2))
                    {
                        con.Open();
                        string SQL = $"SELECT CustomerID FROM Customers WHERE CustomerID = '{ID}' ";

                        using (var sqlcommand = new SqlCommand(SQL, con))
                        {
                            var affected = sqlcommand.ExecuteReader();
                            if(!affected.HasRows)
                            {
                                duplicate = false;
                            }
                        }
                    }
                }

                return ID;
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
