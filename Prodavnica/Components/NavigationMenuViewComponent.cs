using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Prodavnica.Models;
namespace Prodavnica.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IBaza repository;
        public NavigationMenuViewComponent(IBaza repo)
        {
            repository = repo;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(repository.Products
            .Select(x => x.Category)
            .Distinct()
            .OrderBy(x => x));
        }
    }
}