using System.Collections.Generic;

namespace Price.Evaluators
{
    public sealed class CostEvaluator : IEvaluator
    {
        Entities.Cost Cost { get; set; }

        public CostEvaluator(Entities.Cost cost)
        {
            Cost = cost;
        }

        public double Evaluate(IList<Entities.Product> products)
        {
            double response = 0;
            foreach(Entities.Product p in products)
            {
                if(p.ProductId == Cost.ProductId)
                {
                    response += Cost.Amount * p.Quantity;
                }
            }
            return response;
        }
    }
}
