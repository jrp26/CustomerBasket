using System.Collections.Generic;

namespace Price.Interfaces
{
    public interface IPriceProvider
    {
        void AddCost(Model.Cost cost);
        void AddOffer(Model.Offer offer);
        Model.Quote Calculate(IList<Model.Product> products);
    }
}
