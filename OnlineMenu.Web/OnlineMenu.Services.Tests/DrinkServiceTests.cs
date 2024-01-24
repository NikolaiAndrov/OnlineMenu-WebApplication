namespace OnlineMenu.Services.Tests
{
    using Microsoft.EntityFrameworkCore;
    using OnlineMenu.Data;
	using OnlineMenu.Services.Interfaces;
    using static InMemoryDatabaseSeeder;
    using static Common.GeneralApplicationMessages;

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

        [Test]
        public async Task IsDrinkExistingByIdAsync_ShouldReturnFalseWhenNullPassed()
        {
            bool isDrinkExisting = await this.drinkService.IsDrinkExistingByIdAsync(null!);
            Assert.IsFalse(isDrinkExisting);
        }

		[Test]
		public async Task IsDrinkExistingByIdAsync_ShouldReturnTrueWhenCorrectIdPassed()
        {
            string? drinkId = await this.dbContext.Drinks
                .Where(d => d.IsDeleted == false)
                .Select(d => d.Id.ToString())
                .FirstOrDefaultAsync();

            Assert.IsNotNull(drinkId, ItemNotFoundTestMessage);

            bool isDrinkExisting = await this.drinkService.IsDrinkExistingByIdAsync(drinkId);
            Assert.IsTrue(isDrinkExisting);
        }


		[TearDown] 
        public async Task TearDown()
        {
            await this.dbContext.Database.EnsureCreatedAsync();
            await this.dbContext.DisposeAsync();
        }
    }
}
