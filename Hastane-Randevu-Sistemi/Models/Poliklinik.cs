namespace Hastane_Randevu_Sistemi.Models
{
    public class Poliklinik
    {
        public int PoliklinikID { get; set; }
        public int PoliklinikAdi { get; set; }
        public int HastaneId { get; set; }
        ICollection<Doktor>? Doktorlar { get; set;}
    }
}
