using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab_46_api.Models
{
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

}
