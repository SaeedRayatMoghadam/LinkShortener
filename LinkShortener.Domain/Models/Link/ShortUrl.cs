using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LinkShortener.Domain.Models.Link
{
    public class ShortUrl:BaseEntity
    {
        [Required(ErrorMessage = "Please Enter {0}")]
        public Uri OriginalUrl { get; set; }

        [Required(ErrorMessage = "Please Enter {0}")]
        [MaxLength(400, ErrorMessage = "{0} Cant be more than {1} characters")]
        public Uri Value { get; set; }

        [Required(ErrorMessage = "Please Enter {0}")]
        [MaxLength(40, ErrorMessage = "{0} Cant be more than {1} characters")]
        public string Token { get; set; }

        #region Relations

        public ICollection<RequestUrl> RequestUrls { get; set; }

        #endregion
    }
}