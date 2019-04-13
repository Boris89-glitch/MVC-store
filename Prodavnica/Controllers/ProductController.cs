using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Prodavnica.Models;
using Prodavnica.Models.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Prodavnica.Controllers
{
    public class ProductController : Controller
    {
        private readonly IBaza baza;
        public int PageSize = 4;

        public ProductController(IBaza bazica)
        {
            baza = bazica;
        }
        public ViewResult List(string category, int productPage = 1) => View(new ProductsListViewModel
        {
            Products = baza.Products
            .Where(p => category == null || p.Category == category)
            .OrderBy(p => p.ProductID)
            .Skip((productPage - 1) * PageSize)
            .Take(PageSize), PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                TotalItems = category == null ?
                baza.Products.Count() :
                baza.Products.Where(e => e.Category == category).Count()
                }, CurrentCategory = category
        }); 
    }
}
