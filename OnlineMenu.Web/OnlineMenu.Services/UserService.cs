namespace OnlineMenu.Services
{
    using Microsoft.EntityFrameworkCore;
    using OnlineMenu.Data;
    using OnlineMenu.Services.Interfaces;

    public class UserService : IUserService
    {
        private readonly OnlineMenuDbContext dbContext;

        public UserService(OnlineMenuDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<string> GetUserIdByEmailAsync(string email)
        {
            string userId = await this.dbContext.Users
                .Where(u => u.Email == email)
                .Select(u => u.Id.ToString())
                .FirstAsync();

            return userId!;
        }

        public async Task<bool> IsUserExistingByEmailAsync(string email)
            => await this.dbContext.Users.AnyAsync(u => u.Email == email);
    }
}
