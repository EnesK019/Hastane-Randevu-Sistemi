namespace Hastane_Randevu_Sistemi.Models
{
    public class Doktor
    {
        public int DoktorID { get; set; }
        public string DoktorAd { get; set; }
        public string DoktorSoyad { get; set; }
        public int PoliklinikId { get; set; }
        public bool IsActive { get; set; }
        ICollection<Hasta>? Hastalar {  get; set; }
        ICollection<Randevu>? Randevular { get; set; }
    }
}
