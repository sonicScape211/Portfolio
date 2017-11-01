using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Homework5.DAL;
using Homework5.Models;

namespace Homework5.Controllers
{
    public class DMVFormController : Controller
    {

        DMVEntryContext db = new DMVEntryContext();
        // GET: DMVForm
        public ActionResult Index()
        {
            //Show the list within the DMV record from the DMVEntryContext class in the DAL.
            //return View(db.DMVRecord.ToList());
        }
    }
}