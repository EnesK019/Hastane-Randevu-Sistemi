using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hastane_Randevu_Sistemi.Data;
using Hastane_Randevu_Sistemi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.V5.Pages.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using Microsoft.AspNetCore.Localization;
using Hastane_Randevu_Sistemi.Services;

namespace Hastane_Randevu_Sistemi.Controllers
{
    public class HastaneController : Controller
    {
        private readonly HastaneContext _context;
		private readonly LanguageService _localization;

		public HastaneController(HastaneContext context, LanguageService localization)
        {
            _context = context;
            _localization = localization;
        }
		public IActionResult ChangeLanguage(string culture)
		{
			Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
			new CookieOptions()
			{
				Expires = DateTimeOffset.UtcNow.AddYears(1)

			});
			return Redirect(Request.Headers["Referer"].ToString());
		}

		public async Task<IActionResult> Index()
        {
            ViewBag.Hastaneler = _localization.Getkey("Hastaneler").Value;
            ViewBag.HastaneAdi = _localization.Getkey("HastaneAdi").Value;
            List<Hastane> hastaneler = new List<Hastane>();
            HttpClient client = new HttpClient();
            var response = await client.GetAsync("https://localhost:7025/api/HastaneApi");
            var jsonResponse = await response.Content.ReadAsStringAsync();
            hastaneler = JsonConvert.DeserializeObject<List<Hastane>>(jsonResponse);

            var currentCulture = Thread.CurrentThread.CurrentCulture.Name;

            return View(hastaneler);
        }




        // GET: Hastane/Details/5

        public async Task<IActionResult> Details(int id)
        {
            ViewBag.HastaneDetay = _localization.Getkey("HastaneDetay").Value;
            ViewBag.Poliklinikler = _localization.Getkey("Poliklinikler").Value;
            ViewBag.HastaneAdi = _localization.Getkey("HastaneAdi").Value;

            ViewData["Poliklinikler"] = _context.Poliklinik.Where(x => x.HastaneId == id).ToList();
			ViewData["Hastane"] =  _context.Hastane.FirstOrDefault(x => x.HastaneID == id);
			Hastane hastane = ViewData["Hastane"] as Hastane;
			HttpClient client = new HttpClient();
			var response = await client.GetAsync("https://localhost:7025/api/HastaneApi/id");
			var jsonResponse = await response.Content.ReadAsStringAsync();
			hastane = JsonConvert.DeserializeObject<Hastane>(jsonResponse);

			return View(hastane);
		}

        // GET: Hastane/Create
        [Authorize(Roles ="Admin")]
        public IActionResult Create()
        {
            ViewBag.HastaneEkle = _localization.Getkey("HastaneEkle").Value;
            ViewBag.Ekle = _localization.Getkey("Ekle").Value;
			ViewBag.HastaneAdi = _localization.Getkey("HastaneAdi").Value;
            Hastane hastane = ViewData["Hastane"] as Hastane;

            return View();

        }

        // POST: Hastane/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Create( Hastane hastane)
        {
			ViewBag.HastaneEkle = _localization.Getkey("HastaneEkle").Value;
			ViewBag.Ekle = _localization.Getkey("Ekle").Value;
			ViewBag.HastaneAdi = _localization.Getkey("HastaneAdi").Value;

			HttpClient client = new HttpClient();
			var json = JsonConvert.SerializeObject(hastane);
			var content = new StringContent(json, Encoding.UTF8, "application/json");

			var response = await client.PostAsync("https://localhost:7025/api/HastaneApi/", content);
			var jsonResponse = await response.Content.ReadAsStringAsync();
			hastane = JsonConvert.DeserializeObject<Hastane>(jsonResponse);
			return RedirectToAction("Index");
        }

        // GET: Hastane/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
			ViewBag.Kaydet = _localization.Getkey("Kaydet").Value;
			ViewBag.HastaneDuzen = _localization.Getkey("HastaneDuzen").Value;
            ViewData["Poliklinikler"] = _context.Poliklinik.Where(x => x.HastaneId == id).ToList();
            ViewData["Hastane"] = _context.Hastane.FirstOrDefault(x => x.HastaneID == id);

            if (id == null || _context.Hastane == null)
            {
                return NotFound();
            }

            var hastane = await _context.Hastane.FindAsync(id);
            if (hastane == null)
            {
                return NotFound();
            }
            return View(hastane);
        }

        // POST: Hastane/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
		public async Task<IActionResult> Edit(int id, [Bind("HastaneID,HastaneAdi")] Hastane hastane)
		{
            ViewData["Poliklinikler"] = _context.Poliklinik.Where(x => x.HastaneId == id).ToList();
            ViewData["Hastane"] = _context.Hastane.FirstOrDefault(x => x.HastaneID == id);
            ViewBag.Kaydet = _localization.Getkey("Kaydet").Value;
			ViewData["hastane"] = _context.Hastane.FirstOrDefault(x => x.HastaneID == hastane.HastaneID);
			HttpClient client = new HttpClient();

			// Güncellemek istediğiniz kaydı içeren bir JSON nesnesi oluşturun
			var json = JsonConvert.SerializeObject(hastane);
			var content = new StringContent(json, Encoding.UTF8, "application/json");

			// PutAsync() yöntemini kullanarak kaydı güncelleyin
			//var response = await client.PutAsync("https://localhost:7025/api/HastaneApi/id", new StringContent(json));
			var response = await client.PutAsync($"https://localhost:7025/api/HastaneApi/{id}", content);
			// Güncelleme işleminin sonucunu kontrol edin
			if (response.IsSuccessStatusCode)
			{
				// Güncelleme başarılı
				ViewData["mesaj"] = "Hastane başarıyla güncellendi.";
			}
			else
			{
				// Güncelleme başarısız
				ViewData["mesaj"] = "Hastane güncellenemedi.";
			}

            return RedirectToAction("Index");
        }

		// GET: Hastane/Delete/5
		[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            ViewData["Poliklinikler"] = _context.Poliklinik.Where(x => x.HastaneId == id).ToList();
            ViewData["Hastane"] = _context.Hastane.FirstOrDefault(x => x.HastaneID == id);
            ViewBag.HastaneSil = _localization.Getkey("HastaneSil").Value;
            ViewBag.Sil = _localization.Getkey("Sil").Value;
            ViewBag.HastaneAdi = _localization.Getkey("HastaneAdi").Value;
            if (id == null || _context.Hastane == null)
            {
                return NotFound();
            }

            var hastane = await _context.Hastane
                .FirstOrDefaultAsync(m => m.HastaneID == id);
            if (hastane == null)
            {
                return NotFound();
            }

            return View(hastane);
        }

        // POST: Hastane/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            ViewData["Poliklinikler"] = _context.Poliklinik.Where(x => x.HastaneId == id).ToList();
            ViewData["Hastane"] = _context.Hastane.FirstOrDefault(x => x.HastaneID == id);
            if (_context.Hastane == null)
            {
                return Problem("Entity set 'HastaneContext.Hastane'  is null.");
            }
            var hastane = await _context.Hastane.Include(x => x.Poliklinikler).Where(x => x.HastaneID == id).FirstOrDefaultAsync();
            
            if (hastane != null)
            {
                _context.Hastane.Remove(hastane);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HastaneExists(int id)
        {
          return (_context.Hastane?.Any(e => e.HastaneID == id)).GetValueOrDefault();
        }
    }
}