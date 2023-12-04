namespace Hastane_Randevu_Sistemi.Models
{
    public class Hasta
    {
        public int HastaID { get; set; }
        public string HastaAd { get; set; }
        public string HastaSoyad{ get; set; }
        ICollection<Randevu> Randevular { get; set; }
    }

}
