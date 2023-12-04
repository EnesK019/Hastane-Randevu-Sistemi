namespace Hastane_Randevu_Sistemi.Models
{
    public class Randevu
    {
        public int RandevuID { get; set; }
        public int DoktorId { get; set; }
        public int HastaId { get; set; }
        public DateTime Tarih { get; set; }
    }
}
