using System;
using System.Collections.Generic;

#nullable disable

namespace MMTApplication.Models
{
    public partial class Category
    {
        public Category()
        {
            ProductCategories = new HashSet<ProductCategory>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
