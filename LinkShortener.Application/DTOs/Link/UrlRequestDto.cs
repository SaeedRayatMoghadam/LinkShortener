using System.ComponentModel.DataAnnotations;

namespace LinkShortener.Application.DTOs.Link
{
    public class UrlRequestDto
    {
        [Required(ErrorMessage = "Please Enter {0}")]
        public string OriginalUrl { get; set; }
    }

    public enum UrlRequestResult
    {
        Success,
        Error
    }
}