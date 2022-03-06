using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using LinkShortener.Application.Interfaces;
using Microsoft.Extensions.Primitives;

namespace LinkShortener.Web.Middlesware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ShortLinkUrlRedirect
    {
        private readonly RequestDelegate _next;
        private ILinkService _linkService;

        public ShortLinkUrlRedirect(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            _linkService = (ILinkService)httpContext.RequestServices.GetService(typeof(ILinkService));

            var userAgent = StringValues.Empty;
            httpContext.Request.Headers.TryGetValue("User-Agent", out userAgent);

            if (httpContext.Request.Path.ToString().Length == 9)
            {
                _linkService.CreateUserAgent(userAgent);
                var token = httpContext.Request.Path.ToString().Substring(1);
                var shortUrl = await _linkService.Get(token);

                httpContext.Response.Redirect(shortUrl != null
                    ? shortUrl.OriginalUrl.ToString()
                    : httpContext.Request.Host.ToString());
            }
            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ShortLinkUrlRedirectExtensions
    {
        public static IApplicationBuilder UseShortLinkUrlRedirect(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ShortLinkUrlRedirect>();
        }
    }
}
