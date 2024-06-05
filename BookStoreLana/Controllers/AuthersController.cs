using BookStoreLana.Data;
using BookStoreLana.Models;
using BookStoreLana.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreLana.Controllers
{
    public class AuthersController : Controller
    {
        private readonly ApplicationDbContext context;

        public AuthersController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var authers = context.Authers.ToList();
            var authersvm = new List<AutherFormVM>();
            foreach(var item in  authers)
            {
                var authervm = new AutherFormVM()
                {
                    Id = item.Id,
                    Name = item.Name
                };
                authersvm.Add(authervm);

            }
            return View(authersvm);
        }
        
		[HttpGet]
		public IActionResult Create()
		{
			return View("Form");
		}
		[HttpPost]
		public IActionResult Create(AutherFormVM autherformvm) 
		{
			if (!ModelState.IsValid)
			{
				return View("Form", autherformvm);
			}
			else
			{
				var auther = new Auther
				{
					Name = autherformvm.Name
				};
				try
				{
					context.Authers.Add(auther);
					context.SaveChanges();
					return RedirectToAction("Index");
				}
				catch
				{
					ModelState.AddModelError("Name", "the name alredy exist .... ");
					return View(autherformvm);
				}

			}

		}
        [HttpGet]
        public IActionResult Edite(int id)
        {
            var auther = context.Authers.Find(id);
            var autherformvm = new AutherFormVM
            {
                Id = auther.Id,
                Name = auther.Name
            };


            return View("Form", autherformvm);
        }
        [HttpPost]
        public IActionResult Edite(AutherFormVM autherformvm) 
        {
            var auther = context.Authers.Find(autherformvm.Id);
            if (auther == null)
            {
                return NotFound();
            }
            else
            {
                auther.Name = autherformvm.Name;
                auther.LastUpdate = DateTime.Now;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        public IActionResult Detail(int id)
        {
            var auther = context.Authers.Find(id);//db
            if (auther == null)
            {
                return NotFound();
            }
            var authervm = new AutherVM
            {
                Id = auther.Id,
                Name = auther.Name,
                CreatedDate = auther.CreatedDate,
                LastUpdate = auther.LastUpdate
            };


            return View("Detail", authervm);
        }
        public IActionResult Delete(int id)
        {
            var auther = context.Authers.Find(id);
            if (auther == null)
            {
                return NotFound();
            }
            context.Authers.Remove(auther);
            context.SaveChanges();
            return Ok();
        }
    }
}
