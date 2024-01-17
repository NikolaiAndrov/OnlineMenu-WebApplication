namespace OnlineMenu.Web.Areas.Admin.Controllers
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using OnlineMenu.Services.Interfaces;
	using OnlineMenu.Web.Infrastructure.Extensions;
	using static Common.NotificationConstantMessages;
	using static Common.GeneralApplicationMessages;
	using OnlineMenu.Web.ViewModels.Manager;

	public class ManagerController : BaseAdminController
	{
		private readonly IManagerService managerService;
		private readonly IUserService userService;

		public ManagerController(IManagerService managerService, IUserService userService)
		{
			this.managerService = managerService;
			this.userService = userService;

		}

		[HttpGet]
		public IActionResult Add()
		{
			return this.View();
		}

		[HttpPost]
		public async Task<IActionResult> Add(AddManagerPostModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
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
				return RedirectToAction("Index", "Home");
			}

			if (isManagerExistingByEmail)
			{
				TempData[ErrorMessage] = ExistingManagerErrorMessage;
				return RedirectToAction("All", "User");
			}

			if (!isUserExistingByEmail)
			{
				TempData[ErrorMessage] = UserNotExistingErrorMessage;
				return RedirectToAction("All", "User");
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
			return RedirectToAction("All", "User");
		}
	}
}
