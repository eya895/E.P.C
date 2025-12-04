using System.ComponentModel.DataAnnotations;

namespace E.P.C.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public List<Product> Products { get; set; } = new List<Product>();

    }
}
