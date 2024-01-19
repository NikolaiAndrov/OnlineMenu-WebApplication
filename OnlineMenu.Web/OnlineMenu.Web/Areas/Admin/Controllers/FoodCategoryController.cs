namespace OnlineMenu.Web.Areas.Admin.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.Extensions.Caching.Memory;
	using OnlineMenu.Services.Interfaces;
	using OnlineMenu.Web.ViewModels.FoodCategory;
	using static Common.GeneralApplicationMessages;
	using static Common.NotificationConstantMessages;
	using static Common.GeneralApplicationConstants;

	public class FoodCategoryController : BaseAdminController
	{
		private readonly IFoodCategoryService foodCategoryService;
		private readonly IFoodService foodService;
		private readonly IMemoryCache memoryCache;

		public FoodCategoryController(IFoodCategoryService foodCategoryService, IFoodService foodService, IMemoryCache memoryCache) 
		{
			this.foodCategoryService = foodCategoryService;
			this.foodService = foodService;
			this.memoryCache = memoryCache;
		}

		[HttpGet]
		public async Task<IActionResult> All()
		{
			ICollection<FoodCategoryViewModel> allCategories;

			try
			{
				allCategories = this.memoryCache.Get<ICollection<FoodCategoryViewModel>>(FoodCategoryCacheKey);

				if (allCategories == null)
				{
					allCategories = await this.foodCategoryService.GetAllFoodCategoriesAsync();

					MemoryCacheEntryOptions options = new MemoryCacheEntryOptions()
						.SetAbsoluteExpiration(TimeSpan.FromMinutes(FoodCategoryCacheDurationMinutes));
						
					this.memoryCache.Set(FoodCategoryCacheKey, allCategories, options);
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
			FoodCategoryPostModel model = new FoodCategoryPostModel();

			return this.View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Add(FoodCategoryPostModel model)
		{
			if (!this.ModelState.IsValid)
			{
				return this.View(model);
			}

			bool isCategoryExisting;

			try
			{
				isCategoryExisting = await this.foodCategoryService.IsCategoryExistingByNameAsync(model.Name);
			}
			catch (Exception)
			{
				this.TempData[ErrorMessage] = UnexpectedErrorAdminMessage;
				return this.RedirectToAction("Index", "Home");
			}

			if (isCategoryExisting)
			{
				this.TempData[ErrorMessage] = ExistingCategoryMessage;
				return this.RedirectToAction("All", "FoodCategory");
			}

			try
			{
				await this.foodCategoryService.AddNewCategoryAsync(model);
			}
			catch (Exception)
			{
				this.TempData[ErrorMessage] = UnexpectedErrorAdminMessage;
				return this.RedirectToAction("Index", "Home");
			}

			this.TempData[SuccessMessage] = CategoryAddedMessage;
			this.memoryCache.Remove(FoodCategoryCacheKey);
			return this.RedirectToAction("All", "FoodCategory");
		}

		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			bool isCategoryExisting;

			try
			{
				isCategoryExisting = await this.foodCategoryService.IsCategoryExistingByIdAsync(id);
			}
			catch (Exception)
			{
				this.TempData[ErrorMessage] = UnexpectedErrorAdminMessage;
				return this.RedirectToAction("Index", "Home");
			}

			if (!isCategoryExisting)
			{
				this.TempData[ErrorMessage] = CategoryNotExistingMessage;
				return this.RedirectToAction("All", "FoodCategory");
			}

			FoodCategoryPostModel model;

			try
			{
				model = await this.foodCategoryService.GetCategoryForEditAsync(id);
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
		public async Task<IActionResult> Edit(int id, FoodCategoryPostModel model)
		{
			bool isCategoryExisting;

			try
			{
				isCategoryExisting = await this.foodCategoryService.IsCategoryExistingByIdAsync(id);
			}
			catch (Exception)
			{
				this.TempData[ErrorMessage] = UnexpectedErrorAdminMessage;
				return this.RedirectToAction("Index", "Home");
			}

			if (!isCategoryExisting)
			{
				this.TempData[ErrorMessage] = CategoryNotExistingMessage;
				return this.RedirectToAction("All", "FoodCategory");
			}

			if (!this.ModelState.IsValid)
			{
				return this.View(model);
			}

			try
			{
				await this.foodCategoryService.EditCategoryAsync(model, id);
			}
			catch (Exception)
			{
				this.TempData[ErrorMessage] = UnexpectedErrorAdminMessage;
				return this.RedirectToAction("Index", "Home");
			}

			this.TempData[SuccessMessage] = CategoryEditedMessage;
			this.memoryCache.Remove(FoodCategoryCacheKey);
			return this.RedirectToAction("All", "FoodCategory");
		}

		[HttpGet]
		public async Task<IActionResult> Delete(int id)
		{
			bool isCategoryExisting;

			try
			{
				isCategoryExisting = await this.foodCategoryService.IsCategoryExistingByIdAsync(id);
			}
			catch (Exception)
			{
				this.TempData[ErrorMessage] = UnexpectedErrorAdminMessage;
				return this.RedirectToAction("Index", "Home");
			}

			if (!isCategoryExisting)
			{
				this.TempData[ErrorMessage] = CategoryNotExistingMessage;
				return this.RedirectToAction("All", "FoodCategory");
			}

			FoodCategoryDeleteViewModel model;

			try
			{
				model = await this.foodCategoryService.GetCategoryForDeleteAsync(id);
				model.ItemsForDelete = await this.foodService.GetFoodNamesByCategoryIdAsync(id);
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
		public async Task<IActionResult> Delete(FoodCategoryDeleteViewModel model) 
		{
			bool isCategoryExisting;

			try
			{
				isCategoryExisting = await this.foodCategoryService.IsCategoryExistingByIdAsync(model.Id);
			}
			catch (Exception)
			{
				this.TempData[ErrorMessage] = UnexpectedErrorAdminMessage;
				return this.RedirectToAction("Index", "Home");
			}

			if (!isCategoryExisting)
			{
				this.TempData[ErrorMessage] = CategoryNotExistingMessage;
				return this.RedirectToAction("All", "FoodCategory");
			}

			try
			{
				await this.foodService.DeleteFoodByCategoryIdAsync(model.Id);
				await this.foodCategoryService.DeleteCategoryAsync(model.Id);
			}
			catch (Exception)
			{
				this.TempData[ErrorMessage] = UnexpectedErrorAdminMessage;
				return this.RedirectToAction("Index", "Home");
			}

			this.TempData[SuccessMessage] = CategoryDeletedMessage;
			this.memoryCache.Remove(FoodCategoryCacheKey);
			return this.RedirectToAction("All", "FoodCategory");
		}
	}
}
