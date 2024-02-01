namespace OnlineMenu.Services
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using OnlineMenu.Data;
    using OnlineMenu.Data.Models;
    using OnlineMenu.Services.Interfaces;
    using OnlineMenu.Web.ViewModels.User;
	using System.Collections.Generic;
    using static Common.GeneralApplicationConstants;

	public class UserService : IUserService
    {
        private readonly OnlineMenuDbContext dbContext;
        private readonly UserManager<ApplicationUser> userManager;

		public UserService(OnlineMenuDbContext dbContext,
            UserManager<ApplicationUser> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

		public async Task<ICollection<UserViewModel>> GetAllUsersAsync()
		{
			ICollection<UserViewModel> allUsers = await this.dbContext.Users
                .AsNoTracking()
                .Select(u => new UserViewModel
                {
                    Id = u.Id.ToString(),
                    FullName = u.FirstName + " " + u.LastName,
                    Email = u.Email,
                    PhoneNumber = string.Empty
                })
                .ToListAsync();

            foreach (var user in allUsers)
            {
                Manager? manager = await this.dbContext.Managers
                    .FirstOrDefaultAsync(m => m.UserId.ToString() == user.Id);

                if (manager != null)
                {
                    user.PhoneNumber = manager.PhoneNumber;
                }

                ApplicationUser? applicationUser = await this.dbContext.Users
                    .FirstOrDefaultAsync(u => u.Id.ToString() == user.Id);

                if (applicationUser != null)
                {
                    user.IsAdmin = await this.userManager.IsInRoleAsync(applicationUser, AdminRoleName);
                }
            }

            allUsers = allUsers
                .OrderByDescending(u => u.IsAdmin)
                .ThenByDescending(u => u.PhoneNumber.Length)
                .ThenBy(u => u.FullName)
                .ToList();

            return allUsers;
		}

		public async Task<string> GetFullNameByIdAsync(string userId)
		{
			ApplicationUser? user = await this.dbContext.Users
                .FirstOrDefaultAsync(u => u.Id.ToString() == userId);

            if (user == null)
            {
                return string.Empty;
            }

            return $"{user.FirstName} {user.LastName}";
		}

		public async Task<UpdateUserPostModel> GetUserForUpdateAsync(string userId)
		{
			UpdateUserPostModel viewModel = await this.dbContext.Users
                .Where(u => u.Id.ToString() == userId)
                .Select(u => new UpdateUserPostModel
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName
                })
                .FirstAsync();

            return viewModel;
		}

		public async Task<string> GetUserIdByEmailAsync(string email)
        {
            string userId = await this.dbContext.Users
                .Where(u => u.Email == email)
                .Select(u => u.Id.ToString())
                .FirstAsync();

            return userId!;
        }

        public async Task<bool> IsDrinkInFavourite(string userId, string drinkId)
            => await this.dbContext.UsersDrinks.AnyAsync(ud => ud.UserId.ToString() == userId && ud.DrinkId.ToString() == drinkId);

		public async Task<bool> IsFoodInFavourite(string userId, string foodId)
            => await this.dbContext.UsersFood.AnyAsync(uf => uf.UserId.ToString() == userId && uf.FoodId.ToString() == foodId);

		public async Task<bool> IsUserExistingByEmailAsync(string email)
            => await this.dbContext.Users.AnyAsync(u => u.Email == email);

        public async Task<bool> IsUserExistingByIdAsync(string userId)
            => await this.dbContext.Users.AnyAsync(u => u.Id.ToString() == userId);

		public async Task UpdateFullNameAsync(string userId, UpdateUserPostModel model)
		{
            ApplicationUser user = await this.dbContext.Users
                .FirstAsync(u => u.Id.ToString() == userId);

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;

            await this.dbContext.SaveChangesAsync();
		}
	}
}
