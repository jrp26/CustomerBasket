using System.Collections.Generic;

namespace App
{
    public sealed class Basket
    {
        public IList<BasketItem> BasketItems { get; set; }
        private Price.IPriceProvider PriceProvider { get; set; }
        public double Total { get; set; }

        public Basket(Price.IPriceProvider priceProvider)
        {
            PriceProvider = priceProvider;
            BasketItems = new List<BasketItem>();
        }

        public void Add(BasketItem basketItem)
        {
            BasketItems.Add(basketItem);
        }
        
        public void CalculateTotal()
        {
            IList<Price.Entities.Product> products = new List<Price.Entities.Product>();
            foreach(BasketItem bi in BasketItems)
            {
                products.Add(new Price.Entities.Product(bi.ProductId, bi.Quantity));
            }
            Total = PriceProvider.Calculate(products).Total;
        }
    }
}
