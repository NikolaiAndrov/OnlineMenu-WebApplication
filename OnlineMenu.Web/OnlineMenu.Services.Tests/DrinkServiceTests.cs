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

		[TearDown] 
        public async Task TearDown()
        {
            await this.dbContext.Database.EnsureCreatedAsync();
            await this.dbContext.DisposeAsync();
        }
    }
}
