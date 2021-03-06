using System.Threading.Tasks;
using LinkShortener.Application.DTOs.Account;
using LinkShortener.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LinkShortener.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        private readonly ILinkService _linkService;

        public HomeController(IUserService userService, ILinkService linkService)
        {
            _userService = userService;
            _linkService = linkService;
        }
        [HttpGet("Links")]
        public async Task<IActionResult> Index()
        {
            return View(await _linkService.GetAll());
        }

        [HttpGet("All-Users")]
        public async Task<IActionResult> Users()
        {
            return View(await _userService.GetAll());
        }

        [HttpGet("UpdateUser/{id}")]
        public async Task<IActionResult> UpdateUser(long id)
        {
            return View(await _userService.Get(id));
        }

        [HttpPost("UpdateUser/{id}")]
        public async Task<IActionResult> UpdateUser(UpdateUserDto user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            var result = await _userService.Update(user);

            switch (result)
            {
                case UpdateUserResult.NotFound:
                    TempData["ErrorMessage"] = "User NOT Found !";
                    break;
                case UpdateUserResult.Success:
                    TempData["SuccessMessage"] = "User Successfully Updated !";
                    return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet("CreateUser")]
        public async Task<IActionResult> CreateUser()
        {
            return View();
        }

        [HttpPost("CreateUser")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUser(CreateUserDto user)
        {
            if(!ModelState.IsValid) return View(user);

            var result = await _userService.Create(user);

            switch (result)
            {
                case CreateUserResult.Error:
                    TempData["ErrorMessage"] = "Mobile is NOT Available !";
                    ModelState.AddModelError("Mobile", "Mobile is NOT Available !");
                    break;
                case CreateUserResult.Success:
                    TempData["SuccessMessage"] = "User Successfully Created !";
                    return RedirectToAction("Index");
            }

            return View();
        }
    }
}
