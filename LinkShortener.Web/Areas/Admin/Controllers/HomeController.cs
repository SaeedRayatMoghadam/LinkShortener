using System.Threading.Tasks;
using LinkShortener.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LinkShortener.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("All-Users")]
        public async Task<IActionResult> Index()
        {
            return View(await _userService.GetAll());
        }
    }
}
