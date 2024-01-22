namespace OnlineMenu.Services.Tests
{
    using Microsoft.EntityFrameworkCore;
	using OnlineMenu.Data;
	using OnlineMenu.Services.Interfaces;
	using OnlineMenu.Web.ViewModels.Food;
	using static InMemoryDatabaseSeeder;

	[TestFixture]
	public class FoodServiceTests
	{
        private DbContextOptions<OnlineMenuDbContext> dbOptions;
        private OnlineMenuDbContext dbContext;
        private IFoodService foodService;

        public FoodServiceTests()
        {
            
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
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



        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            this.dbContext.Database.EnsureDeleted();
            this.dbContext.Dispose();
        }
    }
}
