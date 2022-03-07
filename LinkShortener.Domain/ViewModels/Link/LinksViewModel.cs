using System;
using System.ComponentModel.DataAnnotations;

namespace LinkShortener.Domain.ViewModels.Link
{
    public class LinksViewModel
    {
        public Uri OriginalUrl { get; set; }
        public Uri Value { get; set; }
        public string Token { get; set; }
        public DateTime CreateDate { get; set; }
    }
}