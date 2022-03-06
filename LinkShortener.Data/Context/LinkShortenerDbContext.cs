using System.Linq;
using LinkShortener.Domain.Models.Account;
using LinkShortener.Domain.Models.Link;
using Microsoft.EntityFrameworkCore;

namespace LinkShortener.Data.Context
{
    public class LinkShortenerDbContext : DbContext
    {
        public LinkShortenerDbContext(DbContextOptions<LinkShortenerDbContext> options):base(options)
        {
        }
        

        public DbSet<User> Users { get; set; }

        public DbSet<ShortUrl> ShortUrls { get; set; }
        public DbSet<Browser> Browsers { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<OS> Oses { get; set; }
        public DbSet<RequestUrl> RequestUrls { get; set; }


        #region OnModelCreating

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relation in modelBuilder.Model.GetEntityTypes().SelectMany(s => s.GetForeignKeys()))
            {
                relation.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelBuilder);
        }

        #endregion
    }
}