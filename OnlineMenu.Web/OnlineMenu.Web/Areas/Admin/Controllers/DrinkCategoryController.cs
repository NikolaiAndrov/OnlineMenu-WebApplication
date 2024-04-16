namespace OnlineMenu.Web.Areas.Admin.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.Extensions.Caching.Memory;
	using OnlineMenu.Services.Interfaces;
	using OnlineMenu.Web.ViewModels.DrinkCategory;
	using static Common.GeneralApplicationMessages;
	using static Common.NotificationConstantMessages;
	using static Common.GeneralApplicationConstants;

	public class DrinkCategoryController : BaseAdminController
	{
		private readonly IDrinkCategoryService drinkCategoryService;
		private readonly IDrinkService drinkService;
		private readonly IMemoryCache memoryCache;

        public DrinkCategoryController(IDrinkCategoryService drinkCategoryService, IDrinkService drinkService, IMemoryCache memoryCache)
        {
            this.drinkCategoryService = drinkCategoryService;
			this.drinkService = drinkService;
			this.memoryCache = memoryCache;
        }

		[HttpGet]
        public async Task<IActionResult> All()
		{
			ICollection<DrinkCategoryViewModel> allCategories;

			try
			{
				allCategories = this.memoryCache.Get<ICollection<DrinkCategoryViewModel>>(DrinkCategoryCacheKey);

				if (allCategories == null)
				{
					allCategories = await this.drinkCategoryService.GetAllDrinkCategoriesAsync();

					MemoryCacheEntryOptions options = new MemoryCacheEntryOptions()
						.SetAbsoluteExpiration(TimeSpan.FromMinutes(DrinkCategoryCacheDurationMinutes));

					this.memoryCache.Set(DrinkCategoryCacheKey, allCategories, options);
				}
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
			this.memoryCache.Remove(DrinkCategoryCacheKey);
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
			this.memoryCache.Remove(DrinkCategoryCacheKey);
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

		[HttpPost]
		public async Task<IActionResult> Delete(DrinkCategoryDeleteViewModel model)
		{
			bool isCategoryExisting;

			try
			{
				isCategoryExisting = await this.drinkCategoryService.IsCategoryExistingByIdAsync(model.Id);
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

			try
			{
				await this.drinkService.DeleteDrinksByCategoryIdAsync(model.Id);
				await this.drinkCategoryService.DeleteCategoryAsync(model.Id);
			}
			catch (Exception)
			{
				this.TempData[ErrorMessage] = UnexpectedErrorAdminMessage;
				return this.RedirectToAction("Index", "Home");
			}

			this.TempData[SuccessMessage] = CategoryDeletedMessage;
			this.memoryCache.Remove(DrinkCategoryCacheKey);
			return this.RedirectToAction("All", "DrinkCategory");
		}
	}
}
