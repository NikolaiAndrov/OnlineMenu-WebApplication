﻿namespace OnlineMenu.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
	using OnlineMenu.Services.Interfaces;
	using OnlineMenu.Web.ViewModels.Drink;
    using static Common.GeneralApplicationMessages;
    using static Common.NotificationConstantMessages;

	[Authorize]
    public class DrinkController : Controller
    {
        private readonly IDrinkService drinkService;
        private readonly IDrinkCategoryService drinkCategoryService;

        public DrinkController(IDrinkService drinkService, IDrinkCategoryService drinkCategoryService)
        {
            this.drinkService = drinkService;
            this.drinkCategoryService = drinkCategoryService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> All(DrinkQueryModel drinkQueryModel)
        {
            try
            {
                await this.drinkService.GetAllDrinksByQueryModelAsync(drinkQueryModel);
                drinkQueryModel.Categories = await this.drinkCategoryService.GetDrinkCategoryNamesAsync();
            }
            catch (Exception)
            {
				this.TempData[ErrorMessage] = UnexpectedErrorMessage;
				return this.RedirectToAction("Index", "Home");
			}

            return this.View(drinkQueryModel);
        }
    }
}
