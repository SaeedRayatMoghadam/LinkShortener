using System;
using System.Threading.Tasks;
using LinkShortener.Application.DTOs.Link;
using LinkShortener.Domain.Models.Link;

namespace LinkShortener.Application.Interfaces
{
    public interface ILinkService
    {
        ShortUrl GenerateShortUrl(Uri uri);
        Task CreateUserAgent(string userAgent);

        Task<ShortUrl> Get(string token);

        Task<UrlRequestResult> Create(ShortUrl url);
    }
}