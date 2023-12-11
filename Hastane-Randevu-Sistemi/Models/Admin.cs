using System.ComponentModel.DataAnnotations;

namespace Hastane_Randevu_Sistemi.Models
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Kullanıcı Adı")]
        public string KullaniciAd { get; set; }
        [Required]
        [MaxLength(50)]
        [MinLength(8)]
        [Display(Name = "Şifre")]
        [RegularExpression("^([A-Z0-9_.-@#$%^&*()<>/?])([a-z0-9_.-@#$%^&*()<>/?])([0-9])*$")]
        public string Sifre { get; set; }
        [Required]
        [Compare("Sifre", ErrorMessage = "Şifreler Eşleşmiyor")]
        public string SifreKontrol { get; set; }
    }
}