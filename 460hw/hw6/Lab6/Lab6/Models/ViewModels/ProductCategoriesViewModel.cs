using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab6.Models.ViewModels
{
    public class ProductCategoriesViewModel
    {
        public IEnumerable<ProductCategory> ProductCategory { get; set; }
        public IEnumerable<ProductSubcategory> ProductSubcategory { get; set; }
        public IEnumerable<ProductSubcategory> BikesSubcategory { get; set; }
        public IEnumerable<ProductSubcategory> ComponentsSubcategory { get; set; }
        public IEnumerable<ProductSubcategory> ClothingSubcategory { get; set; }
        public IEnumerable<ProductSubcategory> AccessoriesSubcategory { get; set; }
    }

}