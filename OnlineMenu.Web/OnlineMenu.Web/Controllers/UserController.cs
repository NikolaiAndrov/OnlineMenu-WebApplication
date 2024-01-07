﻿namespace OnlineMenu.Web.Controllers
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;

	[Authorize]
	public class UserController : Controller
	{
		public IActionResult AddFavouriteFood()
		{
			return View();
		}

		public IActionResult RemoveFavouriteFood()
		{
			return View();
		}
	}
}