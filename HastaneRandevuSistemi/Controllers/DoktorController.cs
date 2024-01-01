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

namespace Hastane_Randevu_Sistemi.Controllers
{
    public class DoktorController : Controller
    {
        private readonly HastaneContext _context;

        public DoktorController(HastaneContext context)
        {
            _context = context;
        }

        // GET: Doktor
        public async Task<IActionResult> Index()
        {
            ViewData["Poliklinikler"] = _context.Poliklinik.ToList();
            return _context.Doktor != null ? 
                          View(await _context.Doktor.ToListAsync()) :
                          Problem("Entity set 'HastaneContext.Doktor'  is null.");
        }

        // GET: Doktor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ViewData["Poliklinikler"] = _context.Poliklinik.ToList();
            ViewData["Hastaneler"] = _context.Hastane.ToList();
            if (id == null || _context.Doktor == null)
            {
                return NotFound();
            }

            var doktor = await _context.Doktor
                .FirstOrDefaultAsync(m => m.DoktorID == id);
            if (doktor == null)
            {
                return NotFound();
            }

            return View(doktor);
        }

        public async Task<IActionResult> GetPoliklinikler(int hastaneId)
        {
            var poliklinikler = await _context.Poliklinik.Where(p => p.HastaneId == hastaneId).ToListAsync();
            return Json(poliklinikler);
        }

        // GET: Doktor/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["Hastaneler"] = _context.Hastane.ToList();
            var poliklinikler = _context.Poliklinik.ToList();
            
            ViewData["Poliklinikler"] = poliklinikler;
            return View();
        }

        // POST: Doktor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(Doktor doktor)
        {
            doktor.IsActive = true;
            if (ModelState.IsValid)
            {  
                _context.Add(doktor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(doktor);
        }

        [Authorize(Roles = "Admin")]
        // GET: Doktor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
			ViewData["Hastaneler"] = _context.Hastane.ToList();
			
			ViewData["Poliklinikler"] = _context.Poliklinik.ToList();
            if (id == null || _context.Doktor == null)
            {
                return NotFound();
            }

            var doktor = await _context.Doktor.FindAsync(id);
            if (doktor == null)
            {
                return NotFound();
            }
            return View(doktor);
        }

        // POST: Doktor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, Doktor doktor)
        {
            if (id != doktor.DoktorID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doktor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoktorExists(doktor.DoktorID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(doktor);
        }

        // GET: Doktor/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Doktor == null)
            {
                return NotFound();
            }

            var doktor = await _context.Doktor
                .FirstOrDefaultAsync(m => m.DoktorID == id);
            if (doktor == null)
            {
                return NotFound();
            }

            return View(doktor);
        }

        // POST: Doktor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Doktor == null)
            {
                return Problem("Entity set 'HastaneContext.Doktor'  is null.");
            }
            var doktor = await _context.Doktor.Include(x => x.Randevular).Where(x => x.DoktorID == id).FirstOrDefaultAsync(); ;
            if (doktor != null)
            {
                _context.Doktor.Remove(doktor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoktorExists(int id)
        {
          return (_context.Doktor?.Any(e => e.DoktorID == id)).GetValueOrDefault();
        }
    }
}
