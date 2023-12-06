using Microsoft.EntityFrameworkCore;
using System.Xml;

namespace Hastane_Randevu_Sistemi.Models
{
    public class HastaneContext:DbContext
    {
        public DbSet<Hastane> Hastaneler { get; set; }
        public DbSet<Poliklinik> Poliklinikler { get; set; }
        public DbSet<Doktor> Doktorlar { get; set; }
        public DbSet<Hasta> Hastalar { get; set; }
        public DbSet<Randevu> Randevular { get; set; }
        public DbSet<CalismaGunu> CalismaGunleri { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;
Database=HastaneRS; Trusted_Connection = True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doktor>()
                .Property(e => e.IsActive)
                .HasDefaultValue(true);
        }
    }
}
