using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BKAracKiralama.Data;
using BKAracKiralama.Models;

namespace BKAracKiralama.Views.Kiralamalar
{
    public class KiralamalarController : Controller
    {
        private readonly RentalContext _context;

        public KiralamalarController(RentalContext context)
        {
            _context = context;
        }

        // GET: Kiralamalar
        public async Task<IActionResult> Index()
        {
            var rentalContext = _context.Kiralamalar.Include(k => k.Arac).Include(k => k.Müsteri);
            return View(await rentalContext.ToListAsync());
        }

        // GET: Kiralamalar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kiralama = await _context.Kiralamalar
                .Include(k => k.Arac)
                .Include(k => k.Müsteri)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (kiralama == null)
            {
                return NotFound();
            }

            return View(kiralama);
        }

        // GET: Kiralamalar/Create
        public IActionResult Create()
        {
            ViewData["AracID"] = new SelectList(_context.Araclar, "ID", "ID");
            ViewData["MüsteriID"] = new SelectList(_context.Müsteriler, "ID", "ID");
            return View();
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,AlışGünü,GeriTeslimGünü,MüsteriID,AracID")] Kiralama kiralama)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kiralama);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AracID"] = new SelectList(_context.Araclar, "ID", "ID", kiralama.AracID);
            ViewData["MüsteriID"] = new SelectList(_context.Müsteriler, "ID", "ID", kiralama.MüsteriID);
            return View(kiralama);
        }

        // GET: Kiralamalar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kiralama = await _context.Kiralamalar.FindAsync(id);
            if (kiralama == null)
            {
                return NotFound();
            }
            ViewData["AracID"] = new SelectList(_context.Araclar, "ID", "ID", kiralama.AracID);
            ViewData["MüsteriID"] = new SelectList(_context.Müsteriler, "ID", "ID", kiralama.MüsteriID);
            return View(kiralama);
        }

 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,AlışGünü,GeriTeslimGünü,MüsteriID,AracID")] Kiralama kiralama)
        {
            if (id != kiralama.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kiralama);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KiralamaExists(kiralama.ID))
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
            ViewData["AracID"] = new SelectList(_context.Araclar, "ID", "ID", kiralama.AracID);
            ViewData["MüsteriID"] = new SelectList(_context.Müsteriler, "ID", "ID", kiralama.MüsteriID);
            return View(kiralama);
        }

        // GET: Kiralamalar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kiralama = await _context.Kiralamalar
                .Include(k => k.Arac)
                .Include(k => k.Müsteri)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (kiralama == null)
            {
                return NotFound();
            }

            return View(kiralama);
        }

        // POST: Kiralamalar/Delete/5
        [HttpPost, ActionName("Sil")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kiralama = await _context.Kiralamalar.FindAsync(id);
            _context.Kiralamalar.Remove(kiralama);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KiralamaExists(int id)
        {
            return _context.Kiralamalar.Any(e => e.ID == id);
        }
    }
}
