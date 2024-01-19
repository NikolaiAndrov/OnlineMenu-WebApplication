namespace OnlineMenu.Web.Areas.Admin.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	using OnlineMenu.Services.Interfaces;
	using Microsoft.Extensions.Caching.Memory;
	using OnlineMenu.Web.ViewModels.Manager;
	using static Common.NotificationConstantMessages;
	using static Common.GeneralApplicationMessages;
	using static Common.GeneralApplicationConstants;

	public class ManagerController : BaseAdminController
	{
		private readonly IManagerService managerService;
		private readonly IUserService userService;
		private readonly IMemoryCache memoryCache;

		public ManagerController(IManagerService managerService, IUserService userService, IMemoryCache memoryCache)
		{
			this.managerService = managerService;
			this.userService = userService;
			this.memoryCache = memoryCache;
		}

		[HttpGet]
		public IActionResult Add()
		{
			return this.View();
		}

		[HttpPost]
		public async Task<IActionResult> Add(AddManagerPostModel model)
		{
			if (!this.ModelState.IsValid)
			{
				return this.View(model);
			}

			bool isManagerExistingByEmail;
			bool isUserExistingByEmail;

			try
			{
				isManagerExistingByEmail = await managerService.IsManagerExistingByUserEmailAsync(model.Email);
				isUserExistingByEmail = await userService.IsUserExistingByEmailAsync(model.Email);
			}
			catch (Exception)
			{
				TempData[ErrorMessage] = UnexpectedErrorAdminMessage;
				return this.RedirectToAction("Index", "Home");
			}

			if (isManagerExistingByEmail)
			{
				TempData[ErrorMessage] = ExistingManagerErrorMessage;
				return this.RedirectToAction("All", "User");
			}

			if (!isUserExistingByEmail)
			{
				TempData[ErrorMessage] = UserNotExistingErrorMessage;
				return this.RedirectToAction("All", "User");
			}

			try
			{
				string userToManagerId = await userService.GetUserIdByEmailAsync(model.Email);
				await managerService.AddManagerAsync(model, userToManagerId);
			}
			catch (Exception)
			{
				TempData[ErrorMessage] = UnexpectedErrorAdminMessage;
			}

			TempData[SuccessMessage] = ManagerAddedSuccessfullyMessage;
			this.memoryCache.Remove(UsersCacheKey);
			return this.RedirectToAction("All", "User");
		}

		[HttpGet]
		public IActionResult Remove()
		{
			RemoveManagerPostModel model = new RemoveManagerPostModel();
			return this.View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Remove(RemoveManagerPostModel model)
		{
			if (!this.ModelState.IsValid)
			{
				return this.View(model);
			}

			bool isManagerExistingByEmail;

			try
			{
				isManagerExistingByEmail = await managerService.IsManagerExistingByUserEmailAsync(model.Email);
			}
			catch (Exception)
			{
				TempData[ErrorMessage] = UnexpectedErrorAdminMessage;
				return this.RedirectToAction("Index", "Home");
			}

			if (!isManagerExistingByEmail)
			{
				TempData[ErrorMessage] = ManagerNotExistingMessage;
				return this.RedirectToAction("All", "User");
			}

			try
			{
				string userManagerId = await this.userService.GetUserIdByEmailAsync(model.Email);
				await this.managerService.RemoveManagerByUserIdAsync(userManagerId);
			}
			catch (Exception)
			{
				TempData[ErrorMessage] = UnexpectedErrorAdminMessage;
				return this.RedirectToAction("Index", "Home");
			}

			this.TempData[SuccessMessage] = ManagerRemovedMessage;
			this.memoryCache.Remove(UsersCacheKey);
			return this.RedirectToAction("All", "User");
		}
	}
}
