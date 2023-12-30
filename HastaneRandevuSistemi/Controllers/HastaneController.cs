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

namespace Hastane_Randevu_Sistemi.Controllers
{
    public class HastaneController : Controller
    {
        private readonly HastaneContext _context;

        public HastaneController(HastaneContext context)
        {
            _context = context;
        }

        // GET: Hastane
        //public async Task<IActionResult> Index()
        //{
        //      return _context.Hastane != null ? 
        //                  View(await _context.Hastane.ToListAsync()) :
        //                  Problem("Entity set 'HastaneContext.Hastane'  is null.");
        //}




        public async Task<IActionResult> Index()
        {
            List<Hastane> hastaneler = new List<Hastane>();
            HttpClient client = new HttpClient();
            var response = await client.GetAsync("https://localhost:7025/api/HastaneApi");
            var jsonResponse = await response.Content.ReadAsStringAsync();
            hastaneler = JsonConvert.DeserializeObject<List<Hastane>>(jsonResponse);

            return View(hastaneler);
        }




        // GET: Hastane/Details/5

        public async Task<IActionResult> Details(int? id)
        {
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

            //Engin Demiroğ izle ve yap
			HttpClient client = new HttpClient();
			var json = JsonConvert.SerializeObject(hastane);
			var content = new StringContent(json, Encoding.UTF8, "application/json");

			var response = await client.PostAsync("https://localhost:7025/api/HastaneApi/", content);
			var jsonResponse = await response.Content.ReadAsStringAsync();
			hastane = JsonConvert.DeserializeObject<Hastane>(jsonResponse);
			return View(hastane);
        }

        // GET: Hastane/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
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

			return View(hastane);
		}

		// GET: Hastane/Delete/5
		[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
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

            if (_context.Hastane == null)
            {
                return Problem("Entity set 'HastaneContext.Hastane'  is null.");
            }
            var hastane = await _context.Hastane.FindAsync(id);
            
            if (hastane != null)
            {
                _context.Hastane.Remove(hastane);
                //DENENMEDİ
                //var silinecekPoliklinikler = _context.Poliklinik.Where(x => x.HastaneId == hastane.HastaneID).ToList();
                //for(int i = 0; i < silinecekPoliklinikler.Count; i++)
                //    silinecekPoliklinikler.RemoveAt(0);
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