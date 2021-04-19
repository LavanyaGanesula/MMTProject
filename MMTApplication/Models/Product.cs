using System;
using System.Collections.Generic;

#nullable disable

namespace MMTApplication.Models
{
    public class Product
    {
        public Product()
        {
            ProductCategories = new HashSet<ProductCategory>();
        }

        public long Id { get; set; }
        public string SKU { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
