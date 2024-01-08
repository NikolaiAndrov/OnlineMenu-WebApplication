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

        public async Task AddFoodAsync(FoodPostModel model)
        {
            Food newFood = new Food
            {
                Name = model.Name,
                Weight = model.Weight,
                Price = model.Price,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                FoodCategoryId = model.CategoryId,
            };

            await this.dbContext.Food.AddAsync(newFood);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task AddToFavouriteAsync(string foodId, string userId)
		{
			UserFood userFood = new UserFood
            {
                FoodId = Guid.Parse(foodId),
                UserId = Guid.Parse(userId)
            };

            await this.dbContext.UsersFood.AddAsync(userFood);
            await this.dbContext.SaveChangesAsync();
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

		public async Task<ICollection<FoodAllViewModel>> GetFavouriteFoodAsync(string userId)
		{
			ICollection<FoodAllViewModel> favouriteFood = await this.dbContext.UsersFood
                .Where(u => u.UserId.ToString() == userId)
                .OrderBy(uf => uf.Food.Category.Id)
                .ThenBy(uf => uf.Food.Name)
                .ThenBy(uf => uf.Food.Price)
                .Select(uf => new FoodAllViewModel
                {
                    Id = uf.Food.Id.ToString(),
                    Name = uf.Food.Name,
                    Weight= uf.Food.Weight,
                    Price = uf.Food.Price,
                    ImageUrl = uf.Food.ImageUrl
                })
                .ToListAsync();
                
            return favouriteFood;
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

        public async Task<bool> IsFoodExistingByIdAsync(string foodId)
            => await this.dbContext.Food.AnyAsync(f => f.Id.ToString() == foodId);

		public async Task RemoveFromFavouriteAsync(string foodId, string userId)
		{
			UserFood userFood = await this.dbContext.UsersFood
                .Where(uf => uf.UserId.ToString() == userId && uf.FoodId.ToString() == foodId)
                .FirstAsync();

            this.dbContext.UsersFood.Remove(userFood);
            await this.dbContext.SaveChangesAsync();
		}
	}
}
