using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hastane_Randevu_Sistemi.Models
{
    public class Randevu
    {
        [Key]
        public int RandevuID { get; set; }

        [ForeignKey("DoktorId")]
        public int DoktorId { get; set; }

        [ForeignKey("HastaId")]
        public int HastaId { get; set; }

        [DataType(DataType.Date), Display(Name = "Randevu Tarihi"), DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime RandevuTarih { get; set; }
    }
}
