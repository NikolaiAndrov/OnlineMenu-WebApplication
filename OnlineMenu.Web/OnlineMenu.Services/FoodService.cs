namespace OnlineMenu.Services
{
    using Microsoft.EntityFrameworkCore;
    using OnlineMenu.Data;
    using OnlineMenu.Data.Models;
    using OnlineMenu.Services.Interfaces;
    using OnlineMenu.Web.ViewModels.Food;
    using OnlineMenu.Web.ViewModels.Home;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class FoodService : IFoodService
    {
        private readonly OnlineMenuDbContext dbContext;

        public FoodService(OnlineMenuDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<FoodQueryModel> GetAllFoodByQueryModelAsync(FoodQueryModel foodQueryModel)
        {
            IQueryable<Food> foodQuery = this.dbContext.Food.AsQueryable();

            foodQuery = foodQuery
                .Where(f => f.IsDeleted == false);

            if (!string.IsNullOrWhiteSpace(foodQueryModel.Category))
            {
                foodQuery = foodQuery.Where(f => f.Category.Name == foodQueryModel.Category);
            }

            if (!string.IsNullOrWhiteSpace(foodQueryModel.Keyword))
            {
                string wildCard = $"%{foodQueryModel.Keyword.ToLower()}%";

                foodQuery = foodQuery
                    .Where(f => EF.Functions.Like(f.Name, wildCard) ||
                    EF.Functions.Like(f.Category.Name, wildCard) ||
                    EF.Functions.Like(f.Description, wildCard));
            }

            foodQuery = foodQuery
                .OrderBy(f => f.FoodCategoryId)
                .ThenBy(f => f.Name)
                .ThenBy(f => f.Price);

            foodQueryModel.FoodAll = await foodQuery
                .Skip((foodQueryModel.CurrentPage - 1) * foodQueryModel.ItemsPerPage)
                .Take(foodQueryModel.ItemsPerPage)
                .Select(f => new FoodAllViewModel
                {
                    Id = f.Id.ToString(),
                    Name = f.Name,
                    Weight = f.Weight,
                    Price = f.Price,
                    ImageUrl = f.ImageUrl,
                })
                .ToArrayAsync();

            foodQueryModel.TotalItems = foodQuery.Count();

            return foodQueryModel;
        }

        public async Task<ICollection<IndexViewModel>> GetFoodForIndexAsync()
        {
            ICollection<IndexViewModel> indexFood = await this.dbContext.Food
                .Where(f => f.Category.Name == "Desserts" || f.Category.Name == "Burgers")
                .Select(f => new IndexViewModel
                {
                    Id = f.Id.ToString(),
                    Name = f.Name,
                    ImageUrl = f.ImageUrl
                })
                .ToArrayAsync();

            return indexFood;
        }
    }
}
