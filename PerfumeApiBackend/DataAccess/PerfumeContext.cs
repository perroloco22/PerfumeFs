using Microsoft.EntityFrameworkCore;
using PerfumeApiBackend.Models.DataModels;

namespace PerfumeApiBackend.DataAccess
{
    public class PerfumeContext : DbContext
    {
        public PerfumeContext(DbContextOptions<PerfumeContext> options) : base(options) { }

        //TODO Add DbSets (Tables of our DB)

        public DbSet<Perfume>? Perfumes { get; set; }
        public DbSet<Perfumery>? Perfumeries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Perfume>().ToTable("Perfume");
            modelBuilder.Entity < Perfumery>().ToTable("Perfumery");
        }

    }
}
