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

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("All-Users")]
        public async Task<IActionResult> Index()
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
    }
}
