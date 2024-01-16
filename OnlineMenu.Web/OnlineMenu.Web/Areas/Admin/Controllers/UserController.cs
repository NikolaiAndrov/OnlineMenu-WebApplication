namespace OnlineMenu.Web.Areas.Admin.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	using OnlineMenu.Services.Interfaces;
	using OnlineMenu.Web.ViewModels.User;

	public class UserController : BaseAdminController
	{
		private readonly IUserService userService;

		public UserController(IUserService userService) 
		{
			this.userService = userService;
		}

		[Route("User/All")]
		public async Task<IActionResult> All()
		{
			ICollection<UserViewModel> allUsers = await this.userService.GetAllUsersAsync();

			return View(allUsers);
		}
	}
}
