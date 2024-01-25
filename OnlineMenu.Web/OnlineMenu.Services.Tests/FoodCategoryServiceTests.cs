namespace OnlineMenu.Services.Tests
{
    using Microsoft.EntityFrameworkCore;
    using OnlineMenu.Data;
	using OnlineMenu.Data.Models;
	using OnlineMenu.Services.Interfaces;
	using OnlineMenu.Web.ViewModels.FoodCategory;
	using static Common.GeneralApplicationMessages;

	[TestFixture]
	public class FoodCategoryServiceTests
	{
        private DbContextOptions<OnlineMenuDbContext> dbOptions;
        private OnlineMenuDbContext dbContext;
        private IFoodCategoryService foodCategoryService;

        public FoodCategoryServiceTests()
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
            this.foodCategoryService = new FoodCategoryService(dbContext);
        }

        [Test]
        public async Task AddNewCategoryAsync_ShouldAddNewCategory()
        {
			FoodCategoryPostModel model = new FoodCategoryPostModel
            {
                Name = "Test",
            };

            await this.foodCategoryService.AddNewCategoryAsync(model);
            bool isCategoryAdded = await this.dbContext.FoodCategories
                .AnyAsync(fc => fc.IsDeleted == false && fc.Name == model.Name);

            Assert.IsTrue(isCategoryAdded);
		}

        [Test]
        public async Task DeleteCategoryAsync_ShouldDeleteGivenCategory()
        {
            FoodCategory? foodCategory = await this.dbContext.FoodCategories
                .FirstOrDefaultAsync(fc => fc.IsDeleted == false);
            Assert.IsNotNull(foodCategory, ItemNotFoundTestMessage);

            await this.foodCategoryService.DeleteCategoryAsync(foodCategory.Id);

            bool isAnyActiveCategory = await this.dbContext.FoodCategories
                .AnyAsync(fc => fc.IsDeleted == false && fc.Id == foodCategory.Id);

            Assert.False(isAnyActiveCategory);
        }

		[Test]
        public async Task IsCategoryExistingByIdAsync_ShoulReturnTrueWhenCategoryExistung()
        {
            FoodCategory? category = await this.dbContext.FoodCategories
                .FirstOrDefaultAsync(fc => fc.IsDeleted == false);
            Assert.IsNotNull(category, ItemNotFoundTestMessage);

            bool isExisting = await this.foodCategoryService.IsCategoryExistingByIdAsync(category.Id);
            Assert.IsTrue(isExisting);
        }

        [Test]
        public async Task IsCategoryExistingByIdAsync_ShouldReturnFalseWhenCategoryNotExisting()
        {
            int id = int.MinValue;
            bool isExisting = await this.foodCategoryService.IsCategoryExistingByIdAsync(id);

            Assert.IsFalse(isExisting);
        }

        [Test]
        public async Task IsCategoryExistingByIdAsync_ShouldReturnFalseWhenCategoryDeleted()
        {
            FoodCategory? foodCategory = await this.dbContext.FoodCategories
                .FirstOrDefaultAsync(fc => fc.IsDeleted == false);
            Assert.IsNotNull(foodCategory, ItemNotFoundTestMessage);

            await this.foodCategoryService.DeleteCategoryAsync(foodCategory.Id);

            bool isCategoruExisting = await this.foodCategoryService.IsCategoryExistingByIdAsync(foodCategory.Id);
            Assert.IsFalse(isCategoruExisting);
        }

		[Test]
        public async Task IsCategoryExistingByNameAsync_ShouldReturnTrueWhenExisting()
        {
            FoodCategory? foodCategory = await this.dbContext.FoodCategories
                .FirstOrDefaultAsync(fc => fc.IsDeleted == false);
            Assert.IsNotNull(foodCategory, ItemNotFoundTestMessage);

            bool isExisting = await this.foodCategoryService.IsCategoryExistingByNameAsync(foodCategory.Name);
            Assert.IsTrue(isExisting);
        }

        [Test]
        public async Task IsCategoryExistingByNameAsync_ShouldReturnDalseWhenNotExisting()
        {
            string name = "test" + Guid.NewGuid().ToString();
            bool isExisting = await this.foodCategoryService.IsCategoryExistingByNameAsync(name);
            Assert.IsFalse(isExisting);
        }

        [Test]
        public async Task IsCategoryExistingByNameAsync_ShouldReturnFalseWhenCategoryDeleted()
        {
			FoodCategory? foodCategory = await this.dbContext.FoodCategories
			   .FirstOrDefaultAsync(fc => fc.IsDeleted == false);
			Assert.IsNotNull(foodCategory, ItemNotFoundTestMessage);

			await this.foodCategoryService.DeleteCategoryAsync(foodCategory.Id);

			bool isCategoruExisting = await this.foodCategoryService.IsCategoryExistingByNameAsync(foodCategory.Name);
			Assert.IsFalse(isCategoruExisting);
		}

        [Test]
        public async Task GetCategoryForEditAsync_ShouldReturnExactCategory()
        {
            FoodCategory? foodCategory = await this.dbContext.FoodCategories
                .FirstOrDefaultAsync(fc => fc.IsDeleted == false);
            Assert.IsNotNull(foodCategory, ItemNotFoundTestMessage);

            FoodCategoryPostModel model = await this.foodCategoryService.GetCategoryForEditAsync(foodCategory.Id);

            Assert.That(model.Name, Is.EqualTo(foodCategory.Name));
		}

        [Test]
        public async Task GetAllFoodCategoriesAsync_ShouldReturnAllCategories()
        {
			ICollection<FoodCategoryViewModel> foodCategories = await this.dbContext.FoodCategories
                .Where(fc => fc.IsDeleted == false)
                .Select(fc => new FoodCategoryViewModel
                {
                    Id = fc.Id,
                    Name = fc.Name,
                })
                .ToArrayAsync();

			ICollection<FoodCategoryViewModel> returnedCategories = await this.foodCategoryService.GetAllFoodCategoriesAsync();

			int expectedCount = foodCategories.Count;
            int actualCount = returnedCategories.Count;

            Assert.That(actualCount, Is.EqualTo(expectedCount));
		}

        [Test]
        public async Task GetFoodCategoryNamesAsync_ShouldReturnAllCategoriesNames()
        {
			ICollection<string> names = await this.dbContext.FoodCategories
			   .Where(fc => fc.IsDeleted == false)
			   .Select(fc => fc.Name)
			   .ToArrayAsync();

            ICollection<string> returnedNames = await this.foodCategoryService.GetFoodCategoryNamesAsync();

            string expectedNames = string.Join(", ", names);
            string actualNames = string.Join(", ", returnedNames);

            Assert.That(actualNames, Is.EqualTo(expectedNames));
		}

        [Test]
        public async Task EditCategoryAsync_ShouldEditCategory()
        {
            FoodCategory? foodCategory = await this.dbContext.FoodCategories
                .FirstOrDefaultAsync(fc => fc.IsDeleted == false);
            Assert.IsNotNull(foodCategory, ItemNotFoundTestMessage);

			FoodCategoryPostModel model = new FoodCategoryPostModel
            {
                Name = "Test",
            };

            await this.foodCategoryService.EditCategoryAsync(model, foodCategory.Id);

			Assert.That(model.Name, Is.EqualTo(foodCategory.Name));
		}

        [Test]
        public async Task GetCategoryForDeleteAsync_ShouldReturnRequestedCategory()
        {
            FoodCategory? foodCategory = await this.dbContext.FoodCategories
                .FirstOrDefaultAsync(fc => fc.IsDeleted == false);
            Assert.IsNotNull(foodCategory, ItemNotFoundTestMessage);

            FoodCategoryDeleteViewModel deleteModel = await this.foodCategoryService.GetCategoryForDeleteAsync(foodCategory.Id);

            Assert.That(deleteModel.Id, Is.EqualTo(foodCategory.Id));
            Assert.That(deleteModel.Name, Is.EqualTo(foodCategory.Name));
		}

		[TearDown]
        public async Task TearDown()
        {
            await this.dbContext.Database.EnsureDeletedAsync();
            await this.dbContext.DisposeAsync();
        }

	}
}
