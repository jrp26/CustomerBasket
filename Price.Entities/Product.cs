
namespace Price.Entities
{
    public sealed class Product
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        
        public Product(int productId, int quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }
    }
}
