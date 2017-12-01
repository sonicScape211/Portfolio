using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
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
            GenreArtworkViewModel completeViewModel = CreateViewModel(genreArtwork);
            return View(completeViewModel);
        }

        /*
         * Create the initial view model for the homepage. All we will need is the genres currently.
         */
        private GenreArtworkViewModel CreateViewModel(GenreArtworkViewModel viewModel)
        {

            viewModel.Genre = dbContext.Genres.ToList();

            return viewModel;
        }

        /*
         * Create the custom view model for the partial view that shows the artwork titles
         * based on the genre provided.
         */
        public ActionResult DisplayArtwork(string genre) {

            var viewModel = new GenreArtworkViewModel
            {
                Genre = dbContext.Genres.ToList(),
                Classification = dbContext.Classifications.Where(c => c.Genre == genre)
            };
            //This will return a new partial view with the new instance of the viewModel items.
            //ie. the edited artwork list which has only artworks of a particular genre.
            return PartialView("_ArtworkView", viewModel);

        }

        /*
         * This will create a new model for the partial view that displays the artwork's specific
         * details.
         */
        public ActionResult ArtworkDetails(string title) {

            Debug.WriteLine("In the details section");
            Debug.WriteLine(title);

            var viewModel = new GenreArtworkViewModel
            {
                Genre = dbContext.Genres.ToList(),
                Artwork = dbContext.Artworks.Where(a => a.Title == title)
            };

            return PartialView("_ArtworkDetails", viewModel);
        }

    }
}