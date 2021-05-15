using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BKAracKiralama.Data;
using BKAracKiralama.Models;

namespace BKAracKiralama.Controllers
{
    public class AraclarController : Controller
    {
        private readonly RentalContext _context;

        public AraclarController(RentalContext context)
        {
            _context = context;
        }

        // GET: Araclar
        public async Task<IActionResult> Index()
        {
            return View(await _context.Araclar.ToListAsync());
        }

        // GET: Araclar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arac = await _context.Araclar
                .FirstOrDefaultAsync(m => m.ID == id);
            if (arac == null)
            {
                return NotFound();
            }

            return View(arac);
        }

        // GET: Araclar/Create
        public IActionResult Create()
        {
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Plaka,Marka,Model,Yıl,Renk,GünlükÜcret,Cins")] Arac arac)
        {
            if (ModelState.IsValid)
            {
                _context.Add(arac);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(arac);
        }

        // GET: Araclar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arac = await _context.Araclar.FindAsync(id);
            if (arac == null)
            {
                return NotFound();
            }
            return View(arac);
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Plaka,Marka,Model,Yıl,Renk,GünlükÜcret,Cins")] Arac arac)
        {
            if (id != arac.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(arac);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AracExists(arac.ID))
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
            return View(arac);
        }

        // GET: Araclar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arac = await _context.Araclar
                .FirstOrDefaultAsync(m => m.ID == id);
            if (arac == null)
            {
                return NotFound();
            }

            return View(arac);
        }

        //  Araclar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var arac = await _context.Araclar.FindAsync(id);
            _context.Araclar.Remove(arac);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AracExists(int id)
        {
            return _context.Araclar.Any(e => e.ID == id);
        }
    }
}
