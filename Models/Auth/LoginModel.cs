using System.ComponentModel.DataAnnotations;

namespace MONACO_ASP.Models.Auth
{
    public class LoginModel
    {
        [Required]
        [Display(Name = "Email")]
        public string? Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        public bool RememberMe { get; set; }
        public string? ReturnUrl { get; set; }

    }
}
