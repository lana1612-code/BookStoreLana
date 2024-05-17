using BookStoreLana.Data;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreLana.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext context;

        public CategoriesController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var categories = context.categories.ToList();
            return View("Index" , categories);
        }
    }
}
