namespace OnlineMenu.Web.Areas.Admin.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	using OnlineMenu.Services.Interfaces;
	using OnlineMenu.Web.ViewModels.DrinkCategory;
	using static Common.GeneralApplicationMessages;
	using static Common.NotificationConstantMessages;

	public class DrinkCategoryController : BaseAdminController
	{
		private readonly IDrinkCategoryService drinkCategoryService;
		private readonly IDrinkService drinkService;

        public DrinkCategoryController(IDrinkCategoryService drinkCategoryService, IDrinkService drinkService)
        {
            this.drinkCategoryService = drinkCategoryService;
			this.drinkService = drinkService;
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

		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			bool isCategoryExisting;

			try
			{
				isCategoryExisting = await this.drinkCategoryService.IsCategoryExistingByIdAsync(id);
			}
			catch (Exception)
			{
				this.TempData[ErrorMessage] = UnexpectedErrorAdminMessage;
				return this.RedirectToAction("Index", "Home");
			}

			if (!isCategoryExisting)
			{
				this.TempData[ErrorMessage] = CategoryNotExistingMessage;
				return this.RedirectToAction("All", "DrinkCategory");
			}

			DrinkCategoryPostModel model;

			try
			{
				model = await this.drinkCategoryService.GetCategoryForEditAsync(id);
			}
			catch (Exception)
			{
				this.TempData[ErrorMessage] = UnexpectedErrorAdminMessage;
				return this.RedirectToAction("Index", "Home");
			}

			this.TempData[InfoMessage] = EditCategoryInfoMessage;
			return this.View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id, DrinkCategoryPostModel model)
		{
			bool isCategoryExisting;

			try
			{
				isCategoryExisting = await this.drinkCategoryService.IsCategoryExistingByIdAsync(id);
			}
			catch (Exception)
			{
				this.TempData[ErrorMessage] = UnexpectedErrorAdminMessage;
				return this.RedirectToAction("Index", "Home");
			}

			if (!isCategoryExisting)
			{
				this.TempData[ErrorMessage] = CategoryNotExistingMessage;
				return this.RedirectToAction("All", "DrinkCategory");
			}

			if (!this.ModelState.IsValid)
			{
				return this.View(model);
			}

			try
			{
				await this.drinkCategoryService.EditCategoryAsync(id, model);
			}
			catch (Exception)
			{
				this.TempData[ErrorMessage] = UnexpectedErrorAdminMessage;
				return this.RedirectToAction("Index", "Home");
			}

			this.TempData[SuccessMessage] = CategoryEditedMessage;
			return this.RedirectToAction("All", "DrinkCategory");
		}

		[HttpGet]
		public async Task<IActionResult> Delete(int id)
		{
			bool isCategoryExisting;

			try
			{
				isCategoryExisting = await this.drinkCategoryService.IsCategoryExistingByIdAsync(id);
			}
			catch (Exception)
			{
				this.TempData[ErrorMessage] = UnexpectedErrorAdminMessage;
				return this.RedirectToAction("Index", "Home");
			}

			if (!isCategoryExisting)
			{
				this.TempData[ErrorMessage] = CategoryNotExistingMessage;
				return this.RedirectToAction("All", "DrinkCategory");
			}

			DrinkCategoryDeleteViewModel model;

			try
			{
				model = await this.drinkCategoryService.GetCategoryForDeleteAsync(id);
				model.ItemsForDelete = await this.drinkService.GetDrinkNamesByCategoryIdAsync(id);
			}
			catch (Exception)
			{
				this.TempData[ErrorMessage] = UnexpectedErrorAdminMessage;
				return this.RedirectToAction("Index", "Home");
			}

			this.TempData[ErrorMessage] = DeleteCategoryQWarningMessage;
			return this.View(model);
		}
	}
}
