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
                FirstName = model.FirstName,
                LastName = model.LastName,
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
	}
}
