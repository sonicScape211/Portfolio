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
        /// <summary>
        /// Method to process GET requests to the GravityCalculation View.
        /// </summary>
        /// <returns>ActionResult View of GravityCalculation</returns>
        public ActionResult GravityCalculation()
        {
            return View();
            
        }

        /// <summary>
        /// Specific action for sending information from the View via the
        /// Request.Form method. This will get information from the form and
        /// calculate the final gravity of a homebrew.
        /// </summary>
        /// <returns>ActionResult The View with information on the users final
        /// gravity based on their form input information
        /// </returns>
        public ActionResult GravityFormInformation()
        {
            string originalGravity = Request.Form["original-gravity"];
            string specificGravity = Request.Form["specific-gravity"];
           
            ViewBag.originalGravity = originalGravity;
            ViewBag.specificGravity = specificGravity;

            ViewData["abv"] = Math.Round(((float.Parse(originalGravity) - float.Parse(specificGravity)) * 131), 2).ToString(); 
            return View();
        }
    }
}