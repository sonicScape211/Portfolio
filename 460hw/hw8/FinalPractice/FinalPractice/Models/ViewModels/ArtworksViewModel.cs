using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalPractice.Models.ViewModels
{
    public class ArtworksViewModel
    {
        public IEnumerable<Artwork> Artwork { get; set; }
        public IEnumerable<Genre> Genre { get; set; }
        public IEnumerable<Artist> Artist { get; set; }
        public IEnumerable<Classification> Classification { get; set; }

    }
}