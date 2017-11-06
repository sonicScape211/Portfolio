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
        /// <summary>
        /// Method to Process GET request for the LoanCalculator View.
        /// </summary>
        /// <returns>ActionResult View for the LoanCalculator</returns>
        public ActionResult LoanCalculator()
        {
            return View();
        }

        /// <summary>
        /// Method specific to HttpPost requests to the server for the LoanCalculator View.
        /// This will take in a query string of the loan form information the user has filled out.
        /// It will also perform some error detection and handling.
        /// </summary>
        /// <param name="loanAmount">String User form input of amount for their loan.</param>
        /// <param name="interestRate">String User form input for the intrest rate of the loan.</param>
        /// <param name="termLength">int? Integer for the length of the loan.</param>
        /// <returns>ActionResult View containing the processed information of the calculated loan.
        /// (This will be a RedirectToAction which will then take the user to the View)
        /// </returns>
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

        /// <summary>
        /// Method to GET the ResultPage View. This will pass in the processed information 
        /// of the users loan and the calculation.
        /// </summary>
        /// <returns>ActionResult The View with all processed user information on their loan.</returns>
        public ActionResult ResultPage()
        {
            //Pass the TempData that was stored in calculatorLogic function to the viewBag for use.
            ViewBag.loanPaymentResult = TempData["paymentAmount"];
            ViewBag.termLength = TempData["termLength"];
            ViewBag.interestRate = TempData["interestRate"];
            ViewBag.loanAmount = TempData["loanAmount"];
            return View();
        }

        /// <summary>
        /// Arithmetic method for calculating the amount of your payments on a loan based on
        /// the loan amount, interest rate and term length.
        /// </summary>
        /// <param name="loanAmount">double Loan amount.</param>
        /// <param name="interestRate">double Interest rate.</param>
        /// <param name="termLength">double Length of the loan.</param>
        /// <returns>double Calculated payment amount.</returns>
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