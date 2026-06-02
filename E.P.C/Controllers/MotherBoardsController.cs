using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
        public IActionResult Index(string socket)
        {
            // 1. Start with a general query that retrieves all motherboards
            IQueryable<MotherBoard> query = _context.Products.OfType<MotherBoard>();

            // 2. If a socket parameter is provided in the URL (i.e., the user came from the simulator after selecting a CPU)
            if (!string.IsNullOrEmpty(socket))
            {
                // Filter the motherboards so that only those with the exact matching socket type are displayed
                query = query.Where(m => m.SocketType == socket);

                // Save the socket type in ViewBag so we can display a nice header to the user
                ViewBag.FilteredSocket = socket;
            }

            // 3. Convert the query to a list and send it to the View
            var motherboards = query.ToList();
            return View(motherboards);
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
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: MotherBoards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
