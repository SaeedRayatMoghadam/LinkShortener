using System.ComponentModel.DataAnnotations;

namespace LinkShortener.Application.DTOs.Account
{
    public class RegisterDto
    {
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Please Enter {0}")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Please Enter {0}")]
        [MaxLength(100, ErrorMessage = "Password cant be more than {1} characters")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please Enter {0}")]
        public string ConfirmPassword { get; set; }


        [Required(ErrorMessage = "Please Enter {0}")]
        public string Mobile { get; set; }
    }

    public enum RegisterResult{
        MobileExists,
        Success
    }
}