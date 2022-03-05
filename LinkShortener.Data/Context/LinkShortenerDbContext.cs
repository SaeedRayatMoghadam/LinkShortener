using Microsoft.EntityFrameworkCore;

namespace LinkShortener.Data.Context
{
    public class LinkShortenerDbContext : DbContext
    {
        public LinkShortenerDbContext(DbContextOptions<LinkShortenerDbContext> options):base(options)
        {
            
        }
    }
}