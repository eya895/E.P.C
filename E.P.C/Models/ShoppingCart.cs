using Microsoft.AspNetCore.Identity;

namespace E.P.C.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        public IdentityUser User { get; set; }

        public ICollection<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>();

        // 🔑 NEW
        public bool IsCheckedOut { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? CheckedOutAt { get; set; }

        public double TotalPrice =>
            Items.Sum(i => i.Product.Price * i.Quantity);
    }
}