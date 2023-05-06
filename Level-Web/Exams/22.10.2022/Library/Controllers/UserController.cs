namespace Library.Controllers
{
    using Library.Core.Data.Entities;
    using Library.Services.DTOs;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class UserController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public UserController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("All", "Books");
            }

            return View(new RegisterDto());
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterDto regDto)
        {
            if (!ModelState.IsValid)
            {
                return View(regDto);
            }

            ApplicationUser user = new ApplicationUser()
            {
                UserName = regDto.UserName,
                Email = regDto.Email,
            };

            var result = await userManager.CreateAsync(user, regDto.Password);

            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Login));
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(regDto);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("All", "Books");
            }

            return View(new LoginDto());
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = await this.userManager.FindByNameAsync(loginDto.UserName);

            if (user != null)
            {
                var status = await signInManager.PasswordSignInAsync(user, loginDto.Password, false, false);

                if (status.Succeeded)
                {
                    await signInManager.SignInAsync(user, false);
                    return RedirectToAction("All", "Books");
                }
            }

            ModelState.AddModelError("", "Неуспешен вход, опитайте отново");
            return View(loginDto);
        }

        public async Task<IActionResult> Logout()
        {
            await this.signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
