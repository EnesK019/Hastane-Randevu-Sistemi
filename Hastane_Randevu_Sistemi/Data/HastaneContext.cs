using Hastane_Randevu_Sistemi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hastane_Randevu_Sistemi.Data
{
    public class HastaneContext : IdentityDbContext
    {
        public HastaneContext(DbContextOptions<HastaneContext> options) : base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb; Database=Hastane; Trusted_Connection = True;");
        }

       // public DbSet<Kullanici> Kullanicilar { get; set; }
    }
}
