using System.ComponentModel.DataAnnotations;

namespace LinkShortener.Domain.Models.Link
{
    public class Device:BaseEntity
    {
        public bool IsBot { get; set; }

        [Required(ErrorMessage = "{0} Cant be more than {1} characters")]
        [MaxLength(200, ErrorMessage = "{0} Cant be more than {1} characters")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "{0} Cant be more than {1} characters")]
        [MaxLength(200, ErrorMessage = "{0} Cant be more than {1} characters")]
        public string Family { get; set; }

        [Required(ErrorMessage = "{0} Cant be more than {1} characters")]
        [MaxLength(200, ErrorMessage = "{0} Cant be more than {1} characters")]
        public string Model { get; set; }
    }
}