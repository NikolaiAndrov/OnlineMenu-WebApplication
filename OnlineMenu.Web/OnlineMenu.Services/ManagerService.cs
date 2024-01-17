namespace OnlineMenu.Services
{
	using Microsoft.EntityFrameworkCore;
	using OnlineMenu.Data;
    using OnlineMenu.Data.Models;
    using OnlineMenu.Services.Interfaces;
    using OnlineMenu.Web.ViewModels.Manager;

    public class ManagerService : IManagerService
	{
		private readonly OnlineMenuDbContext dbContext;

        public ManagerService(OnlineMenuDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddManagerAsync(AddManagerPostModel model, string userId)
        {
            Manager manager = new Manager
            {
                PhoneNumber = model.PhoneNumber,
                UserId = Guid.Parse(userId)
            };

            await this.dbContext.Managers.AddAsync(manager);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<bool> IsManagerExistingByUserEmailAsync(string userEmail)
            => await this.dbContext.Managers.AnyAsync(m => m.User.Email == userEmail);

        public async Task<bool> IsManagerExistingByUserIdAsync(string userId)
			=> await this.dbContext.Managers.AnyAsync(m => m.UserId.ToString() == userId);

		public async Task RemoveManagerByUserIdAsync(string userId)
		{
            Manager manager = await this.dbContext.Managers
                .FirstAsync(m => m.UserId.ToString() == userId);

            this.dbContext.Managers.Remove(manager);
            
            await this.dbContext.SaveChangesAsync();
		}
	}
}
