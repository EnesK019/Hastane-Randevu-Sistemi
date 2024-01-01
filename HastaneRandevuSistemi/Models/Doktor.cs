using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hastane_Randevu_Sistemi.Models
{
    public class Doktor
    {
        [Key]
        public int DoktorID { get; set; }

        [Required]
        [MaxLength(50)]
        public string DoktorAd { get; set; }

        [Required]
        [MaxLength(50)]
        public string DoktorSoyad { get; set; }

        [Required]
        [ForeignKey("PoliklinikId")]
        [Display(Name =  "Poliklinik")]
        public int PoliklinikId { get; set; }
        public bool? IsActive { get; set; }
        public ICollection<Randevu>? Randevular { get; set; }
    }
}
