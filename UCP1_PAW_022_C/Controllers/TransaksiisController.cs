using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UCP1_PAW_022_C.Models;

namespace UCP1_PAW_022_C.Controllers
{
    public class TransaksiisController : Controller
    {
        private readonly BelanjakuContext _context;

        public TransaksiisController(BelanjakuContext context)
        {
            _context = context;
        }

        // GET: Transaksiis
        public async Task<IActionResult> Index()
        {
            var belanjakuContext = _context.Transaksiis.Include(t => t.IdBarangNavigation).Include(t => t.IdKasirNavigation).Include(t => t.IdPembeliNavigation);
            return View(await belanjakuContext.ToListAsync());
        }

        // GET: Transaksiis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaksii = await _context.Transaksiis
                .Include(t => t.IdBarangNavigation)
                .Include(t => t.IdKasirNavigation)
                .Include(t => t.IdPembeliNavigation)
                .FirstOrDefaultAsync(m => m.IdTransaksi == id);
            if (transaksii == null)
            {
                return NotFound();
            }

            return View(transaksii);
        }

        // GET: Transaksiis/Create
        public IActionResult Create()
        {
            ViewData["IdBarang"] = new SelectList(_context.Barangs, "IdBarang", "IdBarang");
            ViewData["IdKasir"] = new SelectList(_context.Kasirs, "IdKasir", "IdKasir");
            ViewData["IdPembeli"] = new SelectList(_context.Pembelis, "IdPembeli", "IdPembeli");
            return View();
        }

        // POST: Transaksiis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTransaksi,JmlTransaksi,UangBayar,UangKembali,IdBarang,IdPembeli,IdKasir")] Transaksii transaksii)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transaksii);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdBarang"] = new SelectList(_context.Barangs, "IdBarang", "IdBarang", transaksii.IdBarang);
            ViewData["IdKasir"] = new SelectList(_context.Kasirs, "IdKasir", "IdKasir", transaksii.IdKasir);
            ViewData["IdPembeli"] = new SelectList(_context.Pembelis, "IdPembeli", "IdPembeli", transaksii.IdPembeli);
            return View(transaksii);
        }

        // GET: Transaksiis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaksii = await _context.Transaksiis.FindAsync(id);
            if (transaksii == null)
            {
                return NotFound();
            }
            ViewData["IdBarang"] = new SelectList(_context.Barangs, "IdBarang", "IdBarang", transaksii.IdBarang);
            ViewData["IdKasir"] = new SelectList(_context.Kasirs, "IdKasir", "IdKasir", transaksii.IdKasir);
            ViewData["IdPembeli"] = new SelectList(_context.Pembelis, "IdPembeli", "IdPembeli", transaksii.IdPembeli);
            return View(transaksii);
        }

        // POST: Transaksiis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTransaksi,JmlTransaksi,UangBayar,UangKembali,IdBarang,IdPembeli,IdKasir")] Transaksii transaksii)
        {
            if (id != transaksii.IdTransaksi)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transaksii);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransaksiiExists(transaksii.IdTransaksi))
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
            ViewData["IdBarang"] = new SelectList(_context.Barangs, "IdBarang", "IdBarang", transaksii.IdBarang);
            ViewData["IdKasir"] = new SelectList(_context.Kasirs, "IdKasir", "IdKasir", transaksii.IdKasir);
            ViewData["IdPembeli"] = new SelectList(_context.Pembelis, "IdPembeli", "IdPembeli", transaksii.IdPembeli);
            return View(transaksii);
        }

        // GET: Transaksiis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaksii = await _context.Transaksiis
                .Include(t => t.IdBarangNavigation)
                .Include(t => t.IdKasirNavigation)
                .Include(t => t.IdPembeliNavigation)
                .FirstOrDefaultAsync(m => m.IdTransaksi == id);
            if (transaksii == null)
            {
                return NotFound();
            }

            return View(transaksii);
        }

        // POST: Transaksiis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transaksii = await _context.Transaksiis.FindAsync(id);
            _context.Transaksiis.Remove(transaksii);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransaksiiExists(int id)
        {
            return _context.Transaksiis.Any(e => e.IdTransaksi == id);
        }
    }
}
