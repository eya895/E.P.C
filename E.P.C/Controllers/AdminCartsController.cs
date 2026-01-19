using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using E.P.C.Data;

namespace E.P.C.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminCartsController : Controller
    {
        private readonly AppDbContext _context;

        public AdminCartsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: AdminCarts
        public async Task<IActionResult> Index()
        {
            var carts = await _context.ShoppingCarts
                .Include(c => c.User)
                .Include(c => c.Items)
                    .ThenInclude(i => i.Product)
                .OrderByDescending(c => c.CreatedAt)
                .ToListAsync();

            return View(carts);
        }

        // GET: AdminCarts/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var cart = await _context.ShoppingCarts
                .Include(c => c.User)
                .Include(c => c.Items)
                    .ThenInclude(i => i.Product)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (cart == null)
                return NotFound();

            return View(cart);
        }
    }
}
