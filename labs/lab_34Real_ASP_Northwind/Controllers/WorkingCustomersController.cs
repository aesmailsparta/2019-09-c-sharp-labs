using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace lab_34Real_ASP_Northwind.Controllers
{
    public class WorkingCustomersController : ApiController
    {
        public static List<Customer> customers = new List<Customer>();
        public List<Customer> GetCustomers()
        {
            using (var db = new NorthwindEntities())
            {
                customers = db.Customers.ToList();
            }

            return customers;
        }
    }
}
