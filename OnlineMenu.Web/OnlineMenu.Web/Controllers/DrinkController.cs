namespace OnlineMenu.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
	using OnlineMenu.Services.Interfaces;
	using OnlineMenu.Web.Infrastructure.Extensions;
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

        public async Task<IActionResult> Favourite()
        {
            ICollection<DrinkAllViewModel> favouriteDrinks;

            try
            {
                favouriteDrinks = await this.drinkService.GetFavouriteDrinksAsync(this.User.GetId());
            }
            catch (Exception)
            {
				TempData[ErrorMessage] = UnexpectedErrorMessage;
				return this.RedirectToAction("Index", "Home");
			}

            return this.View(favouriteDrinks);
        }

        public async Task<IActionResult> RemoveFromFavourite(string Id)
        {
            return this.View();
        }

        public async Task<IActionResult> AddToFavourite(string Id)
        {
            return this.View();
        }

        public async Task<IActionResult> Edit(string Id)
        {
            return this.View();
        }

        public async Task<IActionResult> Delete(string Id)
        {
            return this.View();
        }
    }
}
