using Microsoft.AspNetCore.Identity;

namespace HastaneRandevuSistemi.Models
{
    public class Kullanici : IdentityUser<int>
    {
        public string UserSurname { get; set; }
    }
}
