using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using COMP2084MidtermF2019.Models;

namespace COMP2084MidtermF2019.Controllers
{
    public class RidingsController : Controller
    {
        private readonly f19Context _context;

        public RidingsController(f19Context context)
        {
            _context = context;
        }

        // GET: Ridings
        public async Task<IActionResult> Index()
        {
            return View(await _context.Riding.ToListAsync());
        }

        // GET: Ridings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var riding = await _context.Riding
                .FirstOrDefaultAsync(m => m.RidingId == id);
            if (riding == null)
            {
                return NotFound();
            }

            return View(riding);
        }

        // GET: Ridings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ridings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RidingId,Name")] Riding riding)
        {
            if (ModelState.IsValid)
            {
                _context.Add(riding);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(riding);
        }

        // GET: Ridings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var riding = await _context.Riding.FindAsync(id);
            if (riding == null)
            {
                return NotFound();
            }
            return View(riding);
        }

        // POST: Ridings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RidingId,Name")] Riding riding)
        {
            if (id != riding.RidingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(riding);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RidingExists(riding.RidingId))
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
            return View(riding);
        }

        // GET: Ridings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var riding = await _context.Riding
                .FirstOrDefaultAsync(m => m.RidingId == id);
            if (riding == null)
            {
                return NotFound();
            }

            return View(riding);
        }

        // POST: Ridings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var riding = await _context.Riding.FindAsync(id);
            _context.Riding.Remove(riding);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RidingExists(int id)
        {
            return _context.Riding.Any(e => e.RidingId == id);
        }
    }
}
