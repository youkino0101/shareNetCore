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
    public class HuyenController : Controller
    {
        private readonly QLThongTinDbContext _context;

        public HuyenController(QLThongTinDbContext context)
        {
            _context = context;
        }

        // GET: Huyen
        public async Task<IActionResult> Index(string? key = "")
        {
            if (key == null || key == "")
            {
                var qLThongTinDbContext = _context.Huyens.Include(h => h.Tinh);
                return View(await qLThongTinDbContext.ToListAsync());
            } else
            {
                IEnumerable < Huyen > lstHuyen= _context.Huyens.Where(h => h.TenHuyen.Contains(key));
                return View(lstHuyen);

                //var qLThongTinDbContext = _context.Huyens.Include(h => h.Tinh);

                //List<Huyen> newList = new List<Huyen>();

                //foreach(Huyen huyen in qLThongTinDbContext)
                //{
                //    if (huyen.IdTinh == id)
                //    {
                //        newList.Add(huyen);
                //    }
                //}
                //return View(newList);
            }
        }

        // GET: Huyen/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Huyens == null)
            {
                return NotFound();
            }

            var huyen = await _context.Huyens
                .Include(h => h.Tinh)
                .FirstOrDefaultAsync(m => m.IdHuyen == id);
            if (huyen == null)
            {
                return NotFound();
            }

            return View(huyen);
        }

        // GET: Huyen/Create
        public IActionResult Create()
        {
            ViewData["IdTinh"] = new SelectList(_context.Tinhs, "Id", "TenTinh");
            return View();
        }

        // POST: Huyen/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdHuyen,TenHuyen,IdTinh")] Huyen huyen)
        {
            if (ModelState.IsValid)
            {
                _context.Add(huyen);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdTinh"] = new SelectList(_context.Tinhs, "Id", "TenTinh", huyen.IdTinh);
            return View(huyen);
        }

        // GET: Huyen/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Huyens == null)
            {
                return NotFound();
            }

            var huyen = await _context.Huyens.FindAsync(id);
            if (huyen == null)
            {
                return NotFound();
            }
            ViewData["IdTinh"] = new SelectList(_context.Tinhs, "Id", "TenTinh", huyen.IdTinh);
            return View(huyen);
        }

        // POST: Huyen/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdHuyen,TenHuyen,IdTinh")] Huyen huyen)
        {
            if (id != huyen.IdHuyen)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(huyen);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HuyenExists(huyen.IdHuyen))
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
            ViewData["IdTinh"] = new SelectList(_context.Tinhs, "Id", "TenTinh", huyen.IdTinh);
            return View(huyen);
        }

        // GET: Huyen/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Huyens == null)
            {
                return NotFound();
            }

            var huyen = await _context.Huyens
                .Include(h => h.Tinh)
                .FirstOrDefaultAsync(m => m.IdHuyen == id);
            if (huyen == null)
            {
                return NotFound();
            }

            return View(huyen);
        }

        // POST: Huyen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Huyens == null)
            {
                return Problem("Entity set 'QLThongTinDbContext.Huyens'  is null.");
            }
            var huyen = await _context.Huyens.FindAsync(id);
            if (huyen != null)
            {
                _context.Huyens.Remove(huyen);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HuyenExists(int id)
        {
          return _context.Huyens.Any(e => e.IdHuyen == id);
        }
    }
}
