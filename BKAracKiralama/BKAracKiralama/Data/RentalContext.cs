using BKAracKiralama.Models;
using Microsoft.EntityFrameworkCore;

namespace BKAracKiralama.Data
{
    public class RentalContext: DbContext
    {
        public RentalContext(DbContextOptions<RentalContext> options) : base(options)
        {
        }

        public DbSet<Müsteri> Müsteriler { get; set; }
        public DbSet<Kiralama> Kiralamalar { get; set; }
        public DbSet<Arac> Araclar { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Müsteri>().ToTable("Müsteri");
            modelBuilder.Entity<Kiralama>().ToTable("Kiralama");
            modelBuilder.Entity<Arac>().ToTable("Arac");
        }
    }
}
