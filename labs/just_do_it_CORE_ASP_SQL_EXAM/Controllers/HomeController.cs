using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using just_do_it_CORE_ASP_SQL_EXAM.Models;

namespace just_do_it_CORE_ASP_SQL_EXAM.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Northwind01()
        {
            using (var dbc = new NorthwindModel())
            {
                //--SELECT CustomerID, CompanyName, Address, City, Region, PostalCode, Country
                //--FROM Customers
                //--WHERE LOWER(City) = 'paris' OR LOWER(City) = 'london'
                var customers = dbc.Customers.Where(c => c.City.ToLower().Contains("paris") || c.City.ToLower().Contains("london")).ToList();

                ViewBag.Customers = customers;
            }

            return View();
        }
    }
}
