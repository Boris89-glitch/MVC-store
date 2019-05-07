using Microsoft.AspNetCore.Mvc;
using Prodavnica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prodavnica.Controllers
{
    public class AdminController : Controller
    {
        private IBaza repository;

        public AdminController(IBaza repo)
        {
            repository = repo;
        }

        public ViewResult Index() => View(repository.Products);

        public ViewResult Edit(int productId) => View(repository.Products.FirstOrDefault(p => p.ProductID == productId));

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            repository.SaveProduct(product);
            return RedirectToAction("Index");
        }
       
        [HttpPost]
        public IActionResult Delete(int productId)
        {
            Product deletedProduct = repository.DeleteProduct(productId);
            return RedirectToAction("Index");
        }

        public ViewResult Create() => View("Edit", new Product());
    }
}
