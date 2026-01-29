using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using E.P.C.Data;

namespace E.P.C.Controllers
{
    [Authorize]
    public class ShoppingCartController : Controller
    {
        private readonly ShoppingCartService _cart;

        public ShoppingCartController(ShoppingCartService cart)
        {
            _cart = cart;
        }

        public async Task<IActionResult> Index()
        {
            var cart =  await _cart.GetCartAsync();
            return View(cart);
        }

        [HttpPost]
        public async Task<IActionResult> Add(int itemId)
        {
            await _cart.AddAsync(itemId);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public  async Task<IActionResult> RemoveAsync(int itemId)
        {
             await _cart.RemoveAsync(itemId);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveAll(int itemId)
        {
            await _cart.RemoveAllAsync(itemId);
            return RedirectToAction(nameof(Index));
        }
    }
}

