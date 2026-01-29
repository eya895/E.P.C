using E.P.C.Data;
using E.P.C.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

public class ShoppingCartService
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _http;

        public ShoppingCartService(
            AppDbContext context,
            IHttpContextAccessor http)
        {
            _context = context;
            _http = http;
        }

    // 🔑 Find or create active cart
    public async Task<ShoppingCart> GetOrCreateCartAsync()
    {
        var userId = _http.HttpContext.User
            .FindFirstValue(ClaimTypes.NameIdentifier);

        var cart = await _context.ShoppingCarts
            .Include(c => c.Items)
            .ThenInclude(i => i.Product)
            .FirstOrDefaultAsync(c => c.UserId == userId && !c.IsCheckedOut);

        if (cart == null)
        {
            cart = new ShoppingCart
            {
                UserId = userId,
                CreatedAt = DateTime.Now,
                IsCheckedOut = false,
                Items = new List<ShoppingCartItem>()
            };

            _context.ShoppingCarts.Add(cart);
            await _context.SaveChangesAsync();
        }

        return cart;
    }

    // 📦 Used by ShoppingCartController.Index
    public async Task<ShoppingCart> GetCartAsync()
    {
        return await GetOrCreateCartAsync();
    }

    // ➕ Add item
    public async Task AddAsync(int productId)
    {
        var cart = await GetOrCreateCartAsync();

        var item = cart.Items.FirstOrDefault(i => i.ProductId == productId);

        if (item == null)
            cart.Items.Add(new ShoppingCartItem { ProductId = productId, Quantity = 1 });
        else
            item.Quantity++;

        await _context.SaveChangesAsync();
    }

    // ➖ Remove ONE quantity
    public async Task RemoveAsync(int productId)
    {
        var cart = await GetOrCreateCartAsync();

        var item = cart.Items.FirstOrDefault(i => i.ProductId == productId);
        if (item == null) return;

        if (item.Quantity > 1)
            item.Quantity--;
        else
            cart.Items.Remove(item);

        await _context.SaveChangesAsync();
    }

    // ❌ Remove ALL quantities of an item
    public async Task RemoveAllAsync(int productId)
    {
        var cart = await GetOrCreateCartAsync();

        var item = cart.Items.FirstOrDefault(i => i.ProductId == productId);
        if (item != null)
        {
            cart.Items.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}

