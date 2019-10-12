using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Net.NetworkInformation;
using System.Text;
using System.Web;
using System.Net.Http;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;

namespace lab_46_read_api
{
    class Program
    {

        static string URL = "https://localhost:44317/api/products";
        static List<Product> products = new List<Product>();
        static void Main(string[] args)
        {
            Console.WriteLine($"Is the local network live: {System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable()}");
            Console.WriteLine($"Is connect to the internet {IsNetworkLive()}");

            GetAPIDataAsync().Wait();
        }

        public static bool IsNetworkLive()
        {
            var pingGoogle = new Ping();
            var pingOptions = new PingOptions();
            pingOptions.DontFragment = true;
            string data = "abcdefghijklomnopqrstuvwxyz";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            var timeout = 120;

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"Loop {i}");
                var reply = pingGoogle.Send("8.8.8.8", timeout, buffer, pingOptions);
                if (reply.Status == IPStatus.Success)
                {
                    return true;
                }
            }

            return false;
            //return System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
        }

        public static async Task GetAPIDataAsync()
        {
            using (var client = new HttpClient())
            {
                var s = new Stopwatch();
                s.Start();
                var JSONString = await client.GetStringAsync(URL);
                products = JsonConvert.DeserializeObject<List<Product>>(JSONString);
                s.Stop();
                Console.WriteLine($"API Call took {s.ElapsedMilliseconds}ms");
                printProducts();
            }
        }

        public static void printProducts()
        {
            products.ForEach(p => Console.WriteLine($"{p.ProductName, - 5} {p.ProductName}"));
        }
    }
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        public Category()
        {
            this.Products = new List<Product>();
        }
    }

    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int? CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; } = 0;
        public short? UnitsInStock { get; set; } = 0;
        public short? UnitsOnOrder { get; set; } = 0;
        public short? ReorderLevel { get; set; } = 0;
        public bool Discontinued { get; set; } = false;
    }
}
