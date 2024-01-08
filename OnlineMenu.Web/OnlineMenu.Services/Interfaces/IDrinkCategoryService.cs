namespace OnlineMenu.Services.Interfaces
{
	using OnlineMenu.Web.ViewModels.DrinkCategory;

	public interface IDrinkCategoryService
	{
		Task<ICollection<string>> GetDrinkCategoryNamesAsync();

		Task<ICollection<DrinkCategoryPostModel>> GetDrinkCategoriesPostAsync();
	}
}
