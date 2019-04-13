using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prodavnica.Infrastructure;
using Prodavnica.Models;
using Prodavnica.Models.ViewModels;

namespace Prodavnica.Controllers
{
    public class CartController : Controller
    {
        private IBaza baza;
        private Cart cart;
        public CartController(IBaza bazica, Cart cartService)
        {
            baza = bazica;
            cart = cartService;
        }
        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }
        public RedirectToActionResult AddToCart(int productId, string returnUrl)
        {
            Product product = baza.Products.FirstOrDefault(p => p.ProductID == productId);
            if (product != null)
            {
                cart.AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public RedirectToActionResult RemoveFromCart(int productId,string returnUrl)
        {
            Product product = baza.Products.FirstOrDefault(p => p.ProductID == productId);
            if (product != null)
            {
                cart.RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
    }
}