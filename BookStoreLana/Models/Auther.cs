using System.ComponentModel.DataAnnotations;

namespace BookStoreLana.Models
{
    public class Auther
    {
        public int Id { get; set; }
        [MaxLength(30,ErrorMessage = " can not successed max lenght of characteris ` 30 char `.")]
        public string Name { get; set; } = null!;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime LastUpdate { get; set; } = DateTime.Now;
    }
}
