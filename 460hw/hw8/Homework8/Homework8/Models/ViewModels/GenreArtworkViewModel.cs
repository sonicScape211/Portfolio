using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homework8.Models.ViewModels
{
    public class GenreArtworkViewModel
    {
        public IEnumerable<Artwork> Artwork { get; set; }
        public IEnumerable<Genre> Genre { get; set; }
        public IEnumerable<Classification> Classification { get; set; }
    }
}