namespace OnlineMenu.Services
{
	using Microsoft.EntityFrameworkCore;
	using OnlineMenu.Data;
	using OnlineMenu.Data.Models;
	using OnlineMenu.Services.Interfaces;
	using OnlineMenu.Web.ViewModels.Drink;
	using System.Collections.Generic;

	public class DrinkService : IDrinkService
	{
		private readonly OnlineMenuDbContext dbContext;

        public DrinkService(OnlineMenuDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

		public async Task AddDrinkAsync(DrinkPostModel model)
		{
			Drink newDrink = new Drink
			{
				Name = model.Name,
				Milliliters = model.Milliliters,
				Price = model.Price,
				Description = model.Description,
				IsAlcoholic = model.IsAlcoholic,
				ImageUrl = model.ImageUrl,
				DrinkCategoryId = model.CategoryId,
			};

			await this.dbContext.Drinks.AddAsync(newDrink);
			await this.dbContext.SaveChangesAsync();
		}

		public async Task AddToFavouriteAsync(string drinkId, string userId)
		{
			UserDrink userDrink = new UserDrink
			{
				UserId = Guid.Parse(userId),
				DrinkId = Guid.Parse(drinkId)
			};

			await this.dbContext.UsersDrinks.AddAsync(userDrink);
			await this.dbContext.SaveChangesAsync();
		}

		public async Task DeleteAsync(string drinkId)
		{
			Drink drink = await this.dbContext.Drinks
				.Where(d => d.Id.ToString() == drinkId)
				.FirstAsync();

			drink.IsDeleted = true;
			await this.dbContext.SaveChangesAsync();
		}

		public async Task<DrinkQueryModel> GetAllDrinksByQueryModelAsync(DrinkQueryModel drinkQueryModel)
		{
			IQueryable<Drink> drinkQuery = this.dbContext.Drinks.AsQueryable();

			drinkQuery = drinkQuery
				.Where(d => d.IsDeleted == false);

			if (!string.IsNullOrWhiteSpace(drinkQueryModel.Category))
			{
				drinkQuery = drinkQuery.Where(d => d.DrinkCategory.Name == drinkQueryModel.Category);
			}

			if (!string.IsNullOrWhiteSpace(drinkQueryModel.Keyword))
			{
				string wildCard = $"%{drinkQueryModel.Keyword.ToLower()}%";

				drinkQuery = drinkQuery
					.Where(d => EF.Functions.Like(d.Name, wildCard) ||
					EF.Functions.Like(d.DrinkCategory.Name, wildCard) ||
					EF.Functions.Like(d.Description, wildCard));
			}

			drinkQuery = drinkQuery
				.OrderBy(d => d.DrinkCategoryId)
				.ThenBy(d => d.IsAlcoholic == false)
				.ThenBy(d => d.Name)
				.ThenBy(d => d.Price);

			drinkQueryModel.DrinksAll = await drinkQuery
				.Skip((drinkQueryModel.CurrentPage - 1) * drinkQueryModel.ItemsPerPage)
				.Take(drinkQueryModel.ItemsPerPage)
				.Select(d => new DrinkAllViewModel
				{
					Id = d.Id.ToString(),
					Name = d.Name,
					Category = d.IsAlcoholic ? d.DrinkCategory.Name : string.Empty,
					IsAlcoholic = d.IsAlcoholic,
					Milliliters = d.Milliliters,
					Price = d.Price,
					ImageUrl = d.ImageUrl,
				})
				.ToArrayAsync();

			drinkQueryModel.TotalItems = drinkQuery.Count();

			return drinkQueryModel;
		}

		public async Task<DrinkDetailsViewModel> GetDrinkDetailsAsync(string drinkId)
		{
			DrinkDetailsViewModel drinkDetails = await this.dbContext.Drinks
				.Where(d => d.IsDeleted == false && d.Id.ToString() == drinkId)
				.Select(d => new DrinkDetailsViewModel
				{
					Id = d.Id.ToString(),
					Name = d.Name,
					Category = d.IsAlcoholic ? d.DrinkCategory.Name : string.Empty,
					IsAlcoholic = d.IsAlcoholic,
					Milliliters = d.Milliliters,
					Price = d.Price,
					ImageUrl = d.ImageUrl,
					Description = d.Description
				})
				.FirstAsync();

			return drinkDetails;
		}

		public async Task<DrinkPostModel> GetDrinkForEditAsync(string drinkId)
		{
			DrinkPostModel model = await this.dbContext.Drinks
				.Where(d => d.IsDeleted == false && d.Id.ToString() == drinkId)
				.Select (d => new DrinkPostModel
				{
					Name = d.Name,
					Milliliters = d.Milliliters,
					Price = d.Price,
					Description = d.Description,
					IsAlcoholic = d.IsAlcoholic,
					ImageUrl= d.ImageUrl,
					CategoryId = d.DrinkCategoryId
				})
				.FirstAsync();

			return model;
		}

		public async Task<ICollection<DrinkAllViewModel>> GetFavouriteDrinksAsync(string userId)
		{
			ICollection<DrinkAllViewModel> favouriteDrinks = await this.dbContext.UsersDrinks
				.Where(ud => ud.UserId.ToString() == userId)
				.OrderBy(ud => ud.Drink.DrinkCategoryId)
				.ThenBy(ud => ud.Drink.IsAlcoholic == false)
				.ThenBy(ud => ud.Drink.Name)
				.ThenBy(ud => ud.Drink.Price)
				.Select(ud => new DrinkAllViewModel
				{
					Id = ud.DrinkId.ToString(),
					Name = ud.Drink.Name,
					Category = ud.Drink.DrinkCategory.Name,
					IsAlcoholic = ud.Drink.IsAlcoholic,
					Milliliters = ud.Drink.Milliliters,
					Price = ud.Drink.Price,
					ImageUrl = ud.Drink.ImageUrl,
				})
				.ToArrayAsync();

			return favouriteDrinks;
		}

		public async Task<bool> IsDrinkExistingByIdAsync(string drinkId)
			=> await this.dbContext.Drinks.AnyAsync(d => d.Id.ToString() == drinkId);

		public async Task RemoveFromFavouriteAsync(string drinkId, string userId)
		{
			UserDrink userDrink = await this.dbContext.UsersDrinks
				.Where(ud => ud.DrinkId.ToString() == drinkId && ud.UserId.ToString() == userId)
				.FirstAsync();

			this.dbContext.UsersDrinks.Remove(userDrink);
			await this.dbContext.SaveChangesAsync();
		}
	}
}
