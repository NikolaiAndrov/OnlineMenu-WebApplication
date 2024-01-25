namespace OnlineMenu.Services.Tests
{
    using Microsoft.EntityFrameworkCore;
    using OnlineMenu.Data;
	using OnlineMenu.Services.Interfaces;
	using OnlineMenu.Web.ViewModels.FoodCategory;

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

		[TearDown]
        public async Task TearDown()
        {
            await this.dbContext.Database.EnsureDeletedAsync();
            await this.dbContext.DisposeAsync();
        }

	}
}
