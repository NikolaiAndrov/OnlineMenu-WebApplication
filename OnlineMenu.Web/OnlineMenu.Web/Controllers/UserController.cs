namespace OnlineMenu.Web.Controllers
{
    using Microsoft.AspNetCore.Authentication;
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
	using Microsoft.Extensions.Caching.Memory;
	using OnlineMenu.Data.Models;
    using OnlineMenu.Services.Interfaces;
	using OnlineMenu.Web.Infrastructure.Extensions;
	using OnlineMenu.Web.ViewModels.User;
    using static Common.GeneralApplicationMessages;
    using static Common.NotificationConstantMessages;
    using static Common.GeneralApplicationConstants;

    [Authorize]
    public class UserController : Controller
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUserStore<ApplicationUser> userStore;
        private readonly IUserService userService;
        private readonly IMemoryCache memoryCache;

        public UserController(SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            IUserStore<ApplicationUser> userStore,
            IUserService userService, 
            IMemoryCache memoryCache)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.userStore = userStore;
            this.userService = userService;
            this.memoryCache = memoryCache;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            ApplicationUser user = new ApplicationUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            await this.userManager.SetEmailAsync(user, model.Email);
            await this.userManager.SetUserNameAsync(user, user.Email);

            IdentityResult result = await this.userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                foreach (IdentityError error in result.Errors)
                {
                    this.ModelState.AddModelError(string.Empty, error.Description);
                }

                return this.View(model);    
            }

			await this.signInManager.SignInAsync(user, false);

			this.TempData[SuccessMessage] = SuccessfullRegistrationMessage;
            this.memoryCache.Remove(UsersCacheKey);
            return this.RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string? returnUrl = null)
        {
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            LoginFormModel model = new LoginFormModel
            {
                ReturnUrl = returnUrl,
            };

            return this.View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginFormModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            bool isUserRegistered;

            try
            {
                isUserRegistered = await this.userService.IsUserExistingByEmailAsync(model.Email);
            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = UnexpectedErrorMessage;
                return this.RedirectToAction("Index", "Home");
            }

            if (!isUserRegistered)
            {
                this.TempData[ErrorMessage] = RegisterMessage;
                return this.RedirectToAction("Register", "User");
            }

            var signInResult = await this.signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

            if (!signInResult.Succeeded)
            {
                TempData[ErrorMessage] = LogginErrorMessage;
                return View(model);
            }

            return Redirect(model.ReturnUrl ?? "/Home/Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update()
        {
            UpdateUserPostModel model;

            try
            {
                model = await this.userService.GetUserForUpdateAsync(this.User.GetId());
            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = UnexpectedErrorMessage;
                return this.RedirectToAction("Index", "Home");
            }

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateUserPostModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            try
            {
                await this.userService.UpdateFullNameAsync(this.User.GetId(), model);
            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = UnexpectedErrorMessage;
            }

            this.TempData[SuccessMessage] = FullNameUpdatedMessage;
			return this.RedirectToAction("Index", "Home");
		}
    }
}
