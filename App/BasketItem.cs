
namespace App
{
    public sealed class BasketItem
    {
        public int Quantity { get; set; }
        public int ProductId { get; set; }

        public BasketItem(int productId, int quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }
    }
}
