using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hastane_Randevu_Sistemi.Models;

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
        public async Task<IActionResult> Index()
        {
              return _context.Hastaneler != null ? 
                          View(await _context.Hastaneler.ToListAsync()) :
                          Problem("Entity set 'HastaneContext.Hastaneler'  is null.");
        }

        // GET: Hastane/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Hastaneler == null)
            {
                return NotFound();
            }

            var hastane = await _context.Hastaneler
                .FirstOrDefaultAsync(m => m.HastaneID == id);
            if (hastane == null)
            {
                return NotFound();
            }

            return View(hastane);
        }

        // GET: Hastane/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hastane/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HastaneID,HastaneAdi")] Hastane hastane)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hastane);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hastane);
        }

        // GET: Hastane/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Hastaneler == null)
            {
                return NotFound();
            }

            var hastane = await _context.Hastaneler.FindAsync(id);
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
        public async Task<IActionResult> Edit(int id, [Bind("HastaneID,HastaneAdi")] Hastane hastane)
        {
            if (id != hastane.HastaneID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hastane);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HastaneExists(hastane.HastaneID))
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
            return View(hastane);
        }

        // GET: Hastane/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Hastaneler == null)
            {
                return NotFound();
            }

            var hastane = await _context.Hastaneler
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
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Hastaneler == null)
            {
                return Problem("Entity set 'HastaneContext.Hastaneler'  is null.");
            }
            var hastane = await _context.Hastaneler.FindAsync(id);
            if (hastane != null)
            {
                _context.Hastaneler.Remove(hastane);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HastaneExists(int id)
        {
          return (_context.Hastaneler?.Any(e => e.HastaneID == id)).GetValueOrDefault();
        }
    }
}
