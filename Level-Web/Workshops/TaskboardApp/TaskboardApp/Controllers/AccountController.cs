namespace TaskboardApp.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using TaskboardApp.ViewModels.Account;

    public class AccountController : BaseController
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return this.View(new RegisterViewModel());
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new IdentityUser()
            {
                UserName = model.Username,
                Email = model.Email,
                EmailConfirmed = true,
            };

            var result = await userManager.CreateAsync(user, model.Password);
            //userManager-a ще хешира парола

            if (result.Succeeded)
            {
                //await this.signInManager.SignInAsync(user, false);

                return RedirectToAction("Login", "User");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return this.View(new LoginViewModel());
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            IdentityUser user = await this.userManager.FindByEmailAsync(model.Email);

            if (user != null)
            {
                var result =
                    await this.signInManager.PasswordSignInAsync(user, model.Password, false, false);

                if (result.Succeeded)
                {
                    return this.RedirectToAction("Index", "Home");
                }
            }

            this.ModelState.AddModelError("", "Invalid login");

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await this.signInManager.SignOutAsync();
            return this.RedirectToAction("Index", "Home");
        }

        //---------------------------------------
        //logic for external logins

        //[HttpPost]
        //[AllowAnonymous]
        //public IActionResult ExternalLogin(string provider, string? returnUrl = null)
        //{
        //    // Request a redirect to the external login provider.
        //    var redirectUrl = Url.Action("ExternalLoginCallback", "User", new { returnUrl });
        //    var properties = this.signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
        //    return new ChallengeResult(provider, properties);
        //}

        //[AllowAnonymous]
        //public async Task<IActionResult> ExternalLoginCallback(string? returnUrl = null, string? remoteError = null)
        //{
        //    returnUrl = returnUrl ?? Url.Content("~/");
        //    if (remoteError != null)
        //    {
        //        TempData["ErrorMessage"] = $"Error from external provider: {remoteError}";
        //        return RedirectToAction("Login", new { ReturnUrl = returnUrl });
        //    }
        //    var info = await this.signInManager.GetExternalLoginInfoAsync();

        //    if (info == null)
        //    {
        //        TempData["ErrorMessage"] = "Error loading external login information.";
        //        return RedirectToPage("./Login", new { ReturnUrl = returnUrl });
        //    }

        //    // Sign in the user with this external login provider if the user already has a login.
        //    var result = await this.signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);
        //    if (result.Succeeded)
        //    {
        //        return LocalRedirect(returnUrl);
        //    }
        //    if (result.IsLockedOut)
        //    {
        //        return RedirectToPage("./Lockout");
        //    }
        //    else
        //    {
        //        // If the user does not have an account, then ask the user to create an account.
        //        return RedirectToAction(nameof(Register));
        //    }
        //}
    }
}
