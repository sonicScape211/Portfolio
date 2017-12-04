using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalPractice.Models;

namespace FinalPractice.Controllers
{
    public class ClassificationsController : Controller
    {
        private ArtworkDbContext db = new ArtworkDbContext();

        // GET: Classifications
        public ActionResult Index()
        {
            var classifications = db.Classifications.Include(c => c.Artwork).Include(c => c.Genre);
            return View(classifications.ToList());
        }

    }  
}
