using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Homework4.Controllers
{
    public class TemperatureAdjustmentController : Controller
    {
        /// <summary>
        /// Get the Temperature Adjustment view page.
        /// </summary>
        /// <returns></returns>
        // GET: TemperatureAdjustment
        public ActionResult TemperatureAdjustment()
        {
            return View();
        }

        /// <summary>
        /// On any POST request the controller will grab and process information
        /// from the form on the TemperatureAdjustment view.
        /// </summary>
        /// <param name="form">Form TempAdjustment form.</param>
        /// <returns>The View with calculated Temp Adjustments.</returns>
        [HttpPost]
        public ActionResult TemperatureAdjustment(FormCollection form)
        {
            double gravity = double.Parse(form.Get(0));
            double temperature = double.Parse(form.Get(1));

            double result = temperatureCalculation(gravity, temperature);

            ViewBag.adjustedGravity = result.ToString();
            ViewBag.gravity = gravity;

            return View();
        }

        /// <summary>
        /// Method for calculating the correct gravity of a homebrew for 
        /// the user given temperature and their current gravity..
        /// </summary>
        /// <param name="gravity">double The users current gravity.</param>
        /// <param name="temp">double The temperature of the brew.</param>
        /// <returns>Double The correct gravity</returns>
        public double temperatureCalculation(double gravity, double temp)
        {
            if (temp >= 51.0 && temp <= 69.9)
            {
                //Between 51 degrees and 69 degrees, gravity does not change.
                return gravity;
            }
            else if (temp >= 70.0 && temp <= 76.9)
            {
                gravity += .001;
            }
            else if (temp >= 77.0 && temp <= 83.9)
            {
                gravity += .002;
            }
            else if (temp >= 84.0 && temp <= 94.9)
            {
                gravity += .003;
            }
            else if (temp >= 95.0 && temp <= 104.9)
            {
                gravity += .004;
            }
            else if (temp <= 105.0)
            {
                gravity += .005;
            }
            return gravity;
        }
    }
}