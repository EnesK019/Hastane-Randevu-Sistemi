using Microsoft.AspNetCore.Identity;

namespace HastaneRandevuSistemi.Models
{
    public class Kullanici : IdentityUser
    {
        public string KullaniciAd { get; set; }
        public string KullaniciSoyad { get; set; }
        public string TcNo { get; set; }
    }
}
