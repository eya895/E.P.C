using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using E.P.C.Services;
using E.P.C.Data;

namespace E.P.C.Controllers
{
    [Authorize]
    public class ShoppingCartController : Controller
    {
        private readonly ShoppingCartService _cartService;
        private readonly AppDbContext _context;

        public ShoppingCartController(ShoppingCartService cartService, AppDbContext context)
        {
            _cartService = cartService;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var cart = await _cartService.GetOrCreateCartAsync(User);
            return View(cart);
        }

        [HttpPost]
        public async Task<IActionResult> Add(int itemId)
        {
            var cart = await _cartService.GetOrCreateCartAsync(User);

            var item = cart.Items.FirstOrDefault(i => i.ProductId == itemId);

            if (item == null)
                cart.Items.Add(new Models.ShoppingCartItem { ProductId = itemId, Quantity = 1 });
            else
                item.Quantity++;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Remove(int itemId)
        {
            var cart = await _cartService.GetOrCreateCartAsync(User);

            var item = cart.Items.FirstOrDefault(i => i.ProductId == itemId);

            if (item != null)
            {
                item.Quantity--;
                if (item.Quantity <= 0)
                    _context.ShoppingCartItems.Remove(item);

                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}

