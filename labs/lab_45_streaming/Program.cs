using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
using System.IO;
using System.Net;

namespace lab_45_streaming
{
    class Program
    {
        static List<Customer> customers = new List<Customer>();
        static List<Customer> customersForXML = new List<Customer>();
        static void Main(string[] args)
        {
            var customer01 = new Customer
            {
                CustomerID = "ALFKI",
                ContactName = "Fred",
                CompanyName = "Sparta",
                City = "Berlin"
            };
            var customer02 = new Customer
            {
                CustomerID = "BOB22",
                ContactName = "Bob",
                CompanyName = "Sparta",
                City = "Paris"
            };
            var customer03 = new Customer
            {
                CustomerID = "ELFTE",
                ContactName = "Elly",
                CompanyName = "Sparta",
                City = "London"
            };

            customers.Add(customer01);
            customers.Add(customer02);
            customers.Add(customer03);

            string filename = "data.xml";
            //LIST
            //SERIALISE TO XML, JSON, BINARY
            var formatter = new SoapFormatter();
            //SAVE TO FILE
            using (var stream = new FileStream(filename, FileMode.Create, FileAccess.Write))
            {
                formatter.Serialize(stream, customers);
            }
            Console.WriteLine(File.ReadAllText(filename));
            //REVERSE PROCESS ==> Stream back and Deserialize data
            //using (var reader = File.OpenRead(filename))
            //{
            //    //Deserialize to list
            //    customersForXML = formatter.Deserialize(reader) as List<Customer>;
            //}

            var getHTMLData = WebRequest.Create("https://raw.githubusercontent.com/philanderson888/data/master/Customers.xml");
            getHTMLData.Proxy = null;

            using(var webresponse = getHTMLData.GetResponse())
            {
                using(var webstream = webresponse.GetResponseStream())
                {
                    //Get web stream above now new strea for local fs processing
                    using (var filestream = File.Create("CustomersFromWeb.xml"))
                    {
                        webstream.CopyTo(filestream);
                    }
                }
            }

            using (var reader = File.OpenRead("CustomersFromWeb.xml"))
            {
                //Deserialize to list
                customersForXML = formatter.Deserialize(reader) as List<Customer>;
            }

            customersForXML.ForEach(c => Console.WriteLine($"{c.CustomerID, -10} {c.ContactName, -20} {c.CompanyName, -20} {c.City}"));
        
            //Repeat simulate streaming from the internet

        
        }
    }

    [Serializable]
    class Customer
    {
        [NonSerialized]
        private string NINO;
        public string CustomerID { get; set; }

        public string ContactName { get; set; }

        public string CompanyName { get; set; }

        public string City { get; set; }

        public Customer()
        {
            this.NINO = "ABCD";
        }
    }
}
