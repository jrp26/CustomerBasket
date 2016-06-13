
namespace Price.Entities
{
    public sealed class Reward
    {
        public double Amount { get; set; }

        public Reward(double amount)
        {
            Amount = amount;
        }
    }
}
