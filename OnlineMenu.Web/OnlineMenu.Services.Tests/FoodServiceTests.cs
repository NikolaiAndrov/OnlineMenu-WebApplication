namespace OnlineMenu.Services.Tests
{
    using Microsoft.EntityFrameworkCore;
	using OnlineMenu.Data;
	using OnlineMenu.Data.Models;
	using OnlineMenu.Services.Interfaces;
	using OnlineMenu.Web.ViewModels.Food;
	using static InMemoryDatabaseSeeder;
    using static Common.GeneralApplicationMessages;
    using static Common.GeneralApplicationConstants;
	using OnlineMenu.Web.ViewModels.Home;
	using System.ComponentModel.DataAnnotations.Schema;

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
        public async Task SetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<OnlineMenuDbContext>()
                .UseInMemoryDatabase("OnlineMenuInMemory" + Guid.NewGuid().ToString())
                .Options;

            this.dbContext = new OnlineMenuDbContext(this.dbOptions);
            await this.dbContext.Database.EnsureCreatedAsync();
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
            bool isExisting = await this.dbContext.Food.AnyAsync(f => f.IsDeleted == false && f.Id.ToString() == modelId);

            Assert.IsTrue(isExisting);
        }

        [Test]
        public async Task IsFoodExistingByIdAsync_ShouldReturnTrueWhenExisting()
        {
            Food? food = await this.dbContext.Food
                .FirstOrDefaultAsync(f => f.IsDeleted == false);

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
				.FirstOrDefaultAsync(f => f.IsDeleted == false);

			Assert.IsNotNull(food, ItemNotFoundTestMessage);

			await this.foodService.AddToFavouriteAsync(food.Id.ToString(), User.Id.ToString());

            bool isInFavourite = await this.dbContext.UsersFood.AnyAsync(uf => uf.FoodId == food!.Id && uf.UserId == User.Id);
            Assert.IsTrue(isInFavourite);   
		}

        [Test]
        public async Task RemoveFromFavouriteAsync_ShouldWorkProperly()
        {
			Food? food = await this.dbContext.Food
				.FirstOrDefaultAsync(f => f.IsDeleted == false);

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
				.FirstOrDefaultAsync(f => f.IsDeleted == false);

			Assert.IsNotNull(food, ItemNotFoundTestMessage);

            bool isInFavourite = await this.foodService.IsFoodInFavouriteAsync(User.Id.ToString(), food!.Id.ToString());

            Assert.IsFalse(isInFavourite);
		}

		[Test]
		public async Task IsFoodInFavouriteAsync_ShouldReturnTrueWhenInFavourite()
        {
			Food? food = await this.dbContext.Food
				.FirstOrDefaultAsync(f => f.IsDeleted == false);

			Assert.IsNotNull(food, ItemNotFoundTestMessage);

            await this.foodService.AddToFavouriteAsync(food.Id.ToString(), User.Id.ToString());

			bool isInFavourite = await this.foodService.IsFoodInFavouriteAsync(User.Id.ToString(), food!.Id.ToString());

            Assert.IsTrue(isInFavourite);
		}

        [Test]
        public async Task DeleteFoodAsync_ShouldSetIsDeletedPropertyOfFoodToTrue()
        {
            Food? food = await this.dbContext.Food.FirstOrDefaultAsync(f => f.IsDeleted == false);
            Assert.IsNotNull(food, ItemNotFoundTestMessage);

            await this.foodService.DeleteFoodAsync(food.Id.ToString());

            bool isDeleted = await this.dbContext.Food.AnyAsync(f => f.IsDeleted == true && f.Id == food.Id);
            Assert.IsTrue(isDeleted);
        }

        [Test]
        public async Task DeleteFoodAsync_ShouldThrowWhenInvalidIdPassed()
        {
            string invalidId = "invalidFooodId";

            Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await this.foodService.DeleteFoodAsync(invalidId);
            });
        }

		[Test]
        public async Task DeleteFoodByCategoryIdAsync_ShouldDeleteAllFoodItemsWithGivenCategoryId()
        {
            Food? food = await this.dbContext.Food.FirstOrDefaultAsync(f => f.IsDeleted == false);
            Assert.IsNotNull(food, ItemNotFoundTestMessage);

            await this.foodService.DeleteFoodByCategoryIdAsync(food.FoodCategoryId);

            bool isAnyFoodWithCategory = await this.dbContext.Food.AnyAsync(f => f.IsDeleted == false && f.FoodCategoryId == food.FoodCategoryId);
            Assert.IsFalse(isAnyFoodWithCategory);
        }

        [Test]
        public async Task DeleteFoodByCategoryIdAsync_ShouldNotDeleteAnyFoodWhenWrongCategoryIdPassed()
        {
            int notExistingfoodCategoryId = int.MinValue;
            int expectedFoodCount = await this.dbContext.Food.CountAsync();

            await this.foodService.DeleteFoodByCategoryIdAsync(notExistingfoodCategoryId);

            int actualFoodCount = await this.dbContext.Food.CountAsync();

            Assert.AreEqual(expectedFoodCount, actualFoodCount);
        }

        [Test]
        public async Task GetFoodForEditAsync_AshouldReturnTheCorrectItem()
        {
            Food? food = await this.dbContext.Food.FirstOrDefaultAsync(f => f.IsDeleted == false);
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
        public async Task GetFoodForEditAsync_ShouldThrowWhenInvalidIdPassed()
        {
            string foodId = "someinvalidfoodidididididid";

            Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await this.foodService.GetFoodForEditAsync(foodId);
            });
        }

		[Test]
        public async Task EditFoodAsync_ShouldEditFoodCorrectly()
        {
			Food? food = await this.dbContext.Food.FirstOrDefaultAsync(f => f.IsDeleted == false);
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

        [Test]
        public async Task GetAllFoodByQueryModelAsync_ShouldReturnFoodItemsWithGivenCategory()
        {
            string? foodCategory = await this.dbContext.FoodCategories
                .Where(fc => fc.IsDeleted == false)
                .Select(fc => fc.Name)
                .FirstOrDefaultAsync();

            Assert.IsNotNull(foodCategory, ItemNotFoundTestMessage);
            
            ICollection<Food> food = await this.dbContext.Food
                .Where(f => f.IsDeleted == false && f.Category.Name == foodCategory)
                .ToArrayAsync();


			FoodQueryModel foodQueryModel = new FoodQueryModel
            {
                Category = foodCategory
			};

			FoodQueryModel returnedModel = await this.foodService.GetAllFoodByQueryModelAsync(foodQueryModel);

            bool isCategoryMissing = false;

            foreach (var currentFood in returnedModel.FoodAll)
            {
                if (!food.Any(f => f.Id.ToString() == currentFood.Id))
                {
                    isCategoryMissing = true;
                    break;
                }
            }

            int expectedCount = food.Count;
            int actualCount = returnedModel.FoodAll.Count();

			Assert.AreEqual(expectedCount, actualCount);
            Assert.IsFalse(isCategoryMissing);
		}

        [Test]
        public async Task GetAllFoodByQueryModelAsync_ShouldReturnExactItemByKeyword()
        {
            string? keywordFoodName = await this.dbContext.Food
                .Where(f => f.IsDeleted == false)
                .Select(f => f.Name)
                .FirstOrDefaultAsync();

            Assert.IsNotNull(keywordFoodName, ItemNotFoundTestMessage);

			FoodQueryModel foodQueryModel = new FoodQueryModel
            {
                Keyword = keywordFoodName 
            };

            FoodQueryModel returnedModel = await this.foodService.GetAllFoodByQueryModelAsync(foodQueryModel);

            FoodAllViewModel? foodSearched = returnedModel.FoodAll.FirstOrDefault(f => f.Name == keywordFoodName);
            Assert.IsNotNull(foodSearched, ItemNotFoundTestMessage);

			string expectedFoodName = keywordFoodName;
            string actualFoodName = foodSearched.Name;

            Assert.AreEqual(expectedFoodName, actualFoodName);
		}

        [Test]
        public async Task GetFavouriteFoodAsync_ShouldReturnFavouriteFoodOfGivenUser()
        {
            Food? food = await this.dbContext.Food.FirstOrDefaultAsync(f => f.IsDeleted == false);
            Assert.IsNotNull(food, ItemNotFoundTestMessage);

            await this.foodService.AddToFavouriteAsync(food.Id.ToString(), User.Id.ToString());

            ApplicationUser? user = await this.dbContext.Users.FirstOrDefaultAsync();
            Assert.IsNotNull(user, UserNotFoundTestMessage);

            ICollection<FoodAllViewModel> favouriteFood = await this.foodService.GetFavouriteFoodAsync(user.Id.ToString());

            string expectedFood = food.Name;
            string actualFood = favouriteFood.First().Name;

            Assert.AreEqual(expectedFood, actualFood);
		}

        [Test]
        public async Task GetFavouriteFoodAsync_ShouldReturnEmptyCollectionWhenWrongIdPassed()
        {
            string userId = "WrongUserIdABABA-123";
            ICollection<FoodAllViewModel> favouriteFood = await this.foodService.GetFavouriteFoodAsync(userId);

            int expectedCount = 0;
            int actualCount = favouriteFood.Count;

            Assert.AreEqual(expectedCount, actualCount);
		}

        [Test]
        public async Task GetFoodCountAsync_ShouldReturnTheExactCountOfFoodItems()
        {
            int expectedCount = await this.dbContext.Food.CountAsync(f => f.IsDeleted == false);
            int actualCount = await this.foodService.GetFoodCountAsync();

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public async Task GetFoodDetailsAsync_ShouldThrowWhenNotExistinIdPassed()
        {
            string foodId = "notexistingfoodidABABABA-29382";

            Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await this.foodService.GetFoodDetailsAsync(foodId);
            });
        }

        [Test]
        public async Task GetFoodDetailsAsync_ShouldReturnFoodWithProperDescription()
        {
            Food? food = await this.dbContext.Food.FirstOrDefaultAsync();
            Assert.IsNotNull(food, ItemNotFoundTestMessage);

            FoodDetailsViewModel viewModel = await this.foodService.GetFoodDetailsAsync(food.Id.ToString());

            string expectedDescription = food.Description;
            string actualDescription = viewModel.Description;

            Assert.AreEqual(expectedDescription, actualDescription);
		}

        [Test]
        public async Task GetFoodForDeleteAsync_ShouldThrowWhenInvalidFoodIdPassed()
        {
            string foodId = "someInvalidFoodId129393";

            Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await this.foodService.GetFoodForDeleteAsync(foodId);
            });
        }

        [Test]
        public async Task GetFoodForDeleteAsync_ShoulReturnTheExactModelById()
        {
            Food? food = await this.dbContext.Food.FirstOrDefaultAsync();
            Assert.IsNotNull(food, ItemNotFoundTestMessage);
            FoodDeleteViewModel viewModel = await this.foodService.GetFoodForDeleteAsync(food.Id.ToString());

            Assert.AreEqual(food.Name, viewModel.Name);
            Assert.AreEqual(food.Description, viewModel.Description);
            Assert.AreEqual(food.ImageUrl, viewModel.ImageUrl);
		}

        [Test]
        public async Task GetFoodForIndexAsync_ShouldReturnItemsByCategoryRequested()
        {
            ICollection<IndexViewModel> indexViewModels = await this.foodService.GetFoodForIndexAsync();
            int expectedCount = await this.dbContext.Food.CountAsync(f => f.IsDeleted == false && f.Category.Name == DessertsFoodCategoryForIndex || f.Category.Name == BurgersFoodCategoryForIndex);
            int actualCount = indexViewModels.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public async Task GetFoodNamesByCategoryIdAsync_ShouldReturnEmptyStringWhenInvalidCategoryIdPassed()
        {
            int foodCategoryId = int.MinValue;
            string foodNames = await this.foodService.GetFoodNamesByCategoryIdAsync(foodCategoryId);
            Assert.IsEmpty(foodNames);
        }

        [Test]
        public async Task GetFoodNamesByCategoryIdAsync_ShouldReturnFoodNamesByGivenFoodCategoryId()
        {
            int foodCategoryId = await this.dbContext.FoodCategories
                .Where(fc => fc.IsDeleted == false)
                .Select(fc => fc.Id)
                .FirstOrDefaultAsync();

            ICollection<string> food = await this.dbContext.Food
                .Where(f => f.IsDeleted == false && f.FoodCategoryId == foodCategoryId)
                .Select(f => f.Name)
                .ToArrayAsync();

            string expectedNames = string.Join(", ", food);
            string actualNames = await this.foodService.GetFoodNamesByCategoryIdAsync(foodCategoryId);

            Assert.AreEqual(expectedNames, actualNames);
        }

		[TearDown]
        public async Task TearDown()
        {
            await this.dbContext.Database.EnsureDeletedAsync();
            await this.dbContext.DisposeAsync();
        }
    }
}
