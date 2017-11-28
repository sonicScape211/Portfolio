namespace Homework8
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ArtDbContext : DbContext
    {
        public ArtDbContext()
            : base("name=ArtDbContext")
        {
        }

        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<Artwork> Artworks { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Classification> Classifications { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist>()
                .Property(e => e.Name)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Artwork>()
                .Property(e => e.Title)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Artwork>()
                .Property(e => e.Artist)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Genre>()
                .Property(e => e.Genre1)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Classification>()
                .Property(e => e.Title)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Classification>()
                .Property(e => e.Genre)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
