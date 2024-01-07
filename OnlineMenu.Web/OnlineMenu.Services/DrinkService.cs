namespace OnlineMenu.Services
{
	using Microsoft.EntityFrameworkCore;
	using OnlineMenu.Data;
	using OnlineMenu.Data.Models;
	using OnlineMenu.Services.Interfaces;
	using OnlineMenu.Web.ViewModels.Drink;

	public class DrinkService : IDrinkService
	{
		private readonly OnlineMenuDbContext dbContext;

        public DrinkService(OnlineMenuDbContext dbContext)
        {
            this.dbContext = dbContext;
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
	}
}
