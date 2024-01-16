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
	}
}
