using System.Threading.Tasks;
using LinkShortener.Application.DTOs.Account;
using LinkShortener.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LinkShortener.Web.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("Register")]
        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost("Register")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterDto model)
        {
            if (!ModelState.IsValid) return View(model);

            var result = await _userService.Register(model);

            switch (result)
            {
                case RegisterResult.MobileExists:
                    TempData[ErrorMessage] = "PhoneNumber NOT available";
                    ModelState.AddModelError("Mobile", "PhoneNumber NOT available");
                    break;
                case RegisterResult.Success:
                    TempData[SuccessMessage] = "Successfully Registered";
                    return Redirect("/");
            }

            return View();
        }

        [HttpGet("Login")]
        public async Task<IActionResult> Login()
        {

            return View();
        }

        [HttpPost("Login")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginDto model)
        {
            if (!ModelState.IsValid) return View(model);

            var result = await _userService.Login(model);

            return View();
        }

    }
}
