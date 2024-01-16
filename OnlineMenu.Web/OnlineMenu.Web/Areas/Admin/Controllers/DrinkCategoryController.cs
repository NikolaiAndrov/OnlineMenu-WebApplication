namespace OnlineMenu.Web.Areas.Admin.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	using OnlineMenu.Services.Interfaces;
	using OnlineMenu.Web.ViewModels.DrinkCategory;
	using static Common.GeneralApplicationMessages;
	using static Common.NotificationConstantMessages;
	using static Common.GeneralApplicationConstants;

	public class DrinkCategoryController : BaseAdminController
	{
		private readonly IDrinkCategoryService drinkCategoryService;

        public DrinkCategoryController(IDrinkCategoryService drinkCategoryService)
        {
            this.drinkCategoryService = drinkCategoryService;
        }

		[HttpGet]
        public async Task<IActionResult> All()
		{
			ICollection<DrinkCategoryViewModel> allCategories;

			try
			{
				allCategories = await this.drinkCategoryService.GetAllDrinkCategoriesAsync();
			}
			catch (Exception)
			{
				this.TempData[ErrorMessage] = UnexpectedErrorAdminMessage;
				return this.RedirectToAction("Index", "Home", new { Area = AdminAreaName });
			}

			return this.View(allCategories);
		}

		[HttpGet]
		public IActionResult Add()
		{
			DrinkCategoryPostModel model = new DrinkCategoryPostModel();

			return this.View(model);
		}
	}
}
