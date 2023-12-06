using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hastane_Randevu_Sistemi.Models
{
    public class CalismaGunu
    {
        [Key]
        public int CalismaGunID { get; set; }
        [Required]
        [MaxLength(7)]
        public string Gunler { get; set; }
        [Required]
        public string Saatler { get; set; }

        [ForeignKey("DoktorId")]
        [Required]
        public int DoktorId { get; set; }

    }
}
