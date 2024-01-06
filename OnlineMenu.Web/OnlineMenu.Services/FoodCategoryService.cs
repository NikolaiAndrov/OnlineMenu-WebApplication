namespace OnlineMenu.Services
{
    using Microsoft.EntityFrameworkCore;
    using OnlineMenu.Data;
    using OnlineMenu.Services.Interfaces;

    public class FoodCategoryService : IFoodCategoryService
    {
        private readonly OnlineMenuDbContext dbContext;

        public FoodCategoryService(OnlineMenuDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ICollection<string>> GetFoodCategoryNamesAsync()
        {
            ICollection<string> categoryNames = await this.dbContext.FoodCategories
                .Select(fc => fc.Name)
                .ToArrayAsync();

            return categoryNames;
        }
    }
}
