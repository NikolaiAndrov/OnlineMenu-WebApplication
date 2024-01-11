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

        public async Task<string> AddFoodAndReturnIdAsync(FoodPostModel model)
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
            return newFood.Id.ToString();
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

		public async Task DeleteFoodAsync(string foodId)
		{
			Food food = await this.dbContext.Food
                .Where(f => f.IsDeleted == false && f.Id.ToString() == foodId)
                .FirstAsync();

            food.IsDeleted = true;
            await this.dbContext.SaveChangesAsync();
		}

		public async Task EditFoodAsync(string foodId, FoodPostModel model)
		{
			Food food = await this.dbContext.Food
                .Where(f => f.IsDeleted == false && f.Id.ToString() == foodId)
                .FirstAsync();

            food.Name = model.Name;
            food.Weight = model.Weight;
            food.Price = model.Price;
            food.Description = model.Description;
            food.ImageUrl = model.ImageUrl;
            food.FoodCategoryId = model.CategoryId;

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

		public async Task<FoodDetailsViewModel> GetFoodDetailsAsync(string foodId)
		{
			FoodDetailsViewModel foodDetails = await this.dbContext.Food
                .Where(f => f.IsDeleted == false && f.Id.ToString() == foodId)
                .Select(f => new FoodDetailsViewModel
                {
					Id = f.Id.ToString(),
					Name = f.Name,
					Weight = f.Weight,
					Price = f.Price,
					ImageUrl = f.ImageUrl,
                    Description = f.Description
				})
                .FirstAsync();

            return foodDetails;

		}

		public async Task<FoodDeleteViewModel> GetFoodForDeleteAsync(string foodId)
		{
			FoodDeleteViewModel model = await this.dbContext.Food
                .Where(f => f.IsDeleted == false && f.Id.ToString() == foodId)
                .Select(f => new FoodDeleteViewModel
                {
                    Name = f.Name,
                    Description = f.Description,
                    ImageUrl = f.ImageUrl,
                })
                .FirstAsync();

            return model;
		}

		public async Task<FoodPostModel> GetFoodForEditAsync(string foodId)
		{
			FoodPostModel foodPostModel = await this.dbContext.Food
                .Where(f => f.IsDeleted == false && f.Id.ToString() == foodId)
                .Select(f => new FoodPostModel
                {
                    Name = f.Name,
                    Weight = f.Weight,
                    Price = f.Price,
                    Description = f.Description,
                    ImageUrl = f.ImageUrl,
                    CategoryId = f.FoodCategoryId
                })
                .FirstAsync();

            return foodPostModel;
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

        public async Task<bool> IsFoodInFavouriteAsync(string userId, string foodId)
            => await this.dbContext.UsersFood.AnyAsync(uf => uf.UserId.ToString() == userId && uf.FoodId.ToString() == foodId);

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
