using System.Collections.Generic;

namespace Product
{
    public sealed class Provider
    {
        private Dictionary<string, Entities.Product> Products {get; set; }

        public Provider()
        {
            Products = new Dictionary<string, Entities.Product>();
        }

        public void Add(Entities.Product product)
        {
            Products.Add(product.Name, product);
        }

        public Entities.Product Find(string name)
        {
            return Products[name];
        }
    }
}
