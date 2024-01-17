namespace OnlineMenu.Services
{
	using Microsoft.EntityFrameworkCore;
	using OnlineMenu.Data;
	using OnlineMenu.Data.Models;
	using OnlineMenu.Services.Interfaces;
	using OnlineMenu.Web.ViewModels.DrinkCategory;

	public class DrinkCategoryService : IDrinkCategoryService
	{
		private readonly OnlineMenuDbContext dbContext;

        public DrinkCategoryService(OnlineMenuDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

		public async Task AddNewCategoryAsync(DrinkCategoryPostModel model)
		{
			DrinkCategory drinkCategory = new DrinkCategory
			{
				Name = model.Name
			};

			await this.dbContext.DrinksCategories.AddAsync(drinkCategory);
			await this.dbContext.SaveChangesAsync();
		}

		public async Task DeleteCategoryAsync(int id)
		{
			DrinkCategory drinkCategory = await this.dbContext.DrinksCategories
				.Where(dc => dc.IsDeleted == false && dc.Id == id)
				.FirstAsync();

			drinkCategory.IsDeleted = true;

			await this.dbContext.SaveChangesAsync();
		}

		public async Task EditCategoryAsync(int id, DrinkCategoryPostModel model)
		{
			DrinkCategory drinkCategory = await this.dbContext.DrinksCategories
				.FirstAsync(dc => dc.IsDeleted == false && dc.Id == id);

			drinkCategory.Name = model.Name;

			await this.dbContext.SaveChangesAsync();
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

		public async Task<DrinkCategoryDeleteViewModel> GetCategoryForDeleteAsync(int id)
		{
			DrinkCategoryDeleteViewModel model = await this.dbContext.DrinksCategories
				.Where(dc => dc.IsDeleted == false && dc.Id == id)
				.Select(dc => new DrinkCategoryDeleteViewModel
				{
					Id = dc.Id,
					Name = dc.Name
				})
				.FirstAsync();

			return model;
		}

		public async Task<DrinkCategoryPostModel> GetCategoryForEditAsync(int id)
		{
			DrinkCategoryPostModel model = await this.dbContext.DrinksCategories
				.Where(dc => dc.IsDeleted == false && dc.Id == id)
				.Select(dc => new DrinkCategoryPostModel
				{
					Name = dc.Name
				})
				.FirstAsync();

			return model;
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

		public async Task<bool> IsCategoryExistingByNameAsync(string name)
			=> await this.dbContext.DrinksCategories.AnyAsync(dc => dc.IsDeleted == false && dc.Name.ToLower() == name.ToLower());
	}
}
