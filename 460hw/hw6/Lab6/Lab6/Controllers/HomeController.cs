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

        [HttpPost]
        public ActionResult ProductsList(string subCategoryButton)
        {

            productView.ProductQuery = db.Products
                                       .Where(p => p.ProductSubcategoryID == db.ProductSubcategories
                                       .Where(psub => psub.Name == subCategoryButton)
                                       .Select(psub => psub.ProductCategoryID)
                                       .FirstOrDefault())
                                       .ToList();

            //Store the data away to be called later.
            TempData["query"] = productView;

            return View(productView);
        }

        public ActionResult ProductsList()//ProductViewModel productView)
        {
            ProductViewModel productView = (ProductViewModel)TempData["query"];
            return View(productView);
        }

        public ActionResult productDetailsPage(int productID)
        {

            productView.ProductDescription = db.ProductDescriptions
                                            .Where(pd => pd.ProductDescriptionID == (db.ProductModelProductDescriptionCultures
                                            .Where(pc => pc.ProductModelID == (db.Products.Where(p => p.ProductID == productID)
                                            .Select(p => p.ProductModelID)).FirstOrDefault())
                                            .Where(pc => pc.CultureID == "en")
                                            .Select(pc => pc.ProductDescriptionID)).FirstOrDefault());
                                            
            return View(productView);
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