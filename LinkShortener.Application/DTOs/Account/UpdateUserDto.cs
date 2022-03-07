using System.ComponentModel.DataAnnotations;

namespace LinkShortener.Application.DTOs.Account
{
    public class UpdateUserDto
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public bool IsBlocked { get; set; }
        public bool IsAdmin{ get; set; }
    }

    public enum UpdateUserResult
    {
        NotFound,
        Success
    }
}