using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab6.Models.ViewModels
{
    public class ProductDetailsViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<ProductCategory> ProductCategory { get; set; }
        public IEnumerable<ProductSubcategory> ProductSubcategory { get; set; }
        public IEnumerable<ProductPhoto> ProductPhoto { get; set; }
        public IEnumerable<ProductDescription> ProductDescription { get; set; }
        public IEnumerable<ProductReview> ProductReview { get; set; }

    }
}