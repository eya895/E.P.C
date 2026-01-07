using Microsoft.AspNetCore.Identity;

namespace E.P.C.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }

        // Link cart to logged-in user
        public string UserId { get; set; }
        public IdentityUser User { get; set; }

        public ICollection<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>();

        public double TotalPrice =>Items.Sum(i => i.Product.Price * i.Quantity);
    }
}