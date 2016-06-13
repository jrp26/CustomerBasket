using System.Collections.Generic;

namespace Price
{
    public interface IPriceProvider
    {
        void AddCost(Entities.Cost cost);
        void AddOffer(Entities.Offer offer);
        Entities.Quote Calculate(IList<Entities.Product> products);
    }
}
