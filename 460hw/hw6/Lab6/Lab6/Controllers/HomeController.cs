using Lab6.Models;
using System;
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
            //Pass in the product categories as a list when the page is created.
            return View(db.ProductCategories.ToList());
        }

        public ActionResult ProductDropDown()
        {
            var productCategoriesList = db.ProductCategories.ToList();
            SelectList list = new SelectList(productCategoriesList, "ID", "Name");
            ViewBag.productList = list;
            return View();
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