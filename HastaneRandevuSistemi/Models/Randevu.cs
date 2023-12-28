using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hastane_Randevu_Sistemi.Models
{
    public class Randevu
    {
        [Key]
        public int RandevuID { get; set; }

        [ForeignKey("DoktorId")]
        public int DoktorId { get; set; }

        [ForeignKey("KullaniciId")]
        public string KullaniciId { get; set; }

        [DataType(DataType.Date), Display(Name = "Randevu Günü"), DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime RandevuGun { get; set; }

       // [DataType(DataType.DateTime), Display(Name = "Randevu Saati"), DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        [Required]
        public TimeSpan RandevuSaat { get; set; }
        public bool IsEmpty { get; set; }
    }
}
