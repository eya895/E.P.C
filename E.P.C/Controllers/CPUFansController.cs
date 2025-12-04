using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using E.P.C.Data;
using E.P.C.Models;

namespace E.P.C.Controllers
{
    public class CPUFansController : Controller
    {
        private readonly AppDbContext _context;

        public CPUFansController(AppDbContext context)
        {
            _context = context;
        }

        // GET: CPUFans
        public async Task<IActionResult> Index()
        {
            return View(await _context.CPUFans.ToListAsync());
        }

        // GET: CPUFans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cPUFan = await _context.CPUFans
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cPUFan == null)
            {
                return NotFound();
            }

            return View(cPUFan);
        }

        // GET: CPUFans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CPUFans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Brand,Model,Size,RPM,Airflow,NoiseLevel,ConnectorType,SupportedSockets,Id,Description,Price,ImageUrl")] CPUFan cPUFan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cPUFan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cPUFan);
        }

        // GET: CPUFans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cPUFan = await _context.CPUFans.FindAsync(id);
            if (cPUFan == null)
            {
                return NotFound();
            }
            return View(cPUFan);
        }

        // POST: CPUFans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Brand,Model,Size,RPM,Airflow,NoiseLevel,ConnectorType,SupportedSockets,Id,Description,Price,ImageUrl")] CPUFan cPUFan)
        {
            if (id != cPUFan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cPUFan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CPUFanExists(cPUFan.Id))
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
            return View(cPUFan);
        }

        // GET: CPUFans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cPUFan = await _context.CPUFans
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cPUFan == null)
            {
                return NotFound();
            }

            return View(cPUFan);
        }

        // POST: CPUFans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cPUFan = await _context.CPUFans.FindAsync(id);
            if (cPUFan != null)
            {
                _context.CPUFans.Remove(cPUFan);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CPUFanExists(int id)
        {
            return _context.CPUFans.Any(e => e.Id == id);
        }
    }
}
