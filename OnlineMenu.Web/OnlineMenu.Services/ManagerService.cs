namespace OnlineMenu.Services
{
	using Microsoft.EntityFrameworkCore;
	using OnlineMenu.Data;
	using OnlineMenu.Services.Interfaces;

	public class ManagerService : IManagerService
	{
		private readonly OnlineMenuDbContext dbContext;

        public ManagerService(OnlineMenuDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

		public async Task<bool> IsManagerExistingByUserId(string userId)
			=> await this.dbContext.Managers.AnyAsync(m => m.UserId.ToString() == userId);
	}
}
