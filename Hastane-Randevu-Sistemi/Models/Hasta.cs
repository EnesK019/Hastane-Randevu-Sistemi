using System.ComponentModel.DataAnnotations;

namespace Hastane_Randevu_Sistemi.Models
{
    public class Hasta
    {
        [Key]
        public int HastaID { get; set; }
        [Required]
        [MaxLength(50)]
        public string HastaAd { get; set; }
        [Required]
        [MaxLength(50)]
        public string HastaSoyad{ get; set; }
        ICollection<Randevu>? Randevular { get; set; }
    }

}
