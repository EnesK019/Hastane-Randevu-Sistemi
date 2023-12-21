﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HastaneRandevuSistemi.Models
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
        public int PoliklinikId { get; set; }
        public bool? IsActive { get; set; }
        ICollection<CalismaGunu>? CalismaGunleri { get; set; }
        ICollection<Randevu>? Randevular { get; set; }
    }
}
