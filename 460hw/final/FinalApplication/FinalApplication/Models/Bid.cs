namespace FinalApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Bid")]
    public partial class Bid
    {
        public int BidID { get; set; }

        public int ItemID { get; set; }

        public int BuyerID { get; set; }

        public int Price { get; set; }

        public DateTime BidTime { get; set; }

        public virtual Item Item { get; set; }

        public virtual Buyer Buyer { get; set; }
    }
}
