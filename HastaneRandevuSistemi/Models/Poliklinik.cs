using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hastane_Randevu_Sistemi.Models
{
    public class Poliklinik
    {
        [Key]
        public int PoliklinikID { get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name = "Poliklinik Adı")]
        public string PoliklinikAdi { get; set; }
        [ForeignKey("HastaneId")]
        [Required]
        [Display(Name = "Hastane")]
        public int HastaneId { get; set; }
        
        public ICollection<Doktor>? Doktorlar { get; set; }
    }
}
