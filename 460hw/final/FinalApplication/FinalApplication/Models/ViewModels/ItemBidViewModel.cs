using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalApplication.Models.ViewModels
{
    public class ItemBidViewModel
    {
        public IEnumerable<Item> Item { get; set; }
        public IEnumerable<Bid> Bid { get; set; }
        public IEnumerable<Seller> Seller { get; set; }
    }
}