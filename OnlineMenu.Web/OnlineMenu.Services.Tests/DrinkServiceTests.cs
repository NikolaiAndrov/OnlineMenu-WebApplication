namespace OnlineMenu.Services.Tests
{
    using Microsoft.EntityFrameworkCore;
    using OnlineMenu.Data;
	using OnlineMenu.Services.Interfaces;
    using static InMemoryDatabaseSeeder;

	[TestFixture]
	public class DrinkServiceTests
	{
        private DbContextOptions<OnlineMenuDbContext> dbOptions;
        private OnlineMenuDbContext dbContext;
        private IDrinkService drinkService;

        public DrinkServiceTests()
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
            Seed(dbContext);

            this.drinkService = new DrinkService(this.dbContext);
        }

        [Test]
        public async Task IsDrinkExistingByIdAsync_ShouldReturnFalseWhenInvalidIdPassed()
        {
            string drinkId = "someinvalidid123123-abababa";
            bool isDrinkExisting = await this.drinkService.IsDrinkExistingByIdAsync(drinkId);

            Assert.IsFalse(isDrinkExisting);
        }




		[TearDown] 
        public async Task TearDown()
        {
            await this.dbContext.Database.EnsureCreatedAsync();
            await this.dbContext.DisposeAsync();
        }
    }
}
