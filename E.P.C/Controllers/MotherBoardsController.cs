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
    public class MotherBoardsController : Controller
    {
        private readonly AppDbContext _context;

        public MotherBoardsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: MotherBoards
        public async Task<IActionResult> Index()
        {
            return View(await _context.MotherBoards.ToListAsync());
        }

        // GET: MotherBoards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motherBoard = await _context.MotherBoards
                .FirstOrDefaultAsync(m => m.Id == id);
            if (motherBoard == null)
            {
                return NotFound();
            }

            return View(motherBoard);
        }

        // GET: MotherBoards/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MotherBoards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Brand,Model,Chipset,SocketType,RAMSlots,MaxRAMCapacity,FormFactor,Id,Description,Price,ImageUrl")] MotherBoard motherBoard)
        {
            if (ModelState.IsValid)
            {
                _context.Add(motherBoard);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(motherBoard);
        }

        // GET: MotherBoards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motherBoard = await _context.MotherBoards.FindAsync(id);
            if (motherBoard == null)
            {
                return NotFound();
            }
            return View(motherBoard);
        }

        // POST: MotherBoards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Brand,Model,Chipset,SocketType,RAMSlots,MaxRAMCapacity,FormFactor,Id,Description,Price,ImageUrl")] MotherBoard motherBoard)
        {
            if (id != motherBoard.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(motherBoard);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MotherBoardExists(motherBoard.Id))
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
            return View(motherBoard);
        }

        // GET: MotherBoards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motherBoard = await _context.MotherBoards
                .FirstOrDefaultAsync(m => m.Id == id);
            if (motherBoard == null)
            {
                return NotFound();
            }

            return View(motherBoard);
        }

        // POST: MotherBoards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var motherBoard = await _context.MotherBoards.FindAsync(id);
            if (motherBoard != null)
            {
                _context.MotherBoards.Remove(motherBoard);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MotherBoardExists(int id)
        {
            return _context.MotherBoards.Any(e => e.Id == id);
        }
    }
}
