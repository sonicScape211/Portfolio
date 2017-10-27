using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using System.Web.Mvc;

namespace Homework4.Controllers
{
    public class LoanCalculatorController : Controller
    {
        // GET: LoanCalculator
        public ActionResult LoanCalculator()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoanCalculator(FormCollection form)
        {
            //ViewBag.RequestMethod = "POST";
            double loan;
            double rate;
            double term;

            string numericalErrorMessage = "Please enter a numerical value.";
            //Test to see if loan can be converted to a double.

            try
            {
                loan = double.Parse(form.Get(0));
            }
            catch
            {
                Debug.WriteLine("In the catch statment.");
                ViewBag.loanAmountError = numericalErrorMessage;
                return View();
                //LoanCalculator("loanAmountError");
            }

            try
            {
                rate = double.Parse(form.Get(1));
            }
            catch
            {
                ViewBag.interestRateError = numericalErrorMessage;
                return View();
            }

            try
            {
                term = double.Parse(form.Get(2));
            }
            catch
            {
                ViewBag.termLengthError = numericalErrorMessage;
                return View();
            }
            return RedirectToAction("ResultPage");
        }

    }
}