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

        [Test]
        public async Task IsFoodInFavouriteAsync_ShouldReturnFalseWhenNotInFavourite()
        {
			Food? food = await this.dbContext.Food
				.FirstOrDefaultAsync(f => f.Name == "Beef Burger");

			Assert.IsNotNull(food, ItemNotFoundTestMessage);

            bool isInFavourite = await this.foodService.IsFoodInFavouriteAsync(User.Id.ToString(), food!.Id.ToString());

            Assert.IsFalse(isInFavourite);
		}

		[Test]
		public async Task IsFoodInFavouriteAsync_ShouldReturnTrueWhenInFavourite()
        {
			Food? food = await this.dbContext.Food
				.FirstOrDefaultAsync(f => f.Name == "Beef Burger");

			Assert.IsNotNull(food, ItemNotFoundTestMessage);

            await this.foodService.AddToFavouriteAsync(food.Id.ToString(), User.Id.ToString());

			bool isInFavourite = await this.foodService.IsFoodInFavouriteAsync(User.Id.ToString(), food!.Id.ToString());

            Assert.IsTrue(isInFavourite);
		}

        [Test]
        public async Task DeleteFoodAsync_ShouldSetIsDeletedPropertyOfFoodToTrue()
        {
            Food? food = await this.dbContext.Food.FirstOrDefaultAsync(f => f.IsDeleted == false && f.Name == "Beef Burger");
            Assert.IsNotNull(food, ItemNotFoundTestMessage);

            await this.foodService.DeleteFoodAsync(food.Id.ToString());

            bool isDeleted = await this.dbContext.Food.AnyAsync(f => f.IsDeleted == true && f.Name == "Beef Burger");
            Assert.IsTrue(isDeleted);
        }

        [Test]
        public async Task DeleteFoodByCategoryIdAsync_ShouldDeleteAllFoodItemsWithGivenCategoryId()
        {
            int saladsCategoryId = 1;
            await this.foodService.DeleteFoodByCategoryIdAsync(saladsCategoryId);

            bool isAnyFoodWithCategory = await this.dbContext.Food.AnyAsync(f => f.IsDeleted == false && f.FoodCategoryId == saladsCategoryId);
            Assert.IsFalse(isAnyFoodWithCategory);
        }

        [Test]
        public async Task DeleteFoodByCategoryIdAsync_ShouldNotDeleteAnyFoodWhenWrongCategoryIdPassed()
        {
            int notExistingfoodCategoryId = int.MaxValue;
            int expectedFoodCount = await this.dbContext.Food.CountAsync();

            await this.foodService.DeleteFoodByCategoryIdAsync(notExistingfoodCategoryId);

            int actualFoodCount = await this.dbContext.Food.CountAsync();

            Assert.AreEqual(expectedFoodCount, actualFoodCount);
        }

        [Test]
        public async Task GetFoodForEditAsync_AshouldReturnTheCorrectItem()
        {
            Food? food = await this.dbContext.Food.FirstOrDefaultAsync(f => f.IsDeleted == false && f.Name == "Beef Burger");
            Assert.IsNotNull(food, ItemNotFoundTestMessage);

            FoodPostModel foodPostModel = await this.foodService.GetFoodForEditAsync(food.Id.ToString());
            Assert.IsNotNull(foodPostModel, ItemNotFoundTestMessage);

            Assert.That(foodPostModel.Name, Is.EqualTo(food.Name));
            Assert.That(foodPostModel.Weight, Is.EqualTo(food.Weight));
            Assert.That(foodPostModel.Price, Is.EqualTo(food.Price));
            Assert.That(foodPostModel.Description, Is.EqualTo(food.Description));
            Assert.That(foodPostModel.ImageUrl, Is.EqualTo(food.ImageUrl));
            Assert.That(foodPostModel.CategoryId, Is.EqualTo(food.FoodCategoryId));
		}

        [Test]
        public async Task EditFoodAsync_ShouldEditFoodCorrectly()
        {
			Food? food = await this.dbContext.Food.FirstOrDefaultAsync(f => f.IsDeleted == false && f.Name == "Beef Burger");
			Assert.IsNotNull(food, ItemNotFoundTestMessage);

			FoodPostModel expectedFood = new FoodPostModel
            {
                Name = "Beef Burger Burger beef burger",
                Weight = 1000,
                Price = 1000m,
                Description = "Description description some description",
                ImageUrl = "newImageUrlOfBeefBurgerburgerburger",
                CategoryId = 1,
			};

            await this.foodService.EditFoodAsync(food.Id.ToString(), expectedFood);

            Food? actualFood = await this.dbContext.Food.FirstOrDefaultAsync(f => f.IsDeleted == false && f.Id == food.Id);
			Assert.IsNotNull(food, ItemNotFoundTestMessage);

			Assert.That(expectedFood.Name, Is.EqualTo(actualFood!.Name));
			Assert.That(expectedFood.Weight, Is.EqualTo(actualFood!.Weight));
			Assert.That(expectedFood.Price, Is.EqualTo(actualFood!.Price));
			Assert.That(expectedFood.Description, Is.EqualTo(actualFood!.Description));
			Assert.That(expectedFood.ImageUrl, Is.EqualTo(actualFood!.ImageUrl));
			Assert.That(expectedFood.CategoryId, Is.EqualTo(actualFood!.FoodCategoryId));
		}

        [Test]
        public async Task EditFoodAsync_ShouldThrowExceptionWhenInvallidIdPassed()
        {
            string invalidId = "InvalidFoodId-12345-Abu";

			FoodPostModel food = new FoodPostModel
			{
				Name = "Beef Burger Burger beef burger",
				Weight = 1000,
				Price = 1000m,
				Description = "Description description some description",
				ImageUrl = "newImageUrlOfBeefBurgerburgerburger",
				CategoryId = 1,
			};

            Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await this.foodService.EditFoodAsync(invalidId, food);
            });
		}

		[TearDown]
        public void TearDown()
        {
            this.dbContext.Database.EnsureDeleted();
            this.dbContext.Dispose();
        }
    }
}
