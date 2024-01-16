namespace OnlineMenu.Web.Areas.Admin.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	using OnlineMenu.Services.Interfaces;
	using OnlineMenu.Web.ViewModels.FoodCategory;

	public class FoodCategoryController : BaseAdminController
	{
		private readonly IFoodCategoryService foodCategoryService;

		public FoodCategoryController(IFoodCategoryService foodCategoryService) 
		{
			this.foodCategoryService = foodCategoryService;
		}

		public async Task<IActionResult> All()
		{
			ICollection<FoodCategoryViewModel> allCategories = await this.foodCategoryService.GetAllFoodCategoriesAsync();

			return this.View(allCategories);
		}
	}
}
