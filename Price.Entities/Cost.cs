
namespace Price.Entities
{
    public sealed class Cost
    {
        public int ProductId { get; set; }
        public double Amount { get; set; }

        public Cost(int productId, double amount)
        {
            ProductId = productId;
            Amount = amount;
        }
    }
}
