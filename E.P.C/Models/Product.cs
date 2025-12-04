using System.ComponentModel.DataAnnotations;

namespace E.P.C.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
    }
}
