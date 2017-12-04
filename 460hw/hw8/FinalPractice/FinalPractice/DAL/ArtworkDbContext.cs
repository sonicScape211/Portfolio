namespace FinalPractice.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ArtworkDbContext : DbContext
    {
        public ArtworkDbContext()
            : base("name=ArtworkDbContext")
        {
        }

        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<Artwork> Artworks { get; set; }
        public virtual DbSet<Classification> Classifications { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist>()
                .Property(e => e.ArtistName)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Artist>()
                .Property(e => e.CityOfBirth)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Artist>()
                .HasMany(e => e.Artworks)
                .WithRequired(e => e.Artist)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Artwork>()
                .Property(e => e.ArtworkTitle)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Artwork>()
                .HasMany(e => e.Classifications)
                .WithRequired(e => e.Artwork)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Genre>()
                .Property(e => e.Genre1)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Genre>()
                .HasMany(e => e.Classifications)
                .WithRequired(e => e.Genre)
                .WillCascadeOnDelete(false);
        }
    }
}
