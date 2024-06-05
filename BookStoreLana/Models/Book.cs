using System.ComponentModel.DataAnnotations;

namespace BookStoreLana.Models
{
    public class Book
    {
        public int Id { get; set; }
        [MaxLength(500)]
        public string Title { get; set; } = null!;

        public int AutherId { get; set; }
        public Auther? Auther { get; set; }
        public string Publisher { get; set; } = null!;
        public string? ImageUrl { get; set; }
        public DateTime publishDate { get; set; }
        public string Description { get; set; } = null!;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime LastUpdate { get; set; } = DateTime.Now;
        public List<BookCategory> Categories { get; set; } = new List<BookCategory>();
    }
}
