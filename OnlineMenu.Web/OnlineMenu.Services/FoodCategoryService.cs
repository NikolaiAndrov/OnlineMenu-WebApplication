namespace OnlineMenu.Services
{
    using Microsoft.EntityFrameworkCore;
    using OnlineMenu.Data;
    using OnlineMenu.Services.Interfaces;
	using OnlineMenu.Web.ViewModels.FoodCategory;

	public class FoodCategoryService : IFoodCategoryService
    {
        private readonly OnlineMenuDbContext dbContext;

        public FoodCategoryService(OnlineMenuDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

		public async Task<ICollection<FoodCategoryPostModel>> GetFoodCategoriesPostAsync()
		{
			ICollection<FoodCategoryPostModel> foodCategories = await this.dbContext.FoodCategories
                .Where(fc => fc.IsDeleted == false)
                .Select(fc => new FoodCategoryPostModel
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
            => await this.dbContext.FoodCategories.AnyAsync(fc => fc.Id == id);
    }
}
