using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using E.P.C.Data;
using E.P.C.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace E.P.C.Controllers
{
    public class AIOsController : Controller
    {
        private readonly AppDbContext _context;
        public AIOsController(AppDbContext context) => _context = context;

        // INDEX
        public async Task<IActionResult> Index()
        {
            return View(await _context.AIOs.ToListAsync());
        }

        // DETAILS
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var aio = await _context.AIOs.FirstOrDefaultAsync(a => a.Id == id);
            if (aio == null) return NotFound();
            return View(aio);
        }

        // CREATE GET
        public IActionResult Create() => View();

        // CREATE POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AIO aio, string[] SupportedSockets)
        {
            if (!ModelState.IsValid) return View(aio);

            aio.SupportedSockets = SupportedSockets != null ? string.Join(", ", SupportedSockets) : "";

            _context.Add(aio);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Products"); // back to Products Index
        }

        // EDIT GET
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var aio = await _context.AIOs.FindAsync(id);
            if (aio == null) return NotFound();

            return View(aio);
        }

        // EDIT POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AIO aio, string[] SupportedSockets)
        {
            if (id != aio.Id) return NotFound();
            if (!ModelState.IsValid) return View(aio);

            var dbAio = await _context.AIOs.FindAsync(id);
            if (dbAio == null) return NotFound();

            // Update all fields
            dbAio.Brand = aio.Brand;
            dbAio.Model = aio.Model;
            dbAio.RadiatorSize = aio.RadiatorSize;
            dbAio.PumpSpeed = aio.PumpSpeed;
            dbAio.FanSize = aio.FanSize;
            dbAio.FanRPM = aio.FanRPM;
            dbAio.NoiseLevel = aio.NoiseLevel;
            dbAio.Description = aio.Description;
            dbAio.Price = aio.Price;
            dbAio.ImageUrl = aio.ImageUrl;
            dbAio.SupportedSockets = SupportedSockets != null ? string.Join(", ", SupportedSockets) : "";

            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Products"); // back to Products Index
        }

        // DELETE GET
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var aio = await _context.AIOs.FirstOrDefaultAsync(a => a.Id == id);
            if (aio == null) return NotFound();

            return View(aio);
        }

        // DELETE POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aio = await _context.AIOs.FindAsync(id);
            if (aio != null)
            {
                _context.AIOs.Remove(aio);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index", "Products");
        }
    }
}
