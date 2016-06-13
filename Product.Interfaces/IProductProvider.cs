using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Interfaces
{
    public interface IProductProvider
    {
        void Add(Model.Product product);
        Model.Product Find(string name);
    }
}
