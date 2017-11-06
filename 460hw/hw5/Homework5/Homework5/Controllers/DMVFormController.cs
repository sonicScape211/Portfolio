using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Homework5.DAL;
using Homework5.Models;

namespace Homework5.Controllers
{
    public class DMVFormController : Controller
    {

        private DMVEntryContext db = new DMVEntryContext();
        // GET: DMVForm
        public ActionResult Index()
        {
            //Show the list within the DMV record from the DMVEntryContext class in the DAL.
            return View(db.DMVEntries.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}