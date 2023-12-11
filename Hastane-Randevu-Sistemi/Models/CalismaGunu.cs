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
        public string Gunler { get; set; } //0 1 2 3 4 5 6 şeklinde alıcak enum ile günler belirtilecek
        [Required]
        public string Saatler { get; set; }// 9:00 - 17:00 şeklinde tanımlaması yapılacak sonrasında 

        [ForeignKey("DoktorId")]
        [Required]
        public int DoktorId { get; set; }

    }
}
