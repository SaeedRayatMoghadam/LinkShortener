using System.ComponentModel.DataAnnotations;

namespace LinkShortener.Domain.Models.Link
{
    public class Browser:BaseEntity
    {
        [Required(ErrorMessage = "Please Enter {0}")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string Family { get; set; }
        
        [Required(ErrorMessage = "{0} Cant be more than {1} characters")]
        [MaxLength(200, ErrorMessage = "{0} Cant be more than {1} characters")]
        public string Major { get; set; }
        
        [Required(ErrorMessage = "Please Enter {0}")]
        [MaxLength(200, ErrorMessage = "{0} Cant be more than {1} characters")]
        public string Minor { get; set; }
    }
}