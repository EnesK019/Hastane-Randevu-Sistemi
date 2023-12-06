using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hastane_Randevu_Sistemi.Models
{
    public class Poliklinik
    {
        [Key]
        public int PoliklinikID { get; set; }
        [Required]
        [MaxLength(100)]
        public int PoliklinikAdi { get; set; }
        [ForeignKey("HastaneId")]
        [Required]
        public int HastaneId { get; set; }
        ICollection<Doktor>? Doktorlar { get; set;}
    }
}