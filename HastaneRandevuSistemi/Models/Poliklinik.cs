using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HastaneRandevuSistemi.Models
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
        public ICollection<Doktor>? Doktorlar { get; set; }
    }
}
