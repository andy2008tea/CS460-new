namespace CS460Final.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AtrContext : DbContext
    {
        public AtrContext()
            : base("name=AtrContext")
        {
        }

        public virtual DbSet<Artist> Artist { get; set; }
        public virtual DbSet<ArtWork> ArtWork { get; set; }
        public virtual DbSet<Classification> Classification { get; set; }
        public virtual DbSet<Genre> Genre { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArtWork>()
                .HasMany(e => e.Classification)
                .WithRequired(e => e.ArtWork)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Genre>()
                .HasMany(e => e.Classification)
                .WithRequired(e => e.Genre)
                .WillCascadeOnDelete(false);
        }
    }
}
