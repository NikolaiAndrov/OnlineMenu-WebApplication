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

		[TearDown]
        public async Task TearDown()
        {
            await this.dbContext.Database.EnsureDeletedAsync();
            await this.dbContext.DisposeAsync();
        }

	}
}
