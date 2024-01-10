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

		Task AddDrinkAsync(DrinkPostModel model);

		Task DeleteAsync(string drinkId);

		Task<DrinkDetailsViewModel> GetDrinkDetailsAsync(string drinkId);

		Task<DrinkPostModel> GetDrinkForEditAsync(string drinkId);
	}
}
