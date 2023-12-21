using Microsoft.AspNetCore.Identity;

namespace Hastane_Randevu_Sistemi.Models
{
    public class Kullanici : IdentityUser
    {
        public int Id { get; set; }

    }
}   