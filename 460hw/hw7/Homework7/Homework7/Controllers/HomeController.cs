using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using System.Web.Mvc;
//Imported for use with the WebRequest class.
using System.Net;
//Imported for use with the reader and stream classes.
using System.IO;
//Imported for use with the JSON class.
using System.Web.Helpers;
//Imported for use with converting strings to JSON objects.
using Newtonsoft.Json.Linq;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace Homework7.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {

            return View();
        }

        /*
         * Much of the following code is references from: https://docs.microsoft.com/en-us/dotnet/framework/network-programming/how-to-request-data-using-the-webrequest-class
         * 
         * This method will build a url to request Giphy for data and read it into a string, then convert that data
         * to a JSON format, then deserialize that date and return it to the AJAX success function. 
         */
        
        public JsonResult Search(string searchInput) {

            //Request encrypted api key from external source.
            //NOTE this needs to be here because this key will not stick around in a field
            //and for that matter shouldn't be stored away like that.
            string apiKey = System.Web.Configuration.WebConfigurationManager.AppSettings["GiphyAPIKey"];

            string userQuery = searchInput;
            string host = "api.giphy.com";
            string path = "/v1/gifs/search";
            
            //Create the WebRequest instance by calling Create method.
            WebRequest request = WebRequest.Create("https://"+ host + path + "?q=" + searchInput + "&api_key="+ apiKey + "&limit=1");
            //Get the response from the API
            WebResponse response = request.GetResponse();
            //Get the stream of data from the server.
            Stream dataStream = response.GetResponseStream();
            //Create a reader for the data stream
            //Read it!
            string apiResponse = new StreamReader(dataStream).ReadToEnd();//reader.ReadToEnd();
            
            //Convert the JSON string to a .NET object 
     
            var serializer = new JavaScriptSerializer();

            var data = serializer.DeserializeObject(apiResponse);
            
            //Close everything up
            response.Close();
            dataStream.Close();

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}