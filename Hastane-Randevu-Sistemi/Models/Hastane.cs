namespace Hastane_Randevu_Sistemi.Models
{
    public class Hastane
    {
        public int HastaneID { get; set; }
        public string HastaneAdi { get; set; }
        ICollection<Poliklinik>? Poliklinikler { get; set; }
    }
}
