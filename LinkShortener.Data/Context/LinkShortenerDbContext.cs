using System.Linq;
using LinkShortener.Domain.Models.Account;
using Microsoft.EntityFrameworkCore;

namespace LinkShortener.Data.Context
{
    public class LinkShortenerDbContext : DbContext
    {
        public LinkShortenerDbContext(DbContextOptions<LinkShortenerDbContext> options):base(options)
        {
        }

        #region Account

        public DbSet<User> Users { get; set; }

        #endregion


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