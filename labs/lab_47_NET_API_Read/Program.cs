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
using System.Net.Http.Headers;

namespace lab_47_NET_API_Read
{
    class Program
    {

        static string URL = "https://localhost:44361/api/products";
        static string URLPost = "https://localhost:44361/";
        public static List<Product> products = new List<Product>();
        static void Main(string[] args)
        {
            //Console.WriteLine($"Is the local network live: {System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable()}");
           // Console.WriteLine($"Is connect to the internet {IsNetworkLive()}");

            //GetAPIDataAsync().Wait();

            Console.ReadLine();
            CreateProductAsync().Wait();
            // Console.ReadLine();

            // GetAPIDataAsync().Wait();
            //Console.ReadLine();

            Product updateProduct = new Product()
            {
                UnitsOnOrder = 200
            };

            EditProductAsync(2092).Wait();

            DeleteProductAsync(2090).Wait();
            Console.ReadLine();

            GetAPIDataAsync().Wait();
            Console.ReadLine();
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

        public static async Task DeleteProductAsync(int productid)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(URLPost);
                client.DefaultRequestHeaders.Accept.Clear();

                HttpResponseMessage response = await client.DeleteAsync($"/api/products/{productid}");
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Product Deleted");
                }
                else
                {
                    Console.WriteLine($"Failed to delete data");
                }
            }
        }
        
        public static async Task CreateProductAsync()
        {
            using (var client = new HttpClient())
            {
                var product = new Product
                {
                    ProductName = "MyNewProducts",
                    QuantityPerUnit = "12x Bottles",
                    UnitsInStock = 240
                };

                client.BaseAddress = new Uri(URLPost);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var content = new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync("/api/products", content);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Data posted");
                }
                else
                {
                    Console.WriteLine($"Failed to poste data. Status code:{response.StatusCode}");
                }
            }
        }
        
        public static async Task EditProductAsync(int productID)
        {
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(URLPost);

                var JSONString = await client.GetStringAsync($"/api/products/{productID}");
                var productObj = JsonConvert.DeserializeObject<Product>(JSONString);

                productObj.ProductName = "UpdatedProduct";

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var content = new StringContent(JsonConvert.SerializeObject(productObj), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PutAsync($"/api/products/{productID}", content);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Data updated");
                }
                else
                {
                    Console.WriteLine($"Failed to update data. Status code:{response.StatusCode}");
                }
            }
        }

        public static void printProducts()
        {
            products.ForEach(p => Console.WriteLine($"{p.ProductID,-5} {p.ProductName}"));
        }
    }

    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int? CategoryID { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; } = 0;
        public short? UnitsInStock { get; set; } = 0;
        public short? UnitsOnOrder { get; set; } = 0;
        public short? ReorderLevel { get; set; } = 0;
        public bool Discontinued { get; set; } = false;
    }
}
