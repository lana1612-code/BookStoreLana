using BookStoreLana.Data;
using BookStoreLana.Data.Migrations;
using BookStoreLana.Models;
using BookStoreLana.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BookStoreLana.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext context;
		private readonly IWebHostEnvironment webHostEnvironment;

		public BooksController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment) {
            this.context = context;
			this.webHostEnvironment = webHostEnvironment;
		}
        public IActionResult Index()
        {
            var books = context.Books.Include(Book=>Book.Auther).Include(Book => Book.Categories).
                ThenInclude(Book=>Book.Category).ToList();
         
            var booksvm = books.Select(book=>new BookVM {
                Id = book.Id,
                Title = book.Title,
                Auther = book.Auther.Name,
                Publisher = book.Publisher,
                publishDate = book.publishDate,
                ImageUrl = book.ImageUrl,
                Categories = book.Categories.Select(c=>c.Category.Name).ToList(),
            }).ToList();



            /*
            var booksvm = new List<BookVM>();
            foreach(var book in books)
            {
                var bookvm = new BookVM 
                {
                    Id = book.Id,
                    Title = book.Title,
                    Auther = book.Auther.Name,
                    Publisher = book.Publisher,
                    publishDate = book.publishDate,
                    ImageUrl = book.ImageUrl,
                    Categories = new List<string>(),
                };
                foreach (var item2 in book.Categories)
                {
                    
                  bookvm.Categories.Add(item2.Category.Name);
                }
                booksvm.Add(bookvm);

            }
         */
            return View(booksvm);
   
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
            string imgUrl = null;
            if (bookformvm.ImageUrl != null)
            {
                 imgUrl = Path.GetFileName(bookformvm.ImageUrl.FileName);
                var path = Path.Combine($"{webHostEnvironment.WebRootPath}/img/books", imgUrl);
				var stream = System.IO.File.Create(path);
				bookformvm.ImageUrl.CopyTo(stream);
			}
            var book = new Book {
                Title = bookformvm.Title,
                Publisher = bookformvm.Publisher,
                publishDate = bookformvm.publishDate,
                AutherId = bookformvm.AutherId,
                Description = bookformvm.Description,
                ImageUrl = imgUrl,
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
