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
    public class AIOsController : Controller
    {
        private readonly AppDbContext _context;

        public AIOsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: AIOs
        public async Task<IActionResult> Index()
        {
            return View(await _context.AIOs.ToListAsync());
        }

        // GET: AIOs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aIO = await _context.AIOs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aIO == null)
            {
                return NotFound();
            }

            return View(aIO);
        }

        // GET: AIOs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AIOs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Brand,Model,RadiatorSize,PumpSpeed,FanSize,FanRPM,NoiseLevel,SupportedSockets,Id,Description,Price,ImageUrl")] AIO aIO)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aIO);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aIO);
        }

        // GET: AIOs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aIO = await _context.AIOs.FindAsync(id);
            if (aIO == null)
            {
                return NotFound();
            }
            return View(aIO);
        }

        // POST: AIOs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Brand,Model,RadiatorSize,PumpSpeed,FanSize,FanRPM,NoiseLevel,SupportedSockets,Id,Description,Price,ImageUrl")] AIO aIO)
        {
            if (id != aIO.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aIO);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AIOExists(aIO.Id))
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
            return View(aIO);
        }

        // GET: AIOs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aIO = await _context.AIOs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aIO == null)
            {
                return NotFound();
            }

            return View(aIO);
        }

        // POST: AIOs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aIO = await _context.AIOs.FindAsync(id);
            if (aIO != null)
            {
                _context.AIOs.Remove(aIO);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AIOExists(int id)
        {
            return _context.AIOs.Any(e => e.Id == id);
        }
    }
}
