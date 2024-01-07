namespace OnlineMenu.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using OnlineMenu.Services.Interfaces;
    using OnlineMenu.Web.ViewModels.Food;
    using static Common.NotificationConstantMessages;
    using static Common.GeneralApplicationMessages;
	using OnlineMenu.Web.Infrastructure.Extensions;

	[Authorize]
    public class FoodController : Controller
    {
        private readonly IFoodService foodService;
        private readonly IFoodCategoryService foodCategoryService;

        public FoodController(IFoodService foodService, IFoodCategoryService foodCategoryService)
        {
            this.foodService = foodService;
            this.foodCategoryService = foodCategoryService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> All([FromQuery]FoodQueryModel foodQueryModel)
        {
            try
            {
                await this.foodService.GetAllFoodByQueryModelAsync(foodQueryModel);
                foodQueryModel.Categories = await this.foodCategoryService.GetFoodCategoryNamesAsync();
            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = UnexpectedErrorMessage;
                return this.RedirectToAction("Index", "Home");
            }

            return this.View(foodQueryModel);
        }

        public async Task<IActionResult> Favourite()
        {
            ICollection<FoodAllViewModel> favouriteFood;

            try
            {
                favouriteFood = await this.foodService.GetFavouriteFoodAsync(this.User.GetId());
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = UnexpectedErrorMessage;
                return this.RedirectToAction("Index", "Home");
            }

            return this.View(favouriteFood);
        }

        public async Task<IActionResult> RemoveFromFavourite(string Id)
        {
            return this.View();
        }

        public async Task<IActionResult> AddToFavourite(string Id)
        {
            bool isFoodExisting;

            try
            {
                isFoodExisting = await this.foodService.IsFoodExistingByIdAsync(Id);
            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = UnexpectedErrorMessage;
				return this.RedirectToAction("Index", "Home");
			}

            if (!isFoodExisting)
            {
				this.TempData[ErrorMessage] = ItemNotFoundMessage;
				return this.RedirectToAction("Index", "Home");
			}

            try
            {
                string userId = this.User.GetId();
                await this.foodService.AddToFavouriteAsync(Id, userId);
            }
            catch (Exception)
            {
				this.TempData[ErrorMessage] = UnexpectedErrorMessage;
				return this.RedirectToAction("Index", "Home");
			}

            return this.RedirectToAction("Favourite", "Food");
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
