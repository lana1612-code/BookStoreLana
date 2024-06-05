using System.ComponentModel.DataAnnotations;

namespace BookStoreLana.ViewModel
{
    public class AutherVM
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime LastUpdate { get; set; } = DateTime.Now;
    }
}
