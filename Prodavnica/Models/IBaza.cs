using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prodavnica.Models
{
    public interface IBaza
    {
        IQueryable<Product> Products { get; }
    }
}