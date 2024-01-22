namespace OnlineMenu.Services.Tests
{
    using Microsoft.EntityFrameworkCore;
	using OnlineMenu.Data;
	using OnlineMenu.Data.Models;
	using OnlineMenu.Services.Interfaces;
	using OnlineMenu.Web.ViewModels.Food;
	using static InMemoryDatabaseSeeder;
    using static Common.GeneralApplicationMessages;

	[TestFixture]
	public class FoodServiceTests
	{
        private DbContextOptions<OnlineMenuDbContext> dbOptions;
        private OnlineMenuDbContext dbContext;
        private IFoodService foodService;

        public FoodServiceTests()
        {
            
        }

        [SetUp]
        public void SetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<OnlineMenuDbContext>()
                .UseInMemoryDatabase("OnlineMenuInMemory" + Guid.NewGuid().ToString())
                .Options;

            this.dbContext = new OnlineMenuDbContext(this.dbOptions);
            this.dbContext.Database.EnsureCreated();
            Seed(this.dbContext);

            this.foodService = new FoodService(dbContext);
        }

        [Test]
        public async Task AddFoodAndReturnIdAsync_ShouldWorkProperly()
        {
            FoodPostModel model = new FoodPostModel
            {
                Name = "Test",
                Weight = 100,
                Price = 10m,
                Description = "Test Description",
                ImageUrl = "Test Image Url",
                CategoryId = 1
            };

            string modelId = await this.foodService.AddFoodAndReturnIdAsync(model);
            bool isExisting = await this.dbContext.Food.AnyAsync(f => f.Id.ToString() == modelId);

            Assert.IsTrue(isExisting);
        }

        [Test]
        public async Task IsFoodExistingByIdAsync_ShouldReturnTrueWhenExisting()
        {
            Food? food = await this.dbContext.Food
                .FirstOrDefaultAsync(f => f.Name == "Beef Burger");

            Assert.IsNotNull(food, ItemNotFoundTestMessage);

            bool isFoodExisting = await this.foodService.IsFoodExistingByIdAsync(food!.Id.ToString());
            Assert.IsTrue(isFoodExisting);
        }

        [Test]
        public async Task IsFoodExistingByIdAsync_ShouldReturnFalseWhenNotExisting()
        {
            string id = "NotExistingId";
			bool isFoodExisting = await this.foodService.IsFoodExistingByIdAsync(id);

            Assert.IsFalse(isFoodExisting);
		}

		[Test]
		public async Task IsFoodExistingByIdAsync_ShouldReturnFalseWhenNullPassed()
		{
			bool isFoodExisting = await this.foodService.IsFoodExistingByIdAsync(null!);

			Assert.IsFalse(isFoodExisting);
		}

        [Test]
        public async Task AddToFavouriteAsync_ShouldWorkProperly()
        {
			Food? food = await this.dbContext.Food
				.FirstOrDefaultAsync(f => f.Name == "Beef Burger");

			Assert.IsNotNull(food, ItemNotFoundTestMessage);

			await this.foodService.AddToFavouriteAsync(food!.Id.ToString(), User.Id.ToString());

            bool isInFavourite = await this.dbContext.UsersFood.AnyAsync(uf => uf.FoodId == food!.Id && uf.UserId == User.Id);
            Assert.IsTrue(isInFavourite);   
		}

        [Test]
        public async Task RemoveFromFavouriteAsync_ShouldWorkProperly()
        {
			Food? food = await this.dbContext.Food
				.FirstOrDefaultAsync(f => f.Name == "Beef Burger");

			Assert.IsNotNull(food, ItemNotFoundTestMessage);

			await this.foodService.AddToFavouriteAsync(food!.Id.ToString(), User.Id.ToString());
			await this.foodService.RemoveFromFavouriteAsync(food.Id.ToString(), User.Id.ToString());

			bool isInFavourite = await this.dbContext.UsersFood.AnyAsync(uf => uf.FoodId == food!.Id && uf.UserId == User.Id);
            Assert.False(isInFavourite);
		}

		[TearDown]
        public void TearDown()
        {
            this.dbContext.Database.EnsureDeleted();
            this.dbContext.Dispose();
        }
    }
}
