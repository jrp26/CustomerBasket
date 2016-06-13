using System.Collections.Generic;

namespace Price.Evaluators
{
    public sealed class OfferEvaluator : IEvaluator
    {
        Entities.Offer Offer { get; set; }

        public OfferEvaluator(Entities.Offer offer)
        {
            Offer = offer;
        }

        public double Evaluate(IList<Entities.Product> products)
        {
            Dictionary<int, int> thresholds = new Dictionary<int, int>();
            foreach(Entities.Product p in Offer.Trigger.Products)
            {
                thresholds.Add(p.ProductId, 0);
                int q = 0;
                foreach(Entities.Product b in products)
                {
                    if (p.ProductId == b.ProductId)
                    {
                        q += b.Quantity;
                    }
                    if (q >= p.Quantity)  // If quantity threshold reached/exceeded
                    {
                        int qtyTimesExceeded = q / p.Quantity;
                        thresholds[p.ProductId] += qtyTimesExceeded;
                        q = q - (p.Quantity * qtyTimesExceeded);
                    }
                }
            }
            
            // pick the lowest value in each threshold
            int thresCrossed = products.Count;
            foreach(KeyValuePair<int, int> entry in thresholds)
            {
                if (entry.Value < thresCrossed) thresCrossed = entry.Value;
            }
            return (thresCrossed > 0) ? -(Offer.Reward.Amount * thresCrossed) : 0;
        }
    }
}
