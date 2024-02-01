namespace OnlineMenu.Web.Areas.Admin.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.Extensions.Caching.Memory;
	using OnlineMenu.Services.Interfaces;
	using OnlineMenu.Web.ViewModels.User;
	using static Common.GeneralApplicationConstants;
	using static Common.GeneralApplicationMessages;
	using static Common.NotificationConstantMessages;

	public class UserController : BaseAdminController
	{
		private readonly IUserService userService;
		private readonly IMemoryCache memoryCache;

		public UserController(IUserService userService, IMemoryCache memoryCache) 
		{
			this.userService = userService;
			this.memoryCache = memoryCache;
		}

		[HttpGet]
		public async Task<IActionResult> All()
		{
			ICollection<UserViewModel> allUsers;

			try
			{
				allUsers = this.memoryCache.Get<ICollection<UserViewModel>>(UsersCacheKey);

				if (allUsers == null)
				{
					allUsers = await this.userService.GetAllUsersAsync();

					MemoryCacheEntryOptions cacheOptions = new MemoryCacheEntryOptions()
						.SetAbsoluteExpiration(TimeSpan.FromMinutes(UsersCacheDurationMinutes));

					this.memoryCache.Set(UsersCacheKey, allUsers, cacheOptions);
				}
			}
			catch (Exception)
			{
				this.TempData[ErrorMessage] = UnexpectedErrorAdminMessage;
				return this.RedirectToAction("Index", "Home");
			}

			return View(allUsers);
		}
	}
}
