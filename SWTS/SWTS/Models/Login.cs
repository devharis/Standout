using System.ComponentModel.DataAnnotations;

namespace SWTS.Models
{
    public class Login
    {
        [Required]
        [Display(Name = "Användarnamn")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Lösenord")]
        public string Password { get; set; }

        [Display(Name = "Kom ihåg mig?")]
        public bool RememberMe { get; set; }
    }
}