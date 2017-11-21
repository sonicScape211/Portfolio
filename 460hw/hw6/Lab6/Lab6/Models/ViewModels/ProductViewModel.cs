using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab6.Models.ViewModels
{
    public class ProductViewModel
    {
        public IEnumerable<Product> Product { get; set; }
        public IEnumerable<ProductSubcategory> ProductSubcategory { get; set; }
        public IEnumerable<Product> ProductQuery { get; set; }
        public IEnumerable<ProductDescription> ProductDescription { get; set; }
    }
}