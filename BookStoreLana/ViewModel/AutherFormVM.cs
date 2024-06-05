using System.ComponentModel.DataAnnotations;

namespace BookStoreLana.ViewModel
{
    public class AutherFormVM
    {
        public int Id { get; set; }
        [MaxLength(30, ErrorMessage = "  the  max lenght characterstic is 30 char .")]
        public string Name { get; set; } = null!;
    }
}
