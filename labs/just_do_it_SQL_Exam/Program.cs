using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;

namespace just_do_it_SQL_Exam
{
    class Program
    {
        static List<Customer> customers = new List<Customer>();
        static void Main(string[] args)
        {
            using (var dbc = new NorthwindModel())
            {
                //--SELECT CustomerID, CompanyName, Address, City, Region, PostalCode, Country
                //--FROM Customers
                //--WHERE LOWER(City) = 'paris' OR LOWER(City) = 'london'
                customers = dbc.Customers.Where(c => c.City.ToLower().Contains("paris") || c.City.ToLower().Contains("london")).ToList();

            }

            customers.ForEach(c => Console.WriteLine($"{c.CustomerID, -10} {c.ContactName}"));
        }
    }
}
