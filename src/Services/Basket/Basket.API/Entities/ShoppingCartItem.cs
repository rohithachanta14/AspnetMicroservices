namespace Basket.API.Entities
{
    public class ShoppingCartItem
    {
        public ShoppingCartItem() { }

        public int Quantity { get; set; }
        public string Colour { get; set; }
        public decimal Price { get; set; }
        public string ProductID { get; set; }
        public string ProductName { get; set; }
    }
}