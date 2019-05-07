using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Prodavnica.Models;
namespace Prodavnica.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IBaza baza;
        public NavigationMenuViewComponent(IBaza repo)
        {
            baza = repo;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(baza.Products.Select(x => x.Category).Distinct().OrderBy(x => x));
        }
    }
}