using FinalPractice.Models;
using FinalPractice.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalPractice.Controllers
{
    public class HomeController : Controller
    {
        public ArtworkDbContext dbContext = new ArtworkDbContext();
        public ArtworksViewModel artworksViewModel = new ArtworksViewModel();

        public ActionResult Index()
        {
            ArtworksViewModel viewModel = PopulateViewModel(artworksViewModel);
            return View(viewModel);
        }

        public ArtworksViewModel PopulateViewModel(ArtworksViewModel viewModel)
        {
            //Set the genre class. This is the only thing that will be used
            //In the calls to Index.
            viewModel.Genre = dbContext.Genres;

            return viewModel;
        }


        public PartialViewResult GenreSelection(int genreID) {

            var viewModel = new ArtworksViewModel();

            /*
             * This query will take the unaltered db of Artworks and create a new table, joined with
             * an ArtworkID and a GenreID where the GenreID is equal to the button the user has pressed.
             */
            viewModel.Classification = dbContext.Artworks
                                 .Join(dbContext.Classifications,
                                 a => a.ArtworkID,
                                 c => c.GenreID,
                                 (a, c) => new { a, c })
                                 .Where(z => z.c.GenreID == genreID)
                                 .Select(z => z.c);

            /*
             * This will create the Artwork model for the ViewModel by joining the unaltered dbArtworks with
             * the newly created classification model of the ViewModel and populate the ViewModels artworks with
             * Artist that match the classification class of the viewModel, thus supplying only Artworks which
             * fall under the user selected genre.
             */
            viewModel.Artwork = dbContext.Artworks
                                .Join(viewModel.Classification,
                                a => a.ArtworkID,
                                c => c.ArtworkID,
                                (a, c) => new { a, c })
                                .Where(z => z.a.ArtworkID == z.c.ArtworkID)
                                .Select(z => z.a);

            return PartialView("_ArtworkView", viewModel);
        }

        public PartialViewResult ArtworkDetailSelection(int artworkID)
        {
            var viewModel = new ArtworksViewModel();

            viewModel.Artwork = dbContext.Artworks.Where(a => a.ArtworkID == artworkID);

            viewModel.Artist = dbContext.Artists.Where(a => a.ArtistID == viewModel.Artwork
                                                .Select(aw => aw.ArtistID)
                                                .FirstOrDefault());

            return PartialView("_ArtworkDetailsView", viewModel);

        }

    }
}