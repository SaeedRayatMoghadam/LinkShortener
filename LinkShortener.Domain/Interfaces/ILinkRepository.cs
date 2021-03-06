using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LinkShortener.Domain.Models.Link;
using LinkShortener.Domain.ViewModels.Link;

namespace LinkShortener.Domain.Interfaces
{
    public interface ILinkRepository : IAsyncDisposable
    {
        Task Create(ShortUrl url);
        Task CreateOs(OS os);
        Task CreateDevice(Device device);
        Task CreateBrowser(Browser browser);

        Task<ShortUrl> Get(string token);
        Task<List<LinksViewModel>> GetAll();

        Task CreateRequestUrl(RequestUrl requestUrl);

        Task Save();
    }
}