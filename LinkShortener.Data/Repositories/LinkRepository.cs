using System.Threading.Tasks;
using LinkShortener.Data.Context;
using LinkShortener.Domain.Interfaces;
using LinkShortener.Domain.Models.Link;
using Microsoft.EntityFrameworkCore;

namespace LinkShortener.Data.Repositories
{
    public class LinkRepository:ILinkRepository
    {
        private readonly LinkShortenerDbContext _context;

        public LinkRepository(LinkShortenerDbContext context)
        {
            _context = context;
        }


        public async ValueTask DisposeAsync()
        {
            if(_context != null) await _context.DisposeAsync();
        }

        public async Task Create(ShortUrl url)
        {
            await _context.AddAsync(url);
        }

        public async Task CreateOs(OS os)
        {
            await _context.Oses.AddAsync(os);
        }

        public async Task CreateDevice(Device device)
        {
            await _context.Devices.AddAsync(device);
        }

        public async Task CreateBrowser(Browser browser)
        {
            await _context.Browsers.AddAsync(browser);
        }

        public async Task<ShortUrl> Get(string token)
        {
            return await _context.ShortUrls.AsQueryable().SingleOrDefaultAsync(u => u.Token == token);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}