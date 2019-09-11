using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_23_LINQ
{
    class Program
    {
        static List<Customer> customers;
        static List<Order> orders;
        static void Main(string[] args)
        {
            #if DEBUG
                global::System.Console.WriteLine("We Are Debugging");
                System.Threading.Thread.Sleep(2000);
            #endif

            using(var db = new NorthwindEntities())
            {
                customers = db.Customers.ToList();
                orders = db.Orders.ToList();
                db.Order_Details.ToList();
                db.Products.ToList();

                Console.WriteLine($"\n\n\nTRIVIAL LINQ QUERY ALL CUSTOMERS\n\n\n");

                //LINQ simple query
                var output1 =
                    (from customer in db.Customers
                    select customer).ToList();

                PrintCustomers(output1);


                Console.WriteLine($"\n\n\nLINQ WHERE CITY IS LONDON OR BERLIN\n\n\n");

                var LINQwhere =
                    from customer in db.Customers
                    where customer.City == "London" || customer.City == "Berlin"
                    select customer;


                PrintCustomers(LINQwhere.ToList());


                Console.WriteLine($"\n\n\nLINQ ORDER BY CUSTOMER NAME\n\n\n");

                var LINQorderBy =
                    (from customer in db.Customers
                    where customer.City == "London"
                    orderby customer.ContactName descending
                    select customer);


                PrintCustomers(LINQorderBy.ToList());


                Console.WriteLine($"\n\n\nLINQ ORDER BY THEN BY\n\n\n");

                var LINQorderByThenBy =
                    (from customer in db.Customers
                    where customer.City == "London" || customer.City == "Berlin" || customer.City == "Madrid"
                    select customer).OrderByDescending(c => c.City).ThenBy(c => c.ContactName);


                PrintCustomers(LINQorderByThenBy.ToList());

                Console.WriteLine($"\n\n\nA Custom Object\n\n\n");

                var CustomObject =
                    (from customer in db.Customers
                     join co in db.Orders
                     on customer.CustomerID equals co.CustomerID
                     select new {Name = customer.ContactName, co.OrderID, co.OrderDate, co.ShipCity});

                CustomObject.ToList().ForEach(o => Console.WriteLine($"{o.Name, -20} {o.OrderID, -10} {o.OrderDate, -10} {o.ShipCity }"));
                //PrintCustomers(LINQorderByThenBy.ToList());
                //LINQwhere.ToList().ForEach(c => Console.WriteLine($"{c.CustomerID, -10} {c.City}"));


                db.Order_Details.Where(od => od.Order.Customer.City == "Berlin").ToList().ForEach(od => { 

                    Console.WriteLine($"{od.Order.Customer.ContactName,-20} {od.Order.Customer.City,-15} {od.Order.OrderID,-10} {od.Order.OrderDate, -15} {od.Product.ProductName} ");

                });

      

                Console.ReadLine();
            }

            
        }

#region PRINTBLOCK
        static void PrintCustomers(List<Customer> customers)
        {
            customers.ForEach(c => Console.WriteLine($"{c.CustomerID,-10} {c.ContactName, -20} {c.Address}, {c.City}"));
        }
#endregion PRINTBLOCK
    }
}
