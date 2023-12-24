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
    public class CalismaGunuController : Controller
    {
        private readonly HastaneContext _context;

        public CalismaGunuController(HastaneContext context)
        {
            _context = context;
        }

        // GET: CalismaGunu
        public async Task<IActionResult> Index()
        {
              return _context.CalismaGunu != null ? 
                          View(await _context.CalismaGunu.ToListAsync()) :
                          Problem("Entity set 'HastaneContext.CalismaGunu'  is null.");
        }

        // GET: CalismaGunu/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CalismaGunu == null)
            {
                return NotFound();
            }
            
            var calismaGunu = await _context.CalismaGunu
                .FirstOrDefaultAsync(m => m.CalismaGunID == id);
            if (calismaGunu == null)
            {
                return NotFound();
            }

            return View(calismaGunu);
        }

        // GET: CalismaGunu/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: CalismaGunu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("CalismaGunID,Gunler,Saatler,DoktorId")] CalismaGunu calismaGunu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(calismaGunu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(calismaGunu);
        }

        // GET: CalismaGunu/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CalismaGunu == null)
            {
                return NotFound();
            }

            var calismaGunu = await _context.CalismaGunu.FindAsync(id);
            if (calismaGunu == null)
            {
                return NotFound();
            }
            return View(calismaGunu);
        }

        // POST: CalismaGunu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("CalismaGunID,Gunler,Saatler,DoktorId")] CalismaGunu calismaGunu)
        {
            if (id != calismaGunu.CalismaGunID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(calismaGunu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CalismaGunuExists(calismaGunu.CalismaGunID))
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
            return View(calismaGunu);
        }

        // GET: CalismaGunu/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CalismaGunu == null)
            {
                return NotFound();
            }

            var calismaGunu = await _context.CalismaGunu
                .FirstOrDefaultAsync(m => m.CalismaGunID == id);
            if (calismaGunu == null)
            {
                return NotFound();
            }

            return View(calismaGunu);
        }

        // POST: CalismaGunu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CalismaGunu == null)
            {
                return Problem("Entity set 'HastaneContext.CalismaGunu'  is null.");
            }
            var calismaGunu = await _context.CalismaGunu.FindAsync(id);
            if (calismaGunu != null)
            {
                _context.CalismaGunu.Remove(calismaGunu);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CalismaGunuExists(int id)
        {
          return (_context.CalismaGunu?.Any(e => e.CalismaGunID == id)).GetValueOrDefault();
        }
    }
}
