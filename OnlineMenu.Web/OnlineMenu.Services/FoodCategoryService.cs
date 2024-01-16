namespace OnlineMenu.Services
{
    using Microsoft.EntityFrameworkCore;
    using OnlineMenu.Data;
	using OnlineMenu.Data.Models;
	using OnlineMenu.Services.Interfaces;
	using OnlineMenu.Web.ViewModels.FoodCategory;

	public class FoodCategoryService : IFoodCategoryService
    {
        private readonly OnlineMenuDbContext dbContext;

        public FoodCategoryService(OnlineMenuDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

		public async Task AddNewCategoryAsync(FoodCategoryPostModel model)
		{
			FoodCategory foodCategory = new FoodCategory
            {
                Name = model.Name,
            };

            await this.dbContext.FoodCategories.AddAsync(foodCategory);
            await this.dbContext.SaveChangesAsync();
		}

		public async Task<FoodCategoryPostModel> GetCategoryForEditAsync(int id)
		{
            FoodCategoryPostModel model = await this.dbContext.FoodCategories
                .Where(fc => fc.IsDeleted == false && fc.Id == id)
                .Select(fc => new FoodCategoryPostModel
                {
                    Name = fc.Name
                })
                .FirstAsync();

            return model;
		}

		public async Task<ICollection<FoodCategoryViewModel>> GetAllFoodCategoriesAsync()
		{
			ICollection<FoodCategoryViewModel> foodCategories = await this.dbContext.FoodCategories
                .Where(fc => fc.IsDeleted == false)
                .Select(fc => new FoodCategoryViewModel
                {
                    Id = fc.Id,
                    Name = fc.Name
                })
                .ToArrayAsync();

            return foodCategories;
		}

		public async Task<ICollection<string>> GetFoodCategoryNamesAsync()
        {
            ICollection<string> categoryNames = await this.dbContext.FoodCategories
                .Where(fc => fc.IsDeleted == false)
                .Select(fc => fc.Name)
                .ToArrayAsync();

            return categoryNames;
        }

        public async Task<bool> IsCategoryExistingByIdAsync(int id)
            => await this.dbContext.FoodCategories.AnyAsync(fc => fc.IsDeleted == false && fc.Id == id);

		public async Task<bool> IsCategoryExistingByNameAsync(string name)
		    => await this.dbContext.FoodCategories.AnyAsync(fc => fc.IsDeleted == false && fc.Name.ToLower() == name.ToLower());

		public async Task EditCategoryAsync(FoodCategoryPostModel model, int id)
		{
			FoodCategory foodCategory = await this.dbContext.FoodCategories
                .Where(fc => fc.IsDeleted == false && fc.Id == id)
                .FirstAsync();

            foodCategory.Name = model.Name;
            await this.dbContext.SaveChangesAsync();
		}

		public async Task<FoodCategoryDeleteViewModel> GetCategoryForDeleteAsync(int id)
		{
			FoodCategoryDeleteViewModel model = await this.dbContext.FoodCategories
                .Where(fc => fc.IsDeleted == false && fc.Id == id)
                .Select(fc => new FoodCategoryDeleteViewModel
                {
                    Id = id,
                    Name = fc.Name
                })
                .FirstAsync();

            return model;
		}

		public async Task DeleteCategoryAsync(int id)
		{
			FoodCategory foodCategory = await this.dbContext.FoodCategories
                .FirstAsync(fc => fc.IsDeleted == false && fc.Id == id);

            foodCategory.IsDeleted = true;

            await this.dbContext.SaveChangesAsync();
		}
	}
}
