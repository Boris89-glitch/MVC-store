using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prodavnica.Models
{
    public interface IBaza
    {
        IQueryable<Product> Products { get; }

        void SaveProduct(Product product);   //za admina

        Product DeleteProduct(int productID);
    }
}