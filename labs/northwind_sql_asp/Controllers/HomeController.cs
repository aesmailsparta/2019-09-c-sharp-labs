using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace northwind_sql_asp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult One_One()
        {
            using(var db = new NorthwindEntities())
            {
                var customers = db.Customers.Where(c => c.City.ToLower() == "paris" || c.City.ToLower() == "london").ToList();
                ViewBag.qOneCustomers = customers;
                
            }

            return View();
        }    
        
        public ActionResult One_Two()
        {
            using(var db = new NorthwindEntities())
            {
                var products = db.Products.Where(p => p.QuantityPerUnit.Contains("bottle")).ToList();
                ViewBag.qTwoProducts = products;
            }

            return View();
        }

        public ActionResult One_Three()
        {
            //using (var db = new NorthwindEntities())
            //{
            //    var products = db.Products.Where(p => p.QuantityPerUnit.Contains("bottle")).ToList();
            //    ViewBag.qThreeProducts = products;
            //}
            //using (var db = new NorthwindEntities())
            //{

            //    var products = db.Products.Join(
            //        db.Suppliers, p => p.SupplierID, s => s.SupplierID,
            //        (p, s) => new { p, s }
            //        ).Where(p => p.p.QuantityPerUnit.Contains("bottle")).Select(z => new {z.p,z.s}).ToList();
            //    ViewBag.q = products;
            //}

            using (var db = new NorthwindEntities())
            {

                var products = (from p in db.Products
                                where p.QuantityPerUnit.Contains("bottle")
                                join s in db.Suppliers on p.SupplierID equals s.SupplierID
                                select new { p.ProductID, p.ProductName, p.UnitsInStock, p.UnitPrice, s.CompanyName, s.Country }).ToList();

                ViewBag.q = products;

            }

            return View();
        }
    }
}