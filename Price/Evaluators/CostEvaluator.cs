using System.Collections.Generic;

namespace Price.Evaluators
{
    public sealed class CostEvaluator : IEvaluator
    {
        Model.Cost Cost { get; set; }

        public CostEvaluator(Model.Cost cost)
        {
            Cost = cost;
        }

        public double Evaluate(IList<Model.Product> products)
        {
            double response = 0;
            foreach(Model.Product p in products)
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
