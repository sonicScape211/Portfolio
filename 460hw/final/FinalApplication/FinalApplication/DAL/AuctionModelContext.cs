namespace FinalApplication.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AuctionModelContext : DbContext
    {
        public AuctionModelContext()
            : base("name=AuctionModelContext")
        {
        }

        public virtual DbSet<Bid> Bids { get; set; }
        public virtual DbSet<Buyer> Buyers { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Seller> Sellers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Buyer>()
                .Property(e => e.BuyerName)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Buyer>()
                .HasMany(e => e.Bids)
                .WithRequired(e => e.Buyer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.ItemName)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.ItemDescription)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .HasMany(e => e.Bids)
                .WithRequired(e => e.Item)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Seller>()
                .Property(e => e.SellerName)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Seller>()
                .HasMany(e => e.Items)
                .WithRequired(e => e.Seller)
                .WillCascadeOnDelete(false);
        }
    }
}
