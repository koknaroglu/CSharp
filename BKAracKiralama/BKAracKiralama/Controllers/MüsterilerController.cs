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
    public class MüsterilerController : Controller
    {
        private readonly RentalContext _context;

        public MüsterilerController(RentalContext context)
        {
            _context = context;
        }

        // GET: Müsteriler
        public async Task<IActionResult> Index()
        {
            return View(await _context.Müsteriler.ToListAsync());
        }

        // GET: Müsteriler/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var müsteri = await _context.Müsteriler
                .FirstOrDefaultAsync(m => m.ID == id);
            if (müsteri == null)
            {
                return NotFound();
            }

            return View(müsteri);
        }

        // GET: Müsteriler/Create
        public IActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,TC,Ad,Soyad,Telefon,eMail,Adres")] Müsteri müsteri)
        {
            if (ModelState.IsValid)
            {
                _context.Add(müsteri);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(müsteri);
        }

        // GET: Müsteriler/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var müsteri = await _context.Müsteriler.FindAsync(id);
            if (müsteri == null)
            {
                return NotFound();
            }
            return View(müsteri);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,TC,Ad,Soyad,Telefon,eMail,Adres")] Müsteri müsteri)
        {
            if (id != müsteri.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(müsteri);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MüsteriExists(müsteri.ID))
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
            return View(müsteri);
        }

        // GET: Müsteriler/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var müsteri = await _context.Müsteriler
                .FirstOrDefaultAsync(m => m.ID == id);
            if (müsteri == null)
            {
                return NotFound();
            }

            return View(müsteri);
        }

        // POST: Müsteriler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var müsteri = await _context.Müsteriler.FindAsync(id);
            _context.Müsteriler.Remove(müsteri);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MüsteriExists(int id)
        {
            return _context.Müsteriler.Any(e => e.ID == id);
        }
    }
}
