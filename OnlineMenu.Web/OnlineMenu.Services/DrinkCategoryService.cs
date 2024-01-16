namespace OnlineMenu.Services
{
	using Microsoft.EntityFrameworkCore;
	using OnlineMenu.Data;
	using OnlineMenu.Services.Interfaces;
	using OnlineMenu.Web.ViewModels.DrinkCategory;

	public class DrinkCategoryService : IDrinkCategoryService
	{
		private readonly OnlineMenuDbContext dbContext;

        public DrinkCategoryService(OnlineMenuDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

		public async Task<ICollection<DrinkCategoryViewModel>> GetAllDrinkCategoriesAsync()
		{
			ICollection<DrinkCategoryViewModel> drinkCategories = await this.dbContext.DrinksCategories
				.Where(dc => dc.IsDeleted == false)
				.Select(dc => new DrinkCategoryViewModel
				{
					Id = dc.Id,
					Name = dc.Name
				})
				.ToArrayAsync();

			return drinkCategories;
		}

		public async Task<ICollection<string>> GetDrinkCategoryNamesAsync()
		{
			ICollection<string> drinkCategories = await this.dbContext.DrinksCategories
				.Where(dc => dc.IsDeleted == false)
				.Select(dc => dc.Name)
				.ToArrayAsync();

			return drinkCategories;
		}

		public async Task<bool> IsCategoryExistingByIdAsync(int id)
			=> await this.dbContext.DrinksCategories.AnyAsync(dc => dc.IsDeleted == false && dc.Id == id);
	}
}
