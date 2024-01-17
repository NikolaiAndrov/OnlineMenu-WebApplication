namespace OnlineMenu.Services.Interfaces
{
	using OnlineMenu.Web.ViewModels.DrinkCategory;

	public interface IDrinkCategoryService
	{
		Task<ICollection<string>> GetDrinkCategoryNamesAsync();

		Task<ICollection<DrinkCategoryViewModel>> GetAllDrinkCategoriesAsync();

		Task<bool> IsCategoryExistingByIdAsync(int id);

		Task<bool> IsCategoryExistingByNameAsync(string name);

		Task AddNewCategoryAsync(DrinkCategoryPostModel model);

		Task<DrinkCategoryPostModel> GetCategoryForEditAsync(int id);

		Task EditCategoryAsync(int id, DrinkCategoryPostModel model);

		Task<DrinkCategoryDeleteViewModel> GetCategoryForDeleteAsync(int id);

	}
}
