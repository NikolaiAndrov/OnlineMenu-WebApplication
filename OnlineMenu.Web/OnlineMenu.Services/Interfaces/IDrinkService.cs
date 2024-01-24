namespace OnlineMenu.Services.Interfaces
{
	using OnlineMenu.Web.ViewModels.Drink;

	public interface IDrinkService
	{
		Task<DrinkQueryModel> GetAllDrinksByQueryModelAsync(DrinkQueryModel drinkQueryModel);

		Task<ICollection<DrinkAllViewModel>> GetFavouriteDrinksAsync(string userId);

		Task<bool> IsDrinkExistingByIdAsync(string drinkId);

		Task AddToFavouriteAsync(string drinkId, string userId);

		Task RemoveFromFavouriteAsync(string drinkId, string userId);

		Task<string> AddDrinkAndReturnIdAsync(DrinkPostModel model);

		Task<DrinkDetailsViewModel> GetDrinkDetailsAsync(string drinkId);

		Task<DrinkPostModel> GetDrinkForEditAsync(string drinkId);

		Task EditDrinkAsync(string drinkId, DrinkPostModel model);

		Task<DrinkDeleteViewModel> GetDrinkForDeleteAsync(string drinkId);

		Task DeleteDrinkAsync(string drinkId);

		Task<bool> IsDrinkInFavouriteAsync(string userId, string drinkId);

		Task<int> GetDrinksCountAsync();

		Task<string> GetDrinkNamesByCategoryIdAsync(int categoryId);

		Task DeleteDrinksByCategoryIdAsync(int categoryId);
	}
}
