using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NguyenThanhQuan_QLThongTin_MVC.Data;
using NguyenThanhQuan_QLThongTin_MVC.Models;

namespace NguyenThanhQuan_QLThongTin_MVC.Controllers
{
    public class TinhController : Controller
    {
        private readonly QLThongTinDbContext _context;

        public TinhController(QLThongTinDbContext context)
        {
            _context = context;
        }
        // GET: Tinh
        public async Task<IActionResult> Index()
        {
              return View(await _context.Tinhs.ToListAsync());
        }

        // GET: Tinh/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tinhs == null)
            {
                return NotFound();
            }

            var tinh = await _context.Tinhs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tinh == null)
            {
                return NotFound();
            }

            return View(tinh);
        }

        // GET: Tinh/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tinh/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TenTinh")] Tinh tinh)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tinh);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tinh);
        }

        // GET: Tinh/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tinhs == null)
            {
                return NotFound();
            }

            var tinh = await _context.Tinhs.FindAsync(id);
            if (tinh == null)
            {
                return NotFound();
            }
            return View(tinh);
        }

        // POST: Tinh/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TenTinh")] Tinh tinh)
        {
            if (id != tinh.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tinh);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TinhExists(tinh.Id))
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
            return View(tinh);
        }

        // GET: Tinh/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tinhs == null)
            {
                return NotFound();
            }

            var tinh = await _context.Tinhs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tinh == null)
            {
                return NotFound();
            }

            return View(tinh);
        }

        // POST: Tinh/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tinhs == null)
            {
                return Problem("Entity set 'QLThongTinDbContext.Tinhs'  is null.");
            }
            var tinh = await _context.Tinhs.FindAsync(id);
            if (tinh != null)
            {
                _context.Tinhs.Remove(tinh);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TinhExists(int id)
        {
          return _context.Tinhs.Any(e => e.Id == id);
        }
    }
}
