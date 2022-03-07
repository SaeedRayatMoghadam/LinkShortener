using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LinkShortener.Application.DTOs.Link;
using LinkShortener.Application.Interfaces;
using LinkShortener.Application.Utilities;
using LinkShortener.Domain.Interfaces;
using LinkShortener.Domain.Models.Link;
using LinkShortener.Domain.ViewModels.Link;
using UAParser;
using Device = LinkShortener.Domain.Models.Link.Device;
using OS = LinkShortener.Domain.Models.Link.OS;

namespace LinkShortener.Application.Services
{
    public class LinkService : ILinkService
    {
        private readonly ILinkRepository _linkRepository;

        public LinkService(ILinkRepository linkRepository)
        {
            _linkRepository = linkRepository;
        }
        public ShortUrl GenerateShortUrl(Uri uri)
        {
            var shortUrl = new ShortUrl();

            shortUrl.OriginalUrl = uri;
            shortUrl.CreateDate = DateTime.Now;
            shortUrl.Token = TokenGenerator.Generate();
            shortUrl.Value = new Uri($"https://localhost:44393/{shortUrl.Token}");

            return shortUrl;

        }

        public async Task CreateUserAgent(string userAgent)
        {
            var uaParser = Parser.GetDefault();
            ClientInfo client = uaParser.Parse(userAgent);

            OS os = new OS()
            {
                Family = client.OS.Family,
                Major = client.OS.Major,
                Minor = "No Data",
                CreateDate = DateTime.Now
            };
            await _linkRepository.CreateOs(os);

            Device device = new Device()
            {
                IsBot = client.Device.IsSpider,
                Brand = client.Device.Brand,
                Family = client.Device.Family,
                Model = client.Device.Model,
                CreateDate = DateTime.Now
            };
            await _linkRepository.CreateDevice(device);

            Browser browser = new Browser()
            {
                Family = client.UA.Family,
                Major = client.UA.Major,
                Minor = client.UA.Minor,
                CreateDate = DateTime.Now
            };
            await _linkRepository.CreateBrowser(browser);

            await _linkRepository.Save();
        }

        public async Task<ShortUrl> Get(string token)
        {
            return await _linkRepository.Get(token);
        }

        public async Task<List<LinksViewModel>> GetAll()
        {
            return await _linkRepository.GetAll();
        }

        public async Task<UrlRequestResult> Create(ShortUrl url)
        {
            if (url == null) return UrlRequestResult.Error;
            await _linkRepository.Create(url);
            await _linkRepository.Save();

            return UrlRequestResult.Success;
        }

        public async Task CreateRequestUrl(string token)
        {
            var shortUrl = await _linkRepository.Get(token);

            var requestUrl = new RequestUrl()
            {
                ShortUrl = shortUrl,
                RequestDateTime = DateTime.Now,
                CreateDate = DateTime.Now
            };

            await _linkRepository.CreateRequestUrl(requestUrl);
            await _linkRepository.Save();
        }
    }
}