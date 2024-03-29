﻿namespace OnlineMenu.Services.Tests
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

		[Test]
		public async Task IsCategoryExistingByNameAsync_ShouldReturnTrueWhenExist()
		{
			DrinkCategory? drinkCategory = await this.dbContext.DrinksCategories
				.FirstOrDefaultAsync(dc => dc.IsDeleted == false);
			Assert.IsNotNull(drinkCategory, ItemNotFoundTestMessage);

			bool isCategoryExisting = await this.drinkCategoryService.IsCategoryExistingByNameAsync(drinkCategory.Name);
			Assert.IsTrue(isCategoryExisting);
		}

		[Test]
		public async Task IsCategoryExistingByNameAsync_ShouldReturnFalseWhenNotExisting()
		{
			string name = "invalid name" + Guid.NewGuid().ToString();
			bool isCategoryExisting = await this.drinkCategoryService.IsCategoryExistingByNameAsync(name);
			Assert.IsFalse(isCategoryExisting);
		}

		[Test]
		public async Task IsCategoryExistingByNameAsync_ShouldReturnFalseWhenDeleted()
		{
			DrinkCategory? drinkCategory = await this.dbContext.DrinksCategories
				.FirstOrDefaultAsync(dc => dc.IsDeleted == false);
			Assert.IsNotNull(drinkCategory, ItemNotFoundTestMessage);

			await this.drinkCategoryService.DeleteCategoryAsync(drinkCategory.Id);
			bool isCategoryExisting = await this.drinkCategoryService.IsCategoryExistingByNameAsync(drinkCategory.Name);

			Assert.IsFalse(isCategoryExisting);
		}

		[Test]
		public async Task EditCategoryAsync_ShouldEditGivenCategory()
		{
			DrinkCategory? drinkCategory = await this.dbContext.DrinksCategories
				.FirstOrDefaultAsync(dc => dc.IsDeleted == false);
			Assert.IsNotNull(drinkCategory, ItemNotFoundTestMessage);

			DrinkCategoryPostModel model = new DrinkCategoryPostModel
			{
				Name = "Test"
			};

			await this.drinkCategoryService.EditCategoryAsync(drinkCategory.Id, model);

			Assert.That(model.Name, Is.EqualTo(drinkCategory.Name));
		}

		[Test]
		public async Task GetAllDrinkCategoriesAsync_ShouldReturnAllCategories()
		{
			ICollection<DrinkCategoryViewModel> drinkCategoryViewModels = await this.drinkCategoryService.GetAllDrinkCategoriesAsync();

			int expectedCount = await this.dbContext.DrinksCategories
				.Where(dc => dc.IsDeleted == false)
				.CountAsync();
			
			int actualCount = drinkCategoryViewModels.Count();

			Assert.That(expectedCount, Is.EqualTo(actualCount));
		}

		[Test]
		public async Task GetCategoryForDeleteAsync_ShouldReturnRequestedCategory()
		{
			DrinkCategory? drinkCategory = await this.dbContext.DrinksCategories
				.FirstOrDefaultAsync(dc => dc.IsDeleted == false);
			Assert.IsNotNull(drinkCategory, ItemNotFoundTestMessage);

			DrinkCategoryDeleteViewModel model = await this.drinkCategoryService.GetCategoryForDeleteAsync(drinkCategory.Id);

			Assert.That(drinkCategory.Id, Is.EqualTo(model.Id));
			Assert.That(drinkCategory.Name, Is.EqualTo(model.Name));
		}

		[TearDown]
		public async Task TearDown()
		{
			await this.dbContext.Database.EnsureDeletedAsync();
			await this.dbContext.DisposeAsync();
		}
	}
}
