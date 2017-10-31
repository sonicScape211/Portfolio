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
        public ActionResult LoanCalculator(string loanAmount, string interestRate, int? termLength)
        {
            //ViewBag.RequestMethod = "POST";
            double loan;
            double rate;
            double term;

            string numericalErrorMessage = "Please enter a numerical value.";
            //Test to see if loan can be converted to a double.

            try
            {
                loan = double.Parse(loanAmount);
                
            }
            catch
            {
                ViewBag.loanAmountError = numericalErrorMessage;
                return View();
            }

            try
            {
                rate = double.Parse(interestRate);
            }
            catch
            {
                ViewBag.interestRateError = numericalErrorMessage;
                return View();
            }

            try
            {
                term = (double) termLength;
            }
            catch
            {
                ViewBag.termLengthError = numericalErrorMessage;
                return View();
            }
            TempData["termLength"] = term;
            TempData["interestRate"] = rate;
            TempData["loanAmount"] = loan;
            calculatorLogic(loan, rate, term);
            return RedirectToAction("ResultPage");
        }

        public ActionResult ResultPage()
        {
            //Pass the TempData that was stored in calculatorLogic function to the viewBag for use.
            ViewBag.loanPaymentResult = TempData["paymentAmount"];
            ViewBag.termLength = TempData["termLength"];
            ViewBag.interestRate = TempData["interestRate"];
            ViewBag.loanAmount = TempData["loanAmount"];
            return View();
        }

        public double calculatorLogic(double loanAmount, double interestRate, double termLength)
        {
            interestRate = interestRate * .01;
            double negitiveTermLength = termLength - (termLength * 2);
            double result = loanAmount * (interestRate / (1 - (Math.Pow((1 + interestRate), negitiveTermLength))));
            //Store the result in TempData in order to pass data to another method in the controller.
            TempData["paymentAmount"] = Math.Round(result, 2);
            return result;
        }

    }
}