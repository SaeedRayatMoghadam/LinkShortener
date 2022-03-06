using LinkShortener.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using LinkShortener.Application.DTOs.Link;
using LinkShortener.Application.Interfaces;

namespace LinkShortener.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILinkService _linkService;

        public HomeController(ILinkService linkService)
        {
            _linkService = linkService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(UrlRequestDto request)
        {
            if (!ModelState.IsValid) return View(request);

            if (request.OriginalUrl.Contains("https://") || request.OriginalUrl.Contains("http://"))
            {
                var url = new Uri(request.OriginalUrl);
                var shortUrl = _linkService.GenerateShortUrl(url);

                var result = await _linkService.Create(shortUrl);

                switch (result)
                {
                    case UrlRequestResult.Error:
                        TempData[ErrorMessage] = "Something went WRONG !";
                        break;
                    case UrlRequestResult.Success:
                        TempData[SuccessMessage] = "Link Successfully Shortened !";
                        ViewBag.isSuccess = true;
                        ViewBag.UserShortLink = shortUrl.Value.ToString();
                        break;
                }
                return View(request);
            }
            else
            {
                TempData[ErrorMessage] = "Link is NOT Valid";
                return View(request);
            }
        }
    }
}
