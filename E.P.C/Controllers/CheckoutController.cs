using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using E.P.C.Services;
using E.P.C.Data;
using E.P.C.Models;

namespace E.P.C.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        private readonly ShoppingCartService _cartService;
        private readonly AppDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public CheckoutController(
            ShoppingCartService cartService,
            AppDbContext context,
            UserManager<IdentityUser> userManager)
        {
            _cartService = cartService;
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var cart = await _cartService.GetOrCreateCartAsync(User);

            if (!cart.Items.Any())
                return RedirectToAction("Index", "ShoppingCart");

            return View(cart);
        }

        [HttpPost]
        public async Task<IActionResult> PlaceOrder()
        {
            var cart = await _cartService.GetOrCreateCartAsync(User);
            var userId = _userManager.GetUserId(User);

            if (!cart.Items.Any())
                return RedirectToAction("Index", "ShoppingCart");

            var order = new Order
            {
                UserId = userId,
                TotalPrice = cart.TotalPrice
            };

            foreach (var cartItem in cart.Items)
            {
                order.Items.Add(new OrderItem
                {
                    ProductId = cartItem.ProductId,
                    Quantity = cartItem.Quantity,
                    PriceAtPurchase = cartItem.Product.Price
                });
            }

            _context.Orders.Add(order);

            _context.ShoppingCartItems.RemoveRange(cart.Items);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Success));
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}

