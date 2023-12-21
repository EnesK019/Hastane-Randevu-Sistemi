using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HastaneRandevuSistemi.Data;
using HastaneRandevuSistemi.Models;

namespace HastaneRandevuSistemi.Controllers
{
    public class PoliklinikController : Controller
    {
        private readonly HastaneContext _context;

        public PoliklinikController(HastaneContext context)
        {
            _context = context;
        }

        // GET: Poliklinik
        public async Task<IActionResult> Index()
        {
              return _context.Poliklinik != null ? 
                          View(await _context.Poliklinik.ToListAsync()) :
                          Problem("Entity set 'HastaneContext.Poliklinik'  is null.");
        }

        // GET: Poliklinik/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Poliklinik == null)
            {
                return NotFound();
            }

            var poliklinik = await _context.Poliklinik
                .FirstOrDefaultAsync(m => m.PoliklinikID == id);
            if (poliklinik == null)
            {
                return NotFound();
            }

            return View(poliklinik);
        }

        // GET: Poliklinik/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Poliklinik/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PoliklinikID,PoliklinikAdi,HastaneId")] Poliklinik poliklinik)
        {
            if (ModelState.IsValid)
            {
                _context.Add(poliklinik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(poliklinik);
        }

        // GET: Poliklinik/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Poliklinik == null)
            {
                return NotFound();
            }

            var poliklinik = await _context.Poliklinik.FindAsync(id);
            if (poliklinik == null)
            {
                return NotFound();
            }
            return View(poliklinik);
        }

        // POST: Poliklinik/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PoliklinikID,PoliklinikAdi,HastaneId")] Poliklinik poliklinik)
        {
            if (id != poliklinik.PoliklinikID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(poliklinik);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PoliklinikExists(poliklinik.PoliklinikID))
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
            return View(poliklinik);
        }

        // GET: Poliklinik/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Poliklinik == null)
            {
                return NotFound();
            }

            var poliklinik = await _context.Poliklinik
                .FirstOrDefaultAsync(m => m.PoliklinikID == id);
            if (poliklinik == null)
            {
                return NotFound();
            }

            return View(poliklinik);
        }

        // POST: Poliklinik/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Poliklinik == null)
            {
                return Problem("Entity set 'HastaneContext.Poliklinik'  is null.");
            }
            var poliklinik = await _context.Poliklinik.FindAsync(id);
            if (poliklinik != null)
            {
                _context.Poliklinik.Remove(poliklinik);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PoliklinikExists(int id)
        {
          return (_context.Poliklinik?.Any(e => e.PoliklinikID == id)).GetValueOrDefault();
        }
    }
}
