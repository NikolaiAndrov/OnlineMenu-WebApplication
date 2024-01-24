namespace OnlineMenu.Services.Tests
{
	using Microsoft.EntityFrameworkCore;
	using OnlineMenu.Data;
	using OnlineMenu.Services.Interfaces;
	using OnlineMenu.Web.ViewModels.Drink;
	using static InMemoryDatabaseSeeder;
	using static Common.GeneralApplicationMessages;
	using OnlineMenu.Data.Models;

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

		[TearDown]
		public async Task TearDown()
		{
			await this.dbContext.Database.EnsureCreatedAsync();
			await this.dbContext.DisposeAsync();
		}
	}
}
