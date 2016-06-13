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
            IList<Price.Model.Product> products = new List<Price.Model.Product>();
            foreach(BasketItem bi in BasketItems)
            {
                products.Add(new Price.Model.Product(bi.ProductId, bi.Quantity));
            }
            Total = PriceProvider.Calculate(products).Total;
        }
    }
}
