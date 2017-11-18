using Lab6.Models;
using Lab6.Models.ViewModels;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab6.Controllers
{
    public class HomeController : Controller
    {
        private AdventureWorksContext db = new AdventureWorksContext();

        public ActionResult Index()
        {
            //Create the new viewModel containing both the Cat and SubCat tables.
            ProductCategoriesViewModel viewModel = new ProductCategoriesViewModel();
            //set the fields in the viewModel class to reflect that of the db tables.
           
            
            //Pass in the product categories as a list when the page is created.
            return View(createViewModel(viewModel));
            //return View(db.ProductCategories.ToList());
        }

        [HttpPost]
        public ActionResult Index(string subCategoryButton)
        {
            ProductCategoriesViewModel viewModel = new ProductCategoriesViewModel();

            Debug.Print(subCategoryButton);
            //This will need to be specific to the passed value, not toList of all. TODO.
            return View(createViewModel(viewModel));//db.ProductSubcategories.ToList());
        }

        public ProductCategoriesViewModel createViewModel(ProductCategoriesViewModel viewModel)
        {

            viewModel.ProductCategory = db.ProductCategories.ToList();
            viewModel.ProductSubcategory = db.ProductSubcategories.ToList();
            viewModel.BikesSubcategory = db.ProductSubcategories.Where(c => c.ProductCategory.Name == "Bikes").ToList();
            viewModel.ComponentsSubcategory = db.ProductSubcategories.Where(c => c.ProductCategory.Name == "Components").ToList();
            viewModel.ClothingSubcategory = db.ProductSubcategories.Where(c => c.ProductCategory.Name == "Clothing").ToList();
            viewModel.AccessoriesSubcategory = db.ProductSubcategories.Where(c => c.ProductCategory.Name == "Accessories").ToList();


            return viewModel;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}