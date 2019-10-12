using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using lab_46_api.Models;
using System.Web.Mvc;
using System.Net.Http;
using Newtonsoft.Json;

namespace lab_46_use_api_MVC.Controllers
{
    public class ProductsController : Controller
    {

        static List<Product> products = new List<Product>();
        static string URL = "https://localhost:44317/api/products";
        // GET: Products
        public ActionResult Index()
        {
            using (var client = new HttpClient())
            {
                var JSONString = client.GetStringAsync(URL);
                products = JsonConvert.DeserializeObject<List<Product>>(JSONString.Result);
            }

            return View(products);
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            return View();
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Products/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
