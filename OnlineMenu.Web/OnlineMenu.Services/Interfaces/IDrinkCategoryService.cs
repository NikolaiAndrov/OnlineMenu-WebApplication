namespace OnlineMenu.Services.Interfaces
{
	public interface IDrinkCategoryService
	{
		Task<ICollection<string>> GetDrinkCategoryNamesAsync();
	}
}
