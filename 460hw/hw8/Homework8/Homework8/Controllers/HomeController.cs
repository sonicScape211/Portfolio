using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Homework8.Models.ViewModels;

namespace Homework8.Controllers
{
    public class HomeController : Controller
    {
        private ArtDbContext dbContext = new ArtDbContext();
        //Create the view model to be passed into the homepage view on first opening the website.
        public GenreArtworkViewModel genreArtwork = new GenreArtworkViewModel();

        public ActionResult Index()
        {
            GenreArtworkViewModel completeViewModel = createViewModel(genreArtwork);
            return View(completeViewModel);
        }

        private GenreArtworkViewModel createViewModel(GenreArtworkViewModel viewModel) {

            viewModel.Artist = dbContext.Artists.ToList();
            viewModel.Genre = dbContext.Genres.ToList();

            return viewModel;
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