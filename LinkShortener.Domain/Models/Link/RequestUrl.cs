using System;

namespace LinkShortener.Domain.Models.Link
{
    public class RequestUrl:BaseEntity
    {
        public long ShortUriId { get; set; }
        public DateTime RequestDateTime { get; set; }

        #region Relations

        public ShortUrl ShortUrl { get; set; }

        #endregion
    }
}