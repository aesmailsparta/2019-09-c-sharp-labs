using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace lab_34Real_ASP_Northwind.Controllers
{
    public class CustomerNameController : ApiController
    {
        public static List<string> customerNames = new List<string>();
        public List<string> GetCustomerNames()
        {
            using(var db = new NorthwindEntities())
            {
                var customers = db.Customers.ToList();
                foreach(var c in customers)
                {
                    customerNames.Add(c.ContactName);
                }
            }

            return customerNames;
        }
    }
}
