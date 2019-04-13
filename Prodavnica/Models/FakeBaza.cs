using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prodavnica.Models
{
    public class FakeBaza : IBaza
    {
        public IQueryable<Product> Products => new List<Product>
        {
            new Product{Name = "nesto", Price = 25},
            new Product{Name = "nesto", Price = 115},
            new Product{Name = "nesto nesto", Price = 25}
        }.AsQueryable();
    }
}
