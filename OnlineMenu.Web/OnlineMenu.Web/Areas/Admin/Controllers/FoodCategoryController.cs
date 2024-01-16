namespace OnlineMenu.Web.Areas.Admin.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	using OnlineMenu.Services.Interfaces;
	using OnlineMenu.Web.ViewModels.FoodCategory;
	using static Common.GeneralApplicationMessages;
	using static Common.NotificationConstantMessages;
	using static Common.GeneralApplicationConstants;

	public class FoodCategoryController : BaseAdminController
	{
		private readonly IFoodCategoryService foodCategoryService;

		public FoodCategoryController(IFoodCategoryService foodCategoryService) 
		{
			this.foodCategoryService = foodCategoryService;
		}

		[HttpGet]
		public async Task<IActionResult> All()
		{
			ICollection<FoodCategoryViewModel> allCategories;

			try
			{
				allCategories = await this.foodCategoryService.GetAllFoodCategoriesAsync();
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
			FoodCategoryPostModel model = new FoodCategoryPostModel();

			return this.View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Add(FoodCategoryPostModel model)
		{
			if (!ModelState.IsValid)
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
				return this.RedirectToAction("Index", "Home", new { Area = AdminAreaName });
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
				return this.RedirectToAction("Index", "Home", new { Area = AdminAreaName });
			}

			this.TempData[SuccessMessage] = CategoryAddedMessage;
			return this.RedirectToAction("All", "FoodCategory");
		}
	}
}
