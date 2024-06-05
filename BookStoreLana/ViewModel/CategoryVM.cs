using System.ComponentModel.DataAnnotations;

namespace BookStoreLana.ViewModel
{
    public class CategoryVM
    {
		public int Id { get; set; }
		[Required(ErrorMessage ="this field is required")]
        [MaxLength(30,ErrorMessage ="the length should 30")]
        public string Name { get; set; } = null!;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime LastUpdate { get; set; } = DateTime.Now;
    }
}
