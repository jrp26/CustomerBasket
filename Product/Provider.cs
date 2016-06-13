using System.Collections.Generic;
using Product.Interfaces;

namespace Product
{
    public sealed class Provider : IProductProvider
    {
        private Dictionary<string, Model.Product> Products {get; set; }

        public Provider()
        {
            Products = new Dictionary<string, Model.Product>();
        }

        public void Add(Model.Product product)
        {
            Products.Add(product.Name, product);
        }

        public Model.Product Find(string name)
        {
            return Products[name];
        }
    }
}
