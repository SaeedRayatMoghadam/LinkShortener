using System.ComponentModel.DataAnnotations;

namespace LinkShortener.Application.DTOs.Account
{
    public class LoginDto
    {

        [Required(ErrorMessage = "Please Enter {0}")]
        [MaxLength(100, ErrorMessage = "Password cant be more than {1} characters")]
        public string Password { get; set; }
        
        [Required(ErrorMessage = "Please Enter {0}")]
        public string Mobile { get; set; }

        public bool RememberMe { get; set; }
    }

    public enum LoginResult
    {
        NotFound,
        NotActivated,
        Success
    }
}