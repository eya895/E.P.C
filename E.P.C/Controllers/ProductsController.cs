using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using E.P.C.Data;
using E.P.C.Models;

namespace E.P.C.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        // =========================
        // PUBLIC ACTIONS (ANYONE)
        // =========================

        // GET: Products
        public async Task<IActionResult> Index(string searchDescription)
        {
            var products = from p in _context.Products
                           select p;

            if (!string.IsNullOrWhiteSpace(searchDescription))
            {
                products = products.Where(p => p.Description.Contains(searchDescription));
            }

            return View(await products.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);

            if (product == null)
                return NotFound();

            return View(product);
        }

        // =========================
        // ADMIN-ONLY ACTIONS
        // =========================

        // GET: Products/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("Id,Description,Price,ImageUrl")] Product product)
        {
            if (!ModelState.IsValid)
                return View(product);

            _context.Add(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Products/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return NotFound();

            return View(product);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,Price,ImageUrl")] Product product)
        {
            if (id != product.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(product);

            try
            {
                _context.Update(product);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(product.Id))
                    return NotFound();

                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Products/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);

            if (product == null)
                return NotFound();

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
                _context.Products.Remove(product);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}

