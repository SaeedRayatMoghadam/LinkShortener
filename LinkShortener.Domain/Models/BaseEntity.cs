using System;
using System.ComponentModel.DataAnnotations;

namespace LinkShortener.Domain.Models
{
    public class BaseEntity
    {
        [Key]
        public long Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}