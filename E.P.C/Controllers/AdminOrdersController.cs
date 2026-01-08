using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using E.P.C.Data;

namespace E.P.C.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminOrdersController : Controller
    {
        private readonly AppDbContext _context;

        public AdminOrdersController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var orders = await _context.Orders
                .Include(o => o.User)
                .Include(o => o.Items)
                    .ThenInclude(i => i.Product)
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();

            return View(orders);
        }
    }
}

