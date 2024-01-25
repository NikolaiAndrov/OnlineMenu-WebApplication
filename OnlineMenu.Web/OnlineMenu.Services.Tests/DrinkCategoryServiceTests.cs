namespace OnlineMenu.Services.Tests
{
	using Microsoft.EntityFrameworkCore;
	using OnlineMenu.Data;
	using OnlineMenu.Data.Models;
	using OnlineMenu.Services.Interfaces;
	using OnlineMenu.Web.ViewModels.DrinkCategory;
	using static Common.GeneralApplicationMessages;

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

		[Test]
		public async Task DeleteCategoryAsync_ShouldSoftDeleteGivenCategory()
		{
			DrinkCategory? drinkCategory = await this.dbContext.DrinksCategories
				.FirstOrDefaultAsync(dc => dc.IsDeleted == false);
			Assert.IsNotNull(drinkCategory, ItemNotFoundTestMessage);

			await this.drinkCategoryService.DeleteCategoryAsync(drinkCategory.Id);
			bool isCategoryExisting = await this.dbContext.DrinksCategories
				.AnyAsync(dc => dc.IsDeleted == false && dc.Id == drinkCategory.Id);

			Assert.IsFalse(isCategoryExisting);
		}

		[Test]
		public async Task IsCategoryExistingByIdAsync_ShouldReturnTrueWhenExist()
		{
			DrinkCategory? drinkCategory = await this.dbContext.DrinksCategories
				.FirstOrDefaultAsync(dc => dc.IsDeleted == false);
			Assert.IsNotNull(drinkCategory, ItemNotFoundTestMessage);

			bool isExisting = await this.drinkCategoryService.IsCategoryExistingByIdAsync(drinkCategory.Id);
			Assert.IsTrue(isExisting);
		}

		[Test]
		public async Task IsCategoryExistingByIdAsync_ShouldReturnFalseWhenNotExisting()
		{
			int id = int.MinValue;
			bool isCategoriExisting = await this.drinkCategoryService.IsCategoryExistingByIdAsync(id);
			Assert.IsFalse(isCategoriExisting);
		}

		[Test]
		public async Task IsCategoryExistingByIdAsync_ShouldReturnFalseWhenDeleted()
		{
			DrinkCategory? drinkCategory = await this.dbContext.DrinksCategories
				.FirstOrDefaultAsync(dc => dc.IsDeleted == false);
			Assert.IsNotNull(drinkCategory, ItemNotFoundTestMessage);

			await this.drinkCategoryService.DeleteCategoryAsync(drinkCategory.Id);
			bool isCategoryExisting = await this.drinkCategoryService.IsCategoryExistingByIdAsync(drinkCategory.Id);

			Assert.IsFalse(isCategoryExisting);
		}

		[TearDown]
		public async Task TearDown()
		{
			await this.dbContext.Database.EnsureDeletedAsync();
			await this.dbContext.DisposeAsync();
		}
	}
}
