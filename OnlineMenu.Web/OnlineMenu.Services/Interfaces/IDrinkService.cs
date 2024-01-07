namespace OnlineMenu.Services.Interfaces
{
	using OnlineMenu.Web.ViewModels.Drink;

	public interface IDrinkService
	{
		Task<DrinkQueryModel> GetAllDrinksByQueryModelAsync(DrinkQueryModel drinkQueryModel);
	}
}
