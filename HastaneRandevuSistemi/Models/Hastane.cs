using System.ComponentModel.DataAnnotations;

namespace HastaneRandevuSistemi.Models
{
    public class Hastane
    {
        [Key]
        public int HastaneID { get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name = "Hastane Adı")]
        public string HastaneAdi { get; set; }
        public ICollection<Poliklinik>? Poliklinikler { get; set; }
    }
}
