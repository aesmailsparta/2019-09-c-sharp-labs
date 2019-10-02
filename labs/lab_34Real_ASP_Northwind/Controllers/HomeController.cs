using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab_34Real_ASP_Northwind.Controllers
{
    public class HomeController : Controller
    {

        public static List<Customer> customers;
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult AnotherPage()
        {
            ViewBag.Title = "Another Page";

            return View();
        }

        public ActionResult FinalPage()
        {
            ViewBag.OtherData = "Here is something else to show";

            ViewBag.MyList = new List<string>() { "one", "two", "three" };

            return View();
        }

        public ActionResult Customers()
        {
            using (var db = new NorthwindEntities())
            {
                customers = db.Customers.ToList();
            }

            ViewBag.CustomersList = customers;

            return View();
        }
    }
}
