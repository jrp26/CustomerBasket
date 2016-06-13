using System;
using System.Collections.Generic;

namespace Price
{
    public sealed class Provider : IPriceProvider
    {
        IList<Evaluators.IEvaluator> Evaluators { get; set; }

        public Provider()
        {
            Evaluators = new List<Evaluators.IEvaluator>();
        }

        public void AddCost(Entities.Cost cost)
        {
            Evaluators.Add(new Evaluators.CostEvaluator(cost));
        }

        public void AddOffer(Entities.Offer offer)
        {
            Evaluators.Add(new Evaluators.OfferEvaluator(offer));
        }

        public Entities.Quote Calculate(IList<Entities.Product> products)
        {
            double amount = 0;
            foreach(Evaluators.IEvaluator evs in Evaluators)
            {
                amount += evs.Evaluate(products);
            }
            return new Entities.Quote(Math.Round(amount,2));
        }
    }
}
