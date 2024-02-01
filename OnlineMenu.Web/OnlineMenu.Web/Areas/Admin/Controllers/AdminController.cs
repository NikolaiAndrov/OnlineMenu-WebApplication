namespace OnlineMenu.Web.Areas.Admin.Controllers
{
	using Microsoft.AspNetCore.Identity;
	using Microsoft.AspNetCore.Mvc;
	using OnlineMenu.Data.Models;
	using OnlineMenu.Services.Interfaces;
	using OnlineMenu.Web.ViewModels.Admin;
	using static Common.GeneralApplicationMessages;
	using static Common.NotificationConstantMessages;
	using static Common.GeneralApplicationConstants;
	using Microsoft.Extensions.Caching.Memory;

	public class AdminController : BaseAdminController
	{
		private readonly IUserService userService;
		private readonly UserManager<ApplicationUser> userManager;
		private readonly IMemoryCache memoryCache;

		public AdminController(IUserService userService, UserManager<ApplicationUser> userManager, IMemoryCache memoryCache)
		{
			this.userService = userService;
			this.userManager = userManager;
			this.memoryCache = memoryCache;
		}

		[HttpGet]
		public IActionResult Add()
		{
			AdminPostModel model = new AdminPostModel();
			return this.View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Add(AdminPostModel model)
		{
			if (!ModelState.IsValid)
			{
				return this.View(model);
			}

			bool isUserExisting;

			try
			{
				isUserExisting = await this.userService.IsUserExistingByEmailAsync(model.Email);
			}
			catch (Exception)
			{
				this.TempData[ErrorMessage] = UnexpectedErrorAdminMessage;
				return this.RedirectToAction("Index", "Home");
			}

			if (!isUserExisting)
			{
				this.TempData[ErrorMessage] = UserNotFoundByEmailMessage;
				return this.RedirectToAction("All", "User");
			}

			ApplicationUser adminUser = await this.userManager.FindByEmailAsync(model.Email);
			bool isAdmin = await this.userManager.IsInRoleAsync(adminUser, AdminRoleName);

			if (isAdmin)
			{
				this.TempData[ErrorMessage] = AdminAlreadyExistingMessage;
				return this.RedirectToAction("All", "User");
			}

			await userManager.AddToRoleAsync(adminUser, AdminRoleName);
			this.TempData[SuccessMessage] = AdminAddedMessage;
			this.memoryCache.Remove(UsersCacheKey);
			return this.RedirectToAction("All", "User");
		}

		[HttpGet]
		public IActionResult Remove()
		{
			AdminPostModel model = new AdminPostModel();
			return this.View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Remove(AdminPostModel model)
		{
			if (!ModelState.IsValid)
			{
				return this.View(model);
			}

			bool isUserExisting;

			try
			{
				isUserExisting = await this.userService.IsUserExistingByEmailAsync(model.Email);
			}
			catch (Exception)
			{
				this.TempData[ErrorMessage] = UnexpectedErrorAdminMessage;
				return this.RedirectToAction("Index", "Home");
			}

			if (!isUserExisting)
			{
				this.TempData[ErrorMessage] = UserNotFoundByEmailMessage;
				return this.RedirectToAction("All", "User");
			}

			ApplicationUser adminUser = await this.userManager.FindByEmailAsync(model.Email);
			bool isAdmin = await this.userManager.IsInRoleAsync(adminUser, AdminRoleName);

			if (!isAdmin)
			{
				this.TempData[ErrorMessage] = AdminNotExistingMessage;
				return this.RedirectToAction("All", "User");
			}

			await this.userManager.RemoveFromRoleAsync(adminUser, AdminRoleName);
			this.TempData[SuccessMessage] = AdminRemovedMessage;
			this.memoryCache.Remove(UsersCacheKey);
			return this.RedirectToAction("All", "User");
		}
	}
}
