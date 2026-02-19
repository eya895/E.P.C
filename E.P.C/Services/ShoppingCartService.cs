using E.P.C.Data;
using E.P.C.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

public class ShoppingCartService
{
    private readonly AppDbContext _context;
    private readonly IHttpContextAccessor _http;

    public ShoppingCartService(AppDbContext context, IHttpContextAccessor http)
    {
        _context = context;
        _http = http;
    }

    // 🔑 Get current user ID from claims
    private string GetUserId()
    {
        return _http.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
    }

    // 🔑 Find or create active cart for the current user
    public async Task<ShoppingCart> GetOrCreateCartAsync()
    {
        var userId = GetUserId();
        if (userId == null) throw new InvalidOperationException("User must be logged in.");

        var cart = await _context.ShoppingCarts
            .Include(c => c.Items)
            .ThenInclude(i => i.Product)
            .FirstOrDefaultAsync(c => c.UserId == userId && !c.IsCheckedOut);

        if (cart == null)
        {
            cart = new ShoppingCart
            {
                UserId = userId,
                CreatedAt = DateTime.UtcNow,
                IsCheckedOut = false,
                Items = new List<ShoppingCartItem>()
            };

            _context.ShoppingCarts.Add(cart);
            await _context.SaveChangesAsync();
        }

        return cart;
    }

    // 📦 Get current cart
    public async Task<ShoppingCart> GetCartAsync()
    {
        return await GetOrCreateCartAsync();
    }

    // ➕ Add a product to the cart (or increase quantity)
    public async Task AddAsync(int productId, int quantity = 1)
    {
        var cart = await GetOrCreateCartAsync();

        var item = cart.Items.FirstOrDefault(i => i.ProductId == productId);

        if (item == null)
        {
            cart.Items.Add(new ShoppingCartItem
            {
                ProductId = productId,
                Quantity = quantity
            });
        }
        else
        {
            item.Quantity += quantity;
        }

        await _context.SaveChangesAsync();
    }

    // ➖ Remove one quantity of a product
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

    // ❌ Remove all quantities of a product
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

    // ✅ Optional: Clear entire cart
    public async Task ClearCartAsync()
    {
        var cart = await GetOrCreateCartAsync();
        cart.Items.Clear();
        await _context.SaveChangesAsync();
    }
}
