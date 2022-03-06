using System;
using System.Threading.Tasks;
using LinkShortener.Data.Context;
using LinkShortener.Domain.Interfaces;
using LinkShortener.Domain.Models.Account;
using Microsoft.EntityFrameworkCore;

namespace LinkShortener.Data.Repositories
{
    public class UserRepository:IUserRepository
    {
        private readonly LinkShortenerDbContext _context;

        #region Construction

        public UserRepository(LinkShortenerDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Dispose

        public async ValueTask DisposeAsync()
        {
            if (_context != null) await _context.DisposeAsync();
        }

        #endregion

        public async Task<User> Get(string mobile)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Mobile == mobile);
        }

        public async Task Create(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task<bool> IsMobileExist(string mobile)
        {
            return await _context.Users.AnyAsync(u => u.Mobile == mobile);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}