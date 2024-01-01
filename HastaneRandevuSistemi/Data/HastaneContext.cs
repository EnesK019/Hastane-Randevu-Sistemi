using Hastane_Randevu_Sistemi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hastane_Randevu_Sistemi.Data
{
    public class HastaneContext : IdentityDbContext
    {
        public HastaneContext(DbContextOptions<HastaneContext> claims) : base(claims)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb; Database=Hastane3; Trusted_Connection = True;");
        }

		public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Hastane> Hastane { get; set; }
        public DbSet<Poliklinik> Poliklinik { get; set; }
        public DbSet<Doktor> Doktor { get; set; }
        public DbSet<Randevu> Randevu { get; set; }

        

    }
}
