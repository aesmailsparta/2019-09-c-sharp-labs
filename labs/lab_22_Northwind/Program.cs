using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_22_Northwind
{
    class Program
    {
        static List<Product> products;
        static List<Category> categories;
        static void Main(string[] args)
        {
            using(var db = new NorthwindEntities())
            {
                products = db.Products.ToList();
                categories = db.Categories.ToList();
            }

            Console.WriteLine("\n**********************PRODUCTS***********************\n");
            Console.WriteLine($"{"ProductID",-10} {"ProductName",-35} {"UnitsInStock",-15} {"QuantityPerUnit"}");

            products.ForEach(p =>
            {
                Console.WriteLine($"{p.ProductID,-10} {p.ProductName,-35} {p.UnitsInStock,-15} {p.QuantityPerUnit}");
            });

            Console.ReadLine();

            Console.WriteLine("\n**********************CATEGORYS***********************\n");
            Console.WriteLine($"{"CategoryID",-10} {"CategoryName",-35} {"Description"}");

            categories.ForEach(c =>
            {
                Console.WriteLine($"{c.CategoryID,-10} {c.CategoryName,-35} {c.Description}");
            });

            Console.ReadLine();


            Console.WriteLine("\n**********************PRODUCTS WITH CATEGORYS***********************\n");
            Console.WriteLine($"{"ProductID",-10} {"ProductName",-35} {"CategoryName",-20} {"QuantityPerUnit"}");

            products.ForEach(p =>
            {
                Console.WriteLine($"{p.ProductID,-10} {p.ProductName,-35} {p.Category.CategoryName,-20} {p.QuantityPerUnit}");
            });

            Console.ReadLine();


        }
    }
}
