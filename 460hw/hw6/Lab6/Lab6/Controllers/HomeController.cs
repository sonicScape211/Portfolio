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
        ProductDetailsViewModel detailsViewModel = new ProductDetailsViewModel();

        private int currentProductID;

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
            productView.Product = db.Products.ToList();

            productView.ProductQuery = db.Products
                                       .Where(p => p.ProductSubcategoryID == db.ProductSubcategories
                                       .Where(psub => psub.Name == subCategoryButton)
                                       .Select(psub => psub.ProductSubcategoryID)
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

        public ActionResult ProductDetailsPage(int productID)
        {
            detailsViewModel = PopulateDetailsViewModel(productID);
                                            
            return View(detailsViewModel);
        }

        public ProductDetailsViewModel PopulateDetailsViewModel(int productID)
        {

            detailsViewModel.Products = db.Products
                                        .Where(p => p.ProductID == productID);

            detailsViewModel.ProductCategory = db.ProductCategories
                                               .Where(pc => pc.ProductCategoryID == db.ProductSubcategories
                                               .Where(psub => psub.ProductSubcategoryID == db.Products
                                               .Where(p => p.ProductID == productID)
                                               .Select(p => p.ProductSubcategoryID)
                                               .FirstOrDefault())
                                               .Select(psub => psub.ProductCategoryID)
                                               .FirstOrDefault());

            detailsViewModel.ProductSubcategory = db.ProductSubcategories
                                                  .Where(psub => psub.ProductSubcategoryID == db.Products
                                                  .Where(p => p.ProductID == productID)
                                                  .Select(p => p.ProductSubcategoryID)
                                                  .FirstOrDefault());

            detailsViewModel.ProductReview = db.ProductReviews
                                             .Where(pr => pr.ProductID == productID);

            detailsViewModel.ProductPhoto = db.ProductPhotoes
                                            .Where(pp => pp.ProductPhotoID == db.ProductProductPhotoes
                                            .Where(prodpp => prodpp.ProductID == productID)
                                            .Select(prodpp => prodpp.ProductPhotoID)
                                            .FirstOrDefault());

            detailsViewModel.ProductDescription = db.ProductDescriptions
                                            .Where(pd => pd.ProductDescriptionID == (db.ProductModelProductDescriptionCultures
                                            .Where(pc => pc.ProductModelID == (db.Products.Where(p => p.ProductID == productID)
                                            .Select(p => p.ProductModelID)).FirstOrDefault())
                                            .Where(pc => pc.CultureID == "en")
                                            .Select(pc => pc.ProductDescriptionID)).FirstOrDefault());

            return (detailsViewModel);
        }

        public ActionResult Show(int id)
        {
            var imageData = db.ProductPhotoes
                            .Where(pp => pp.ProductPhotoID == id)
                            .Select(pp => pp.LargePhoto).FirstOrDefault();

            byte[] result = imageData.ToArray();

            return File(result, "image/jpg");
        }

        public ActionResult ReviewForm(int id)
        {
            ViewData["ProductID"] = id;
            currentProductID = id;
            Debug.WriteLine(currentProductID);

            return View();
        }

        public ActionResult SubmitReview(string id, [Bind(Include = "ProductReviewID,ProductID,ReviewerName,ReviewDate,EmailAddress,Rating,Comments,ModifiedDate")] ProductReview productReview)
        {
            //Get the id of the query string
            
            Debug.WriteLine(id);
            int productId = Convert.ToInt32(id);
            currentProductID = productId;

            if (ModelState.IsValid) {
                productReview.ProductID = productId;
                productReview.ReviewDate = DateTime.Now;
                productReview.ModifiedDate = DateTime.Now;

                db.ProductReviews.Add(productReview);
                db.SaveChanges();

                return RedirectToAction("ReviewAccepted");
            }

            return View();
        }

        public ActionResult ReviewAccepted()
        {
            return View();
        }
    }
}