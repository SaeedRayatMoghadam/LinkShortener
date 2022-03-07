using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LinkShortener.Application.DTOs.Link;
using LinkShortener.Domain.Models.Link;
using LinkShortener.Domain.ViewModels.Link;

namespace LinkShortener.Application.Interfaces
{
    public interface ILinkService
    {
        ShortUrl GenerateShortUrl(Uri uri);
        Task CreateUserAgent(string userAgent);

        Task<ShortUrl> Get(string token);
        Task<List<LinksViewModel>> GetAll();

        Task<UrlRequestResult> Create(ShortUrl url);

        Task CreateRequestUrl(string token);
    }
}