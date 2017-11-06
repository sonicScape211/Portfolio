using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Homework4.Controllers
{
    /// <summary>
    /// Controller to return the homeview of the webpage for navigation around
    /// the rest of the project.
    /// </summary>
    public class HomeController : Controller
    {
        public ActionResult Home()
        {
            return View();
        }

    }
}