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
				return this.RedirectToAction("Index", "Home");
			}

			return this.View(allCategories);
		}

		[HttpGet]
		public IActionResult Add()
		{
			DrinkCategoryPostModel model = new DrinkCategoryPostModel();

			return this.View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Add(DrinkCategoryPostModel model)
		{
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

			bool isCategoryExisting;

			try
			{
				isCategoryExisting = await this.drinkCategoryService.IsCategoryExistingByNameAsync(model.Name);
			}
			catch (Exception)
			{
				this.TempData[ErrorMessage] = UnexpectedErrorAdminMessage;
				return this.RedirectToAction("Index", "Home");
			}

			if (isCategoryExisting)
			{
				this.TempData[ErrorMessage] = ExistingCategoryMessage;
				return this.RedirectToAction("All", "DrinkCategory");
			}

			try
			{
				await this.drinkCategoryService.AddNewCategoryAsync(model);
			}
			catch (Exception)
			{
				this.TempData[ErrorMessage] = UnexpectedErrorAdminMessage;
				return this.RedirectToAction("Index", "Home");
			}

			this.TempData[SuccessMessage] = CategoryAddedMessage;
			return this.RedirectToAction("All", "DrinkCategory");
		}
	}
}
