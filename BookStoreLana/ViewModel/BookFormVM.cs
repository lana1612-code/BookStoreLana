using BookStoreLana.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace BookStoreLana.ViewModel
{
    public class BookFormVM
    {
        public int Id { get; set; }
        [MaxLength(500)]
        public string Title { get; set; } = null!;
        [Display(Name = "Auther")]
        public int AutherId { get; set; }
        public List<SelectListItem>? Authers { get; set; }
		public string Publisher { get; set; } = null!;

        [Display(Name = "publish Date")]
        public DateTime publishDate { get; set; } = DateTime.Now;
        [Display(Name ="pls choose image")]
		public IFormFile? ImageUrl { get; set; }
		public string Description { get; set; } = null!;
        public List<int> SelectedCategories { get; set; } = new List<int> ();
        public List<SelectListItem>? Categories { get; set; }
	}
}
