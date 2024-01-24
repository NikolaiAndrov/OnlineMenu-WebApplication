namespace OnlineMenu.Services.Tests
{
	using Microsoft.EntityFrameworkCore;
	using OnlineMenu.Data;
	using OnlineMenu.Services.Interfaces;
	using OnlineMenu.Web.ViewModels.Drink;
	using static InMemoryDatabaseSeeder;
	using static Common.GeneralApplicationMessages;
	using OnlineMenu.Data.Models;
	using OnlineMenu.Web.ViewModels.Food;

	[TestFixture]
	public class DrinkServiceTests
	{
		private DbContextOptions<OnlineMenuDbContext> dbOptions;
		private OnlineMenuDbContext dbContext;
		private IDrinkService drinkService;

		public DrinkServiceTests()
		{

		}

		[SetUp]
		public async Task SetUp()
		{
			this.dbOptions = new DbContextOptionsBuilder<OnlineMenuDbContext>()
				.UseInMemoryDatabase("OnlineMenuInMemory" + Guid.NewGuid().ToString())
				.Options;

			this.dbContext = new OnlineMenuDbContext(this.dbOptions);
			await this.dbContext.Database.EnsureCreatedAsync();
			Seed(dbContext);

			this.drinkService = new DrinkService(this.dbContext);
		}

		[Test]
		public async Task IsDrinkExistingByIdAsync_ShouldReturnFalseWhenInvalidIdPassed()
		{
			string drinkId = "someinvalidid123123-abababa";
			bool isDrinkExisting = await this.drinkService.IsDrinkExistingByIdAsync(drinkId);

			Assert.IsFalse(isDrinkExisting);
		}

		[Test]
		public async Task IsDrinkExistingByIdAsync_ShouldReturnFalseWhenNullPassed()
		{
			bool isDrinkExisting = await this.drinkService.IsDrinkExistingByIdAsync(null!);
			Assert.IsFalse(isDrinkExisting);
		}

		[Test]
		public async Task IsDrinkExistingByIdAsync_ShouldReturnTrueWhenCorrectIdPassed()
		{
			string? drinkId = await this.dbContext.Drinks
				.Where(d => d.IsDeleted == false)
				.Select(d => d.Id.ToString())
				.FirstOrDefaultAsync();

			Assert.IsNotNull(drinkId, ItemNotFoundTestMessage);

			bool isDrinkExisting = await this.drinkService.IsDrinkExistingByIdAsync(drinkId);
			Assert.IsTrue(isDrinkExisting);
		}

		[Test]
		public async Task AddDrinkAndReturnIdAsync_ShouldAddNewDrinkAndReturnTheDrinkId()
		{
			int drinkCategoryId = await this.dbContext.DrinksCategories
				.Select(d => d.Id)
				.FirstOrDefaultAsync();

			DrinkPostModel drinkPostModel = new DrinkPostModel
			{
				Name = "Test",
				Milliliters = 50,
				Price = 50m,
				Description = "Test Test",
				IsAlcoholic = true,
				ImageUrl = "NewDrinkImgUrl",
				CategoryId = drinkCategoryId
			};

			string returnedDrinkId = await this.drinkService.AddDrinkAndReturnIdAsync(drinkPostModel);

			bool isDrinkExisting = await this.dbContext.Drinks
				.AnyAsync(d => d.IsDeleted == false && d.Id.ToString() == returnedDrinkId);

			Assert.IsTrue(isDrinkExisting);
		}

		[Test]
		public void AddDrinkAndReturnIdAsync_ShouldThrowWhenNullPassed()
		{
			Assert.ThrowsAsync<NullReferenceException>(async () =>
			{
				await this.drinkService.AddDrinkAndReturnIdAsync(null!);
			});
		}

		[Test]
		public async Task AddToFavouriteAsync_ShouldAddDrinkToFavouritesOfUser()
		{
			string? userId = await this.dbContext.Users
				.Select(u => u.Id.ToString())
				.FirstOrDefaultAsync();
			Assert.IsNotNull(userId, UserNotFoundTestMessage);

			string? drinkId = await this.dbContext.Drinks
				.Where(d => d.IsDeleted == false)
				.Select(d => d.Id.ToString())
				.FirstOrDefaultAsync();
			Assert.IsNotNull(drinkId, ItemNotFoundTestMessage);

			await this.drinkService.AddToFavouriteAsync(drinkId, userId);

			bool isInFvourite = await this.dbContext.UsersDrinks
				.AnyAsync(ud => ud.Drink.Id.ToString() == drinkId && ud.User.Id.ToString() == userId);

			Assert.IsTrue(isInFvourite);
		}

		[Test]
		public async Task IsDrinkInFavourite_ShouldReturnTrueWhenInFavourite()
		{
			string? userId = await this.dbContext.Users
			   .Select(u => u.Id.ToString())
			   .FirstOrDefaultAsync();
			Assert.IsNotNull(userId, UserNotFoundTestMessage);

			string? drinkId = await this.dbContext.Drinks
				.Where(d => d.IsDeleted == false)
				.Select(d => d.Id.ToString())
				.FirstOrDefaultAsync();
			Assert.IsNotNull(drinkId, ItemNotFoundTestMessage);

			await this.drinkService.AddToFavouriteAsync(drinkId, userId);
			bool isInFvourite = await this.drinkService.IsDrinkInFavouriteAsync(userId, drinkId);

			Assert.IsTrue(isInFvourite);
		}

		[Test]
		public async Task IsDrinkInFavourite_ShouldReturnFalseWhenNotInFavourite()
		{
			string? userId = await this.dbContext.Users
			   .Select(u => u.Id.ToString())
			   .FirstOrDefaultAsync();
			Assert.IsNotNull(userId, UserNotFoundTestMessage);

			string? drinkId = await this.dbContext.Drinks
				.Where(d => d.IsDeleted == false)
				.Select(d => d.Id.ToString())
				.FirstOrDefaultAsync();
			Assert.IsNotNull(drinkId, ItemNotFoundTestMessage);

			bool isInFvourite = await this.drinkService.IsDrinkInFavouriteAsync(userId, drinkId);
			Assert.IsFalse(isInFvourite);
		}

		[Test]
		public async Task IsDrinkInFavourite_ShouldReturnFalseWhenNullPassed()
		{
			bool isInFvourite = await this.drinkService.IsDrinkInFavouriteAsync(null!, null!);
			Assert.IsFalse(isInFvourite);
		}

		[Test]
		public async Task RemoveFromFavouriteAsync_ShouldRemoveDrinkFromFavourite()
		{
			string? userId = await this.dbContext.Users
				.Select(u => u.Id.ToString())
				.FirstOrDefaultAsync();
			Assert.IsNotNull(userId, UserNotFoundTestMessage);

			string? drinkId = await this.dbContext.Drinks
				.Where(d => d.IsDeleted == false)
				.Select(d => d.Id.ToString())
				.FirstOrDefaultAsync();
			Assert.IsNotNull(drinkId, ItemNotFoundTestMessage);

			await this.drinkService.AddToFavouriteAsync(drinkId, userId);
			await this.drinkService.RemoveFromFavouriteAsync(drinkId, userId);
			bool isDrinkInFavourite = await this.drinkService.IsDrinkInFavouriteAsync(userId, drinkId);

			Assert.IsFalse(isDrinkInFavourite);
		}

		[Test]
		public async Task DeleteDrinksByCategoryIdAsync_ShouldSoftDeleteAllDrinksByGivenDrinkCategoryId()
		{
			int drinkCategoryId = await this.dbContext.DrinksCategories
				.Where(dc => dc.IsDeleted == false)
				.Select(dc => dc.Id)
				.FirstOrDefaultAsync();

			await this.drinkService.DeleteDrinksByCategoryIdAsync(drinkCategoryId);

			bool isAnyDrink = await this.dbContext.Drinks
				.AnyAsync(d => d.IsDeleted == false && d.DrinkCategoryId == drinkCategoryId);

			Assert.IsFalse(isAnyDrink);
		}

		[Test]
		public async Task DeleteDrinkAsync_ShouldDeleteDrinkByGivenId()
		{
			string? drinkId = await this.dbContext.Drinks
				.Where(d => d.IsDeleted == false)
				.Select(d => d.Id.ToString())
				.FirstOrDefaultAsync();

			Assert.IsNotNull(drinkId, ItemNotFoundTestMessage);

			await this.drinkService.DeleteDrinkAsync(drinkId);

			bool isAnyDrink = await this.dbContext.Drinks
				.AnyAsync(d => d.IsDeleted == false && d.Id.ToString() == drinkId);

			Assert.IsFalse(isAnyDrink);
		}

		[Test]
		public async Task GetDrinkForEditAsync_ShouldReturnExactDrinkByGivenId()
		{
			Drink? drink = await this.dbContext.Drinks
				.Where(d => d.IsDeleted == false)
				.FirstOrDefaultAsync();

			Assert.IsNotNull(drink, ItemNotFoundTestMessage);

			DrinkPostModel model = await this.drinkService.GetDrinkForEditAsync(drink.Id.ToString());

			Assert.That(model.Name, Is.EqualTo(drink.Name));
			Assert.That(model.Milliliters, Is.EqualTo(drink.Milliliters));
			Assert.That(model.Price, Is.EqualTo(drink.Price));
			Assert.That(model.IsAlcoholic, Is.EqualTo(drink.IsAlcoholic));
			Assert.That(model.ImageUrl, Is.EqualTo(drink.ImageUrl));
			Assert.That(model.CategoryId, Is.EqualTo(drink.DrinkCategoryId));
		}

		[Test]
		public async Task EditDrinkAsync_ShouldEditDrinkCorrectly()
		{
			int drinkCategoryId = await this.dbContext.DrinksCategories
				.Select(d => d.Id)
				.LastOrDefaultAsync();

			string? drinkId = await this.dbContext.Drinks
				.Where(d => d.IsDeleted == false)
				.Select(d => d.Id.ToString())
				.FirstOrDefaultAsync();

			Assert.IsNotNull(drinkId, ItemNotFoundTestMessage);

			DrinkPostModel drinkPostModel = new DrinkPostModel
			{
				Name = "Test",
				Milliliters = 50,
				Price = 50m,
				Description = "Test Test",
				IsAlcoholic = true,
				ImageUrl = "NewDrinkImgUrl",
				CategoryId = drinkCategoryId
			};

			await this.drinkService.EditDrinkAsync(drinkId, drinkPostModel);

			Drink? drink = await this.dbContext.Drinks
				.FirstOrDefaultAsync(d => d.IsDeleted == false && d.Id.ToString() == drinkId);
			Assert.IsNotNull(drink, ItemNotFoundTestMessage);

			Assert.That(drink.Name, Is.EqualTo(drinkPostModel.Name));
			Assert.That(drink.Milliliters, Is.EqualTo(drinkPostModel.Milliliters));
			Assert.That(drink.Price, Is.EqualTo(drinkPostModel.Price));
			Assert.That(drink.Description, Is.EqualTo(drinkPostModel.Description));
			Assert.That(drink.IsAlcoholic, Is.EqualTo(drinkPostModel.IsAlcoholic));
			Assert.That(drink.ImageUrl, Is.EqualTo(drinkPostModel.ImageUrl));
			Assert.That(drink.DrinkCategoryId, Is.EqualTo(drinkPostModel.CategoryId));

		}

		[Test]
		public async Task GetAllDrinksByQueryModelAsync_ShouldReturnDrinkItemsWithGivenCategory()
		{
			string? drinkCategory = await this.dbContext.DrinksCategories
				.Where(dc => dc.IsDeleted == false)
				.Select(dc => dc.Name)
				.FirstOrDefaultAsync();

			Assert.IsNotNull(drinkCategory, ItemNotFoundTestMessage);

			ICollection<Drink> drinks = await this.dbContext.Drinks
				.Where(d => d.IsDeleted == false && d.DrinkCategory.Name == drinkCategory)
				.ToArrayAsync();


			DrinkQueryModel drinkQueryModel = new DrinkQueryModel
			{
				Category = drinkCategory
			};

			DrinkQueryModel returnedModel = await this.drinkService.GetAllDrinksByQueryModelAsync(drinkQueryModel);

			bool isCategoryMissing = false;

			foreach (var currentDrink in returnedModel.DrinksAll)
			{
				if (!drinks.Any(f => f.Id.ToString() == currentDrink.Id))
				{
					isCategoryMissing = true;
					break;
				}
			}

			int expectedCount = drinks.Count;
			int actualCount = returnedModel.DrinksAll.Count();

			Assert.That(actualCount, Is.EqualTo(expectedCount));
			Assert.IsFalse(isCategoryMissing);
		}

		[Test]
		public async Task GetAllDrinksByQueryModelAsync_ShouldReturnExactItemByKeyword()
		{
			string? keywordDrinkName = await this.dbContext.Drinks
			   .Where(d => d.IsDeleted == false)
			   .Select(d => d.Name)
			   .FirstOrDefaultAsync();

			Assert.IsNotNull(keywordDrinkName, ItemNotFoundTestMessage);

			DrinkQueryModel drinkQueryModel = new DrinkQueryModel
			{
				Keyword = keywordDrinkName
			};

			DrinkQueryModel returnedModel = await this.drinkService.GetAllDrinksByQueryModelAsync(drinkQueryModel);

			DrinkAllViewModel? drinkSearched = returnedModel.DrinksAll.FirstOrDefault(d => d.Name == keywordDrinkName);
			Assert.IsNotNull(drinkSearched, ItemNotFoundTestMessage);

			string expectedDrinkName = keywordDrinkName;
			string actualDrinkName = drinkSearched.Name;

			Assert.That(actualDrinkName, Is.EqualTo(expectedDrinkName));
		}

		[Test]
		public async Task GetDrinkDetailsAsync_ShouldReturnCorrectDrinkWithDescription()
		{
			Drink? drink = await this.dbContext.Drinks
				.FirstOrDefaultAsync(d => d.IsDeleted == false);
			Assert.IsNotNull(drink, ItemNotFoundTestMessage);

			DrinkDetailsViewModel drinkDetails = await this.drinkService.GetDrinkDetailsAsync(drink.Id.ToString());

			Assert.That(drink.Id.ToString(), Is.EqualTo(drinkDetails.Id));
			Assert.That(drink.Description, Is.EqualTo(drinkDetails.Description));
		}

		[Test]
		public async Task GetDrinkForDeleteAsync_ShouldReturnTheRequestedDrink()
		{
			Drink? drink = await this.dbContext.Drinks
				.FirstOrDefaultAsync(d => d.IsDeleted == false);
			Assert.IsNotNull(drink, ItemNotFoundTestMessage);

			DrinkDeleteViewModel drinkDelete = await this.drinkService.GetDrinkForDeleteAsync(drink.Id.ToString());

			Assert.That(drink.Name, Is.EqualTo(drinkDelete.Name));
			Assert.That(drink.Description, Is.EqualTo(drinkDelete.Description));
			Assert.That(drink.ImageUrl, Is.EqualTo(drinkDelete.ImageUrl));
		}

		[Test]
		public async Task GetDrinksCountAsync_ShouldReturnAllAvailableDrinksCount()
		{
			int expectedCount = await this.dbContext.Drinks
				.Where(d => d.IsDeleted == false)
				.CountAsync();

			int actualCount = await this.drinkService.GetDrinksCountAsync();

			Assert.That(expectedCount, Is.EqualTo(actualCount));
		}

		[Test]
		public async Task GetFavouriteDrinksAsync_ShouldReturnAllFavouriteDrinks()
		{
			ApplicationUser? user = await this.dbContext.Users
				.FirstOrDefaultAsync();
			Assert.IsNotNull(user, UserNotFoundTestMessage);

			Drink? drink = await this.dbContext.Drinks
				.FirstOrDefaultAsync(d => d.IsDeleted == false);
			Assert.IsNotNull(drink, ItemNotFoundTestMessage);

			await this.drinkService.AddToFavouriteAsync(drink.Id.ToString(), user.Id.ToString());

			ICollection<DrinkAllViewModel> favouriteDrinks = await this.drinkService.GetFavouriteDrinksAsync(user.Id.ToString());

			string expectedDrinkName = drink.Name;
			string actualDrinkName = favouriteDrinks.First().Name;

			Assert.That(expectedDrinkName, Is.EqualTo(actualDrinkName));
		}

		[Test]
		public async Task GetFavouriteDrinksAsync_ShouldReturnEmptyCollectionWhenInvalidUserIdPassed()
		{
			string invalidUserId = "someinvalididididid123";
			ICollection<DrinkAllViewModel> favouriteDrinks = await this.drinkService.GetFavouriteDrinksAsync(invalidUserId);

			int expectedCount = 0;
			int actualCount = favouriteDrinks.Count;

			Assert.That(actualCount, Is.EqualTo(expectedCount));
		}

		[Test]
		public async Task GetDrinkNamesByCategoryIdAsync_ShouldReturnEmptyStringWhenWrongCategoryIdPassed()
		{
			int categoryId = int.MinValue;
			string categories = await this.drinkService.GetDrinkNamesByCategoryIdAsync(categoryId);

			Assert.IsEmpty(categories);
		}

		[Test]
		public async Task GetDrinkNamesByCategoryIdAsync_ShouldReturnAllCategoryNamesByGivenGategoryId()
		{
			int drinkCategoryId = await this.dbContext.DrinksCategories
				.Where(dc => dc.IsDeleted == false)
				.Select(dc => dc.Id)
				.FirstOrDefaultAsync();

			ICollection<string> drinkNames = await this.dbContext.Drinks
				.Where(d => d.IsDeleted == false && d.DrinkCategoryId == drinkCategoryId)
				.Select(d => d.Name)
				.ToArrayAsync();

			string expectedNames = string.Join(", ", drinkNames);
			string actualNames = await this.drinkService.GetDrinkNamesByCategoryIdAsync(drinkCategoryId);

			Assert.That(expectedNames, Is.EqualTo(actualNames));
		}

		[TearDown]
		public async Task TearDown()
		{
			await this.dbContext.Database.EnsureCreatedAsync();
			await this.dbContext.DisposeAsync();
		}
	}
}
