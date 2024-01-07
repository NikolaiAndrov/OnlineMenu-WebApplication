namespace OnlineMenu.Services
{
	using Microsoft.EntityFrameworkCore;
	using OnlineMenu.Data;
	using OnlineMenu.Services.Interfaces;

	public class DrinkCategoryService : IDrinkCategoryService
	{
		private readonly OnlineMenuDbContext dbContext;

        public DrinkCategoryService(OnlineMenuDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ICollection<string>> GetDrinkCategoryNamesAsync()
		{
			ICollection<string> drinkCategories = await this.dbContext.DrinksCategories
				.Where(dc => dc.IsDeleted == false)
				.Select(dc => dc.Name)
				.ToArrayAsync();

			return drinkCategories;
		}
	}
}
