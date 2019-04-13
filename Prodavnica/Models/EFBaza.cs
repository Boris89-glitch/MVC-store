using System.Collections.Generic;
using System.Linq;
namespace Prodavnica.Models
{
    public class EFBaza : IBaza
    {
        private EFContext context;
        public EFBaza(EFContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Product> Products => context.Products;
    }
}