namespace E.P.C.Models
{
    public class ShoppingCartItem
    {
        public int Id { get; set; }

        public int ShoppingCartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }

        public int ItemId { get; set; }
        public Product Item { get; set; }

        public int Quantity { get; set; }
    }
}
