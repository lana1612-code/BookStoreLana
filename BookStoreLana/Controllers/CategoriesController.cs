using BookStoreLana.ViewModel;
using BookStoreLana.Data;
using BookStoreLana.Models;
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
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CategoryVM categoryVM) /* should same name */
        {
            if(!ModelState.IsValid){
                return View("Create",categoryVM);
            }
            else
            {
                var category = new Category
                {
                    Name = categoryVM.Name
                };
                try
                {
                    context.categories.Add(category);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch
                {
                    ModelState.AddModelError("Name","the name alredy exist .... ");
                    return View( categoryVM);
                }
                
            }

        }
        [HttpGet]
		public IActionResult Edite(int id)
        {
            var category = context.categories.Find(id);
            var categoryvm = new CategoryVM { Id = category.Id ,
            Name = category.Name};


            return View("Create", categoryvm);
		}
        [HttpPost]
		public IActionResult Edite(CategoryVM categorymv) // id for  the old value
		{
			var category = context.categories.Find(categorymv.Id);
            if(category == null)
            {
                    return NotFound();
            }
            else
            {
                category.Name= categorymv.Name;
                category.LastUpdate =DateTime.Now;
                context.SaveChanges();
				return RedirectToAction("Index");
			}
		}
        public IActionResult Detail(int id)
        {
            var category = context.categories.Find(id);//db
            if(category == null)
            {
                return NotFound();
            }
            var categoryvm = new CategoryVM { 
            Id = category.Id, Name = category.Name, CreatedDate =category.CreatedDate,LastUpdate = category.LastUpdate
            };


            return View("Detail", categoryvm);
        }
        public IActionResult Delete (int id)
        {
            var category = context.categories.Find(id);
            if(category == null)
            {
                return NotFound();
            }
            context.categories.Remove(category);
            context.SaveChanges();
            return Ok();
        }
    }
}
