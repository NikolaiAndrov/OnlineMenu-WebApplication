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

	public class AdminController : BaseAdminController
	{
		private readonly IUserService userService;
		private readonly UserManager<ApplicationUser> userManager;

		public AdminController(IUserService userService, UserManager<ApplicationUser> userManager)
		{
			this.userService = userService;
			this.userManager = userManager;
		}

		[Route("Admin/Add")]
		[HttpGet]
		public IActionResult Add()
		{
			AdminPostModel model = new AdminPostModel();
			return this.View(model);
		}

		[Route("Admin/Add")]
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
			return this.RedirectToAction("All", "User");
		}

		[Route("Admin/Remove")]
		[HttpGet]
		public IActionResult Remove()
		{
			AdminPostModel model = new AdminPostModel();
			return this.View(model);
		}

		[Route("Admin/Remove")]
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
			return this.RedirectToAction("All", "User");
		}
	}
}
