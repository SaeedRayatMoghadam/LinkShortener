using System;
using System.Threading.Tasks;
using LinkShortener.Domain.Models.Link;

namespace LinkShortener.Domain.Interfaces
{
    public interface ILinkRepository : IAsyncDisposable
    {
        Task Create(ShortUrl url);
        Task CreateOs(OS os);
        Task CreateDevice(Device device);
        Task CreateBrowser(Browser browser);

        Task<ShortUrl> Get(string token);

        Task Save();
    }
}