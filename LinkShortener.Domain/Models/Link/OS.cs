using System.ComponentModel.DataAnnotations;

namespace LinkShortener.Domain.Models.Link
{
    public class OS:BaseEntity
    {
        [Required(ErrorMessage = "{0} Cant be more than {1} characters")]
        [MaxLength(200, ErrorMessage = "{0} Cant be more than {1} characters")]
        public string Family { get; set; }

        [Required(ErrorMessage = "{0} Cant be more than {1} characters")]
        [MaxLength(200, ErrorMessage = "{0} Cant be more than {1} characters")]
        public string Major { get; set; }

        [Required(ErrorMessage = "{0} Cant be more than {1} characters")]
        [MaxLength(200, ErrorMessage = "{0} Cant be more than {1} characters")]
        public string Minor { get; set; }
    }
}