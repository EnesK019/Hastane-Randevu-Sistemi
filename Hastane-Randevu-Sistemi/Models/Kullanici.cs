using System.ComponentModel.DataAnnotations;

namespace Hastane_Randevu_Sistemi.Models
{
    public class Kullanici
    {
        [Key]
        public int KullaniciID { get; set; }
        [Required]
        [MaxLength(50)]
        public string KullaniciAd { get; set; }
        [Required]
        [MaxLength(50)]
        public string KullaniciSoyad { get; set; }
        [Required]
        [RegularExpression("^[1-9]{1}[0-9]{9}[02468]{1}$")]
        public long TcNo { get; set; }
        [Required]
        [RegularExpression("^([A-Z0-9_.-@#$%^&*()<>/?])([a-z0-9_.-@#$%^&*()<>/?])([0-9])*$")]
        public string Sifre { get; set; }
        [Required]
        [Compare("Sifre", ErrorMessage = "Şifreler Eşleşmiyor")]
        public string SifreKontrol { get; set; }
        [Required]
        public int DogumYil { get; set; }
        ICollection<Randevu>? Randevular { get; set; }
    }
}
