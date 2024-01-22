namespace OnlineMenu.Services.Tests
{
	using Microsoft.EntityFrameworkCore;
	using OnlineMenu.Data;
	using OnlineMenu.Services.Interfaces;
	using static InMemoryDatabaseSeeder;

	[TestFixture]
	public class ManagerServiceTests
	{
		private DbContextOptions<OnlineMenuDbContext> dbOptions;
		private OnlineMenuDbContext dbContext;
		private IManagerService managerService;

        public ManagerServiceTests()
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

			this.managerService = new ManagerService(dbContext);
		}

		[Test]
		public async Task IsManagerExistingByUserIdAsync_ShoulReturnFalseWhenManagerNotExisting()
		{
			bool isManagerExisting = await this.managerService.IsManagerExistingByUserIdAsync(User.Id.ToString());

			Assert.IsFalse(isManagerExisting);  
		}

		[Test]
		public async Task IsManagerExistingByUserIdAsync_ShoulReturnTrueWhenManagerExisting()
		{
			 bool isManagerExisting = await this.managerService.IsManagerExistingByUserIdAsync(ManagerUser.Id.ToString());

			Assert.IsTrue(isManagerExisting);
		}

		[OneTimeTearDown]
		public void OneTimeTearDown()
		{
			this.dbContext.Database.EnsureDeleted();
		}
	}
}