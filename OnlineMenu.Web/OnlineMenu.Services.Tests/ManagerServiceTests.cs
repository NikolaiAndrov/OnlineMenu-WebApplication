namespace OnlineMenu.Services.Tests
{
	using Microsoft.EntityFrameworkCore;
	using OnlineMenu.Data;
	using OnlineMenu.Services.Interfaces;
	using OnlineMenu.Web.ViewModels.Manager;
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

        [SetUp]
		public async Task SetUp()
		{
			this.dbOptions = new DbContextOptionsBuilder<OnlineMenuDbContext>()
				.UseInMemoryDatabase("OnlineMenuInMemory" + Guid.NewGuid().ToString())
				.Options;

			this.dbContext = new OnlineMenuDbContext(this.dbOptions);

			await this.dbContext.Database.EnsureDeletedAsync();

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
		public async Task IsManagerExistingByUserIdAsync_ShoulReturnFalseWhenNullPassed()
		{
			bool isManagerExisting = await this.managerService.IsManagerExistingByUserIdAsync(null);

			Assert.IsFalse(isManagerExisting);
		}

		[Test]
		public async Task IsManagerExistingByUserIdAsync_ShoulReturnTrueWhenManagerExisting()
		{
			 bool isManagerExisting = await this.managerService.IsManagerExistingByUserIdAsync(ManagerUser.Id.ToString());

			Assert.IsTrue(isManagerExisting);
		}

		[Test]
		public async Task IsManagerExistingByUserEmailAsync_ShoulReturnFalseWhenManagerNotExisting()
		{
			bool isManagerExisting = await this.managerService.IsManagerExistingByUserEmailAsync(User.Email);

			Assert.IsFalse(isManagerExisting);
		}

		[Test]
		public async Task IsManagerExistingByUserEmailAsync_ShoulReturnFalseWhenNullPassed()
		{
			bool isManagerExisting = await this.managerService.IsManagerExistingByUserEmailAsync(null);

			Assert.IsFalse(isManagerExisting);
		}

		[Test]
		public async Task IsManagerExistingByUserEmailAsync_ShoulReturnTrueWhenManagerExisting()
		{
			bool isManagerExisting = await this.managerService.IsManagerExistingByUserEmailAsync(ManagerUser.Email);

			Assert.IsTrue(isManagerExisting);
		}

		[Test]
		public async Task AddManagerAsync_ShouldWorkProperly()
		{
			AddManagerPostModel model = new AddManagerPostModel
			{
				PhoneNumber = "+359898968989",
				Email = User.Email
			};

			await this.managerService.AddManagerAsync(model, User.Id.ToString());

			bool isManagerExisting = await this.managerService.IsManagerExistingByUserIdAsync(User.Id.ToString());

			Assert.IsTrue(isManagerExisting);
		}

		[Test]
		public async Task RemoveManagerByUserIdAsync_ShouldWorkProperly()
		{
			await this.managerService.RemoveManagerByUserIdAsync(ManagerUser.Id.ToString());

			bool isManagerExisting = await this.managerService.IsManagerExistingByUserIdAsync(ManagerUser.Id.ToString());

			Assert.IsFalse(isManagerExisting);
		}

		[TearDown]
		public async Task TearDown()
		{
			await this.dbContext.Database.EnsureDeletedAsync();
			await this.dbContext.DisposeAsync();
		}
	}
}