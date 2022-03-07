using System.ComponentModel.DataAnnotations;

namespace LinkShortener.Application.DTOs.Account
{
    public class CreateUserDto
    {
        [Required(ErrorMessage = "Please Enter {0}")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Please Enter {0}")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Please Enter {0}")]
        [MaxLength(100, ErrorMessage = "Password cant be more than {1} characters")]
        public string Password { get; set; }


        [Required(ErrorMessage = "Please Enter {0}")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "Please Enter {0}")]
        public bool IsBlocked { get; set; }

        public bool IsAdmin { get; set; }

    }

    public enum CreateUserResult
    {
        Success,
        Error
    }
}