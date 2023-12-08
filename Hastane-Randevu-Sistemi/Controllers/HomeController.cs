using Microsoft.AspNetCore.Mvc;

namespace Hastane_Randevu_Sistemi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
