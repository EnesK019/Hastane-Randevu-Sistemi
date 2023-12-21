using HastaneRandevuSistemi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HastaneRandevuSistemi.Data
{
    public class HastaneContext : IdentityDbContext
    {
        public HastaneContext(DbContextOptions<HastaneContext> claims) : base(claims)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb; Database=HastaneDB; Trusted_Connection = True;");
        }

        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Rol> Roller { get; set; }
        public DbSet<Hastane>? Hastane { get; set; }
        public DbSet<Poliklinik>? Poliklinik { get; set; }
        public DbSet<Doktor>? Doktor { get; set; }
        public DbSet<Randevu>? Randevu { get; set; }
        public DbSet<CalismaGunu>? CalismaGunu { get; set; }

    }
}
