using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using lab_47_NET_API;
using lab_47_NET_API.Models;

namespace lab_47_NET_API.Controllers
{
    public class ProductsController : ApiController
    {
        private readonly NorthwindEntities db = new NorthwindEntities();
        static List<Products> products = new List<Products>();

        // GET: api/Products
        public IQueryable<Product> GetProducts()
        {
            //List<string> pnames = new List<string>();
            foreach (var item in db.Products.ToList())
            {
                Products p = new Products
                {
                    ProductID = item.ProductID,
                    ProductName = item.ProductName,
                    SupplierID = item.SupplierID,
                    CategoryID = item.CategoryID,
                    QuantityPerUnit = item.QuantityPerUnit,
                    UnitPrice = item.UnitPrice,
                    UnitsInStock = item.UnitsInStock,
                    UnitsOnOrder = item.UnitsOnOrder,
                    ReorderLevel = item.ReorderLevel,
                    Discontinued = item.Discontinued
                };

                products.Add(p);

            }

            return db.Products;
        }

        // GET: api/Products/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult GetProduct(int id)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // PUT: api/Products/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduct(int id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.ProductID)
            {
                return BadRequest();
            }

            db.Entry(product).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Products
        [ResponseType(typeof(Product))]
        public IHttpActionResult PostProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Products.Add(product);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = product.ProductID }, product);
        }

        // DELETE: api/Products/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult DeleteProduct(int id)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            db.Products.Remove(product);
            db.SaveChanges();

            return Ok(product);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(int id)
        {
            return db.Products.Count(e => e.ProductID == id) > 0;
        }
    }
}