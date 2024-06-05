using BookStoreLana.Data;
using BookStoreLana.Models;
using BookStoreLana.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStoreLana.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext context;

        public BooksController(ApplicationDbContext context) {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            var authers =  context.Authers.OrderBy(auther=>auther.Name).ToList();
			var categorie = context.categories.OrderBy(c => c.Name).ToList();

			var autherList = new List<SelectListItem>();

            foreach (var auther in authers)
            {
                autherList.Add(
                    new SelectListItem { 
                    Value = auther.Id.ToString(),
                    Text = auther.Name,
                    });
            }
            var categoriesList = new List<SelectListItem>();    
            
            foreach(var category in categorie)
            {
				categoriesList.Add(
				   new SelectListItem
				   {
					   Value = category.Id.ToString(),
					   Text = category.Name,
				   });
			}

            var autherformvm = new BookFormVM { 
            Authers = autherList,
            Categories = categoriesList
            };

            return View(autherformvm);
        }
        [HttpPost]
        public IActionResult Create(BookFormVM bookformvm)
        {
            if (!ModelState.IsValid)
            {
                return View(bookformvm);
            }
            var book = new Book {
                Title = bookformvm.Title,
                Publisher = bookformvm.Publisher,
                publishDate = bookformvm.publishDate,
                AutherId = bookformvm.AutherId,
                Description = bookformvm.Description,
                Categories = bookformvm.SelectedCategories.Select(
                id => new BookCategory {
                    CategoryId = id
                }).ToList(),
             
            };
            context.Books.Add(book);

			context.SaveChanges();

			return RedirectToAction("Index");
        }
    }
}
