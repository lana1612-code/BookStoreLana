using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace BookStoreLana.ViewModel
{
	public class BookVM
	{
		public int Id { get; set; }
		public string Title { get; set; } = null!;
		public string Auther { get; set; } = null!;
		public string Publisher { get; set; } = null!;

		public DateTime publishDate { get; set; } 
		public string ImageUrl { get; set; }
		public List<string> Categories { get; set; } 
	}
}
