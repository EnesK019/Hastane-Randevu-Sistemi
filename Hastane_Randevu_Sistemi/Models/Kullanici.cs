using Microsoft.AspNetCore.Identity;

namespace Hastane_Randevu_Sistemi.Models
{
    public class Kullanici : IdentityUser
    {
        public string KullaniciAd { get; set; }
        public string KullaniciSoyAd { get; set; }
        public string TcNo { get; set; }
        public ICollection<Randevu>? Randevular {  get; set; }
    }
}
