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
        ProductViewModel productView = new ProductViewModel();
        public ActionResult Index()
        {
            //Create the new viewModel containing both the Cat and SubCat tables.
            ProductCategoriesViewModel viewModel = new ProductCategoriesViewModel();
            //set the fields in the viewModel class to reflect that of the db tables.
           
            
            //Pass in the product categories as a list when the page is created.
            return View(CreateViewModel(viewModel));
            //return View(db.ProductCategories.ToList());
        }

        [HttpPost]
        public ActionResult ProductsList(string subCategoryButton)
        {
            //ProductViewModel productView = new ProductViewModel();
            productView.Product = db.Products.ToList();
            //Extract the ID from the button name.
            var id = (from ProductSubcategory in db.ProductSubcategories
                      where ProductSubcategory.Name == subCategoryButton
                      select ProductSubcategory.ProductSubcategoryID
                      ).FirstOrDefault(); //This FirstOrDefault will allow the var to be cast as an int
                                          //rather than an IQueriable.

            productView.ProductQuery = db.Products.Where(p => p.ProductSubcategoryID == id).ToList();
            //Store the data away to be called later.

            TempData["query"] = productView;
            return View(productView);//db.ProductSubcategories.ToList())
        }

        public ActionResult ProductsList()//ProductViewModel productView)
        {
            ProductViewModel productView = (ProductViewModel) TempData["query"];
            return View(productView);
        }

        public ProductCategoriesViewModel CreateViewModel(ProductCategoriesViewModel viewModel)
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