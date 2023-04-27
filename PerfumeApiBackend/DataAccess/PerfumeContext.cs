using Microsoft.EntityFrameworkCore;
using PerfumeApiBackend.Models.DataModels;

namespace PerfumeApiBackend.DataAccess
{
    public class PerfumeContext : DbContext
    {
        public PerfumeContext(DbContextOptions<PerfumeContext> options) : base(options) { }

        //Add DbSets (Tables of our DB)

        public DbSet<Perfume>? Perfumes { get; set; }
        public DbSet<Perfumery>? Perfumeries { get; set; }
        public DbSet<Brand>? Brands { get; set; }
        public DbSet<Concentration>? Concentrations { get; set; }
        public DbSet<Gender>? Genders { get; set; }
        public DbSet<Stock>? Stocks { get; set; }
        public DbSet<Volume> Volumes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Perfume>().ToTable("Perfume");
            modelBuilder.Entity <Perfumery>().ToTable("Perfumery");
            modelBuilder.Entity<Brand>().ToTable("Brand");
            modelBuilder.Entity<Concentration>().ToTable("Concentration");
            modelBuilder.Entity<Gender>().ToTable("Gender");
            modelBuilder.Entity<Stock>().ToTable("Stock");
            modelBuilder.Entity<Volume>().ToTable("Volume");
        }

    }
}
