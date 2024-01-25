namespace OnlineMenu.Services.Tests
{
	using Microsoft.EntityFrameworkCore;
	using OnlineMenu.Data;
	using OnlineMenu.Services.Interfaces;
	using OnlineMenu.Web.ViewModels.DrinkCategory;

	[TestFixture]
	public class DrinkCategoryServiceTests
	{
		private DbContextOptions<OnlineMenuDbContext> dbOptions;
		private OnlineMenuDbContext dbContext;
		private IDrinkCategoryService drinkCategoryService;

		public DrinkCategoryServiceTests()
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
			this.drinkCategoryService = new DrinkCategoryService(dbContext);
		}

		[Test]
		public async Task AddNewCategoryAsync_ShouldAddNewCategory()
		{
			DrinkCategoryPostModel model = new DrinkCategoryPostModel
			{
				Name = "Test"
			};

			await this.drinkCategoryService.AddNewCategoryAsync(model);
			bool isCategoryExisting = await this.dbContext.DrinksCategories
				.AnyAsync(dc => dc.IsDeleted == false && dc.Name == model.Name);

			Assert.IsTrue(isCategoryExisting);
		}


		[TearDown]
		public async Task TearDown()
		{
			await this.dbContext.Database.EnsureDeletedAsync();
			await this.dbContext.DisposeAsync();
		}
	}
}
