using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using LinkShortener.Application.DTOs.Account;
using LinkShortener.Application.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
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

            switch (result)
            {
                case LoginResult.NotFound:
                    TempData[ErrorMessage] = "User NOT Found";
                    break;
                case LoginResult.NotActivated:
                    TempData[WarningMessage] = "User is NOT Activated";
                    break;
                case LoginResult.Success:
                    var user = await _userService.Get(model.Mobile);
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, user.Mobile),
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principle = new ClaimsPrincipal(identity);
                    var properties = new AuthenticationProperties()
                    {
                        IsPersistent = model.RememberMe
                    };
                    await HttpContext.SignInAsync(principle, properties);
                    TempData[SuccessMessage] = "Successfully Logged in";
                    return Redirect("/");

            }

            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}
