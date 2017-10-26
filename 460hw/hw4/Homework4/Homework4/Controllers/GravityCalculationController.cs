using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Homework4.Controllers
{
    public class GravityCalculationController : Controller
    {
        // GET: GravityCalculation
        public ActionResult GravityCalculation()
        {
            return View();
            
        }

        public ActionResult GravityFormInformation()
        {
            string originalGravity = Request.Form["original-gravity"];
            string specificGravity = Request.Form["specific-gravity"];
           
            ViewBag.originalGravity = originalGravity;
            ViewBag.specificGravity = specificGravity;

            ViewData["abv"] = ((float.Parse(originalGravity) - float.Parse(specificGravity)) * 131).ToString(); 
            return View();
        }
        //[HttpPost]
        //public ActionResult GravityCalculation(string originalGravity)
        //{
          //  Debug.WriteLine($"{originalGravity}");
           // return View();
        //}
    }
}