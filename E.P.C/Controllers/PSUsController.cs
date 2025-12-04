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
    public class PSUsController : Controller
    {
        private readonly AppDbContext _context;

        public PSUsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: PSUs
        public async Task<IActionResult> Index()
        {
            return View(await _context.PSUs.ToListAsync());
        }

        // GET: PSUs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pSU = await _context.PSUs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pSU == null)
            {
                return NotFound();
            }

            return View(pSU);
        }

        // GET: PSUs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PSUs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Brand,Model,Wattage,EfficiencyRating,FormFactor,Modular,Connectors,Id,Description,Price,ImageUrl")] PSU pSU)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pSU);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pSU);
        }

        // GET: PSUs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pSU = await _context.PSUs.FindAsync(id);
            if (pSU == null)
            {
                return NotFound();
            }
            return View(pSU);
        }

        // POST: PSUs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Brand,Model,Wattage,EfficiencyRating,FormFactor,Modular,Connectors,Id,Description,Price,ImageUrl")] PSU pSU)
        {
            if (id != pSU.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pSU);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PSUExists(pSU.Id))
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
            return View(pSU);
        }

        // GET: PSUs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pSU = await _context.PSUs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pSU == null)
            {
                return NotFound();
            }

            return View(pSU);
        }

        // POST: PSUs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pSU = await _context.PSUs.FindAsync(id);
            if (pSU != null)
            {
                _context.PSUs.Remove(pSU);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PSUExists(int id)
        {
            return _context.PSUs.Any(e => e.Id == id);
        }
    }
}
