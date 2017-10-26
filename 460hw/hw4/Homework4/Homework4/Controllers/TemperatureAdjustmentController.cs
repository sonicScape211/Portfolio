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
        // GET: TemperatureAdjustment
        public ActionResult TemperatureAdjustment()
        {
            return View();
        }

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

        /*
         * Calculates the correct gravity for the user given temperature.
         * @return double The correct gravity.
         */
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