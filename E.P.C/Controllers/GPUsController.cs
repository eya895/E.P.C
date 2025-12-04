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
    public class GPUsController : Controller
    {
        private readonly AppDbContext _context;

        public GPUsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: GPUs
        public async Task<IActionResult> Index()
        {
            return View(await _context.GPUs.ToListAsync());
        }

        // GET: GPUs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gPU = await _context.GPUs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gPU == null)
            {
                return NotFound();
            }

            return View(gPU);
        }

        // GET: GPUs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GPUs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Brand,Model,Chipset,MemorySize,MemoryType,CoreClock,BoostClock,TDP,Interface,dimensions,Ports,Id,Description,Price,ImageUrl")] GPU gPU)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gPU);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gPU);
        }

        // GET: GPUs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gPU = await _context.GPUs.FindAsync(id);
            if (gPU == null)
            {
                return NotFound();
            }
            return View(gPU);
        }

        // POST: GPUs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Brand,Model,Chipset,MemorySize,MemoryType,CoreClock,BoostClock,TDP,Interface,dimensions,Ports,Id,Description,Price,ImageUrl")] GPU gPU)
        {
            if (id != gPU.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gPU);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GPUExists(gPU.Id))
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
            return View(gPU);
        }

        // GET: GPUs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gPU = await _context.GPUs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gPU == null)
            {
                return NotFound();
            }

            return View(gPU);
        }

        // POST: GPUs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gPU = await _context.GPUs.FindAsync(id);
            if (gPU != null)
            {
                _context.GPUs.Remove(gPU);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GPUExists(int id)
        {
            return _context.GPUs.Any(e => e.Id == id);
        }
    }
}
