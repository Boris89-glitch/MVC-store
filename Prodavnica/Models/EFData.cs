using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
namespace Prodavnica.Models
{
    public static class EFData
    {
        public static void Populate(IApplicationBuilder app)
        {
            EFContext context = app.ApplicationServices.GetRequiredService<EFContext>();
            context.Database.Migrate();
            if (!context.Products.Any()) // if empty add some products(first time)
            {
                context.Products.AddRange(
                new Product
                {
                    Name = "Proizvod 1",
                    Description = "Neki random description za proizvod",
                    Category = "Kategorija 1",
                    Price = 275
                },
                  new Product
                  {
                      Name = "Skije Elan FAS 935",
                      Description = "Stare skije",
                      Category = "Ski",
                      Price = 125
                  },
                new Product
                {
                    Name = "Proizvod 55",
                    Description = "Neki random description za proizvod",
                    Category = "Kategorija 1",
                    Price = 275
                },
                new Product
                {
                    Name = "Proizvod 1",
                    Description = "Neki random description za proizvod",
                    Category = "Kategorija 2",
                    Price = 275
                },
                new Product
                {
                    Name = "Proizvod 5",
                    Description = "Neki random description za proizvod",
                    Category = "Kategorija 1",
                    Price = 275
                },
                new Product
                {
                    Name = "Proizvod 5",
                    Description = "Neki random description za proizvod",
                    Category = "Kategorija 2",
                    Price = 275
                },
                new Product
                {
                    Name = "Proizvod 33",
                    Description = "Neki random description za proizvod",
                    Category = "Kategorija 3",
                    Price = 275
                },
                new Product
                {
                    Name = "Proizvod 3",
                    Description = "Neki random description za proizvod",
                    Category = "Kategorija 3",
                    Price = 275
                },
                new Product
                {
                    Name = "Proizvod 22",
                    Description = "Neki random description za proizvod",
                    Category = "Kategorija 1",
                    Price = 275
                },
                new Product
                {
                    Name = "Proizvod 2",
                    Description = "Neki random description za proizvod",
                    Category = "Kategorija 1",
                    Price = 275
                });
                context.SaveChanges();
            }
        }
    }
}