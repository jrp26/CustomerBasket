using System.Collections.Generic;

namespace Price.Entities
{
    public sealed class Trigger
    {
        public IList<Product> Products { get; set; }
        
        public Trigger(IList<Product> products)
        {
            Products = products;
        }
    }
}
