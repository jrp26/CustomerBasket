using System.Collections.Generic;

namespace Price.Evaluators
{
    public sealed class OfferEvaluator : IEvaluator
    {
        Model.Offer Offer { get; set; }

        public OfferEvaluator(Model.Offer offer)
        {
            Offer = offer;
        }

        public double Evaluate(IList<Model.Product> products)
        {
            Dictionary<int, int> thresholds = new Dictionary<int, int>();
            foreach(Model.Product p in Offer.Trigger.Products)
            {
                thresholds.Add(p.ProductId, 0);
                int q = 0;
                foreach(Model.Product b in products)
                {
                    if (p.ProductId == b.ProductId)
                    {
                        q += b.Quantity;
                    }
                    if (q >= p.Quantity)  // If quantity threshold reached/exceeded, support unlimited redemptions
                    {
                        int qtyTimesExceeded = q / p.Quantity;
                        thresholds[p.ProductId] += qtyTimesExceeded;
                        q = q - (p.Quantity * qtyTimesExceeded);
                    }
                }
            }
            
            // Establish number of times threshold has been crossed for each trigger product:
            int thresCrossed = products.Count;
            foreach(KeyValuePair<int, int> entry in thresholds)
            {
                if (entry.Value < thresCrossed) thresCrossed = entry.Value;
            }
            return (thresCrossed > 0) ? -(Offer.Reward.Amount * thresCrossed) : 0;
        }
    }
}
