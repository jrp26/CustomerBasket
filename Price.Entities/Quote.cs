
namespace Price.Entities
{
    public sealed class Quote
    {
        public Quote(double total)
        {
            Total = total;
        }

        public double Total { get; private set; }
    }
}
