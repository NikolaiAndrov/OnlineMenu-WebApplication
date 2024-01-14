﻿namespace OnlineMenu.Services
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using OnlineMenu.Data;
    using OnlineMenu.Data.Models;
    using OnlineMenu.Services.Interfaces;
    using OnlineMenu.Web.ViewModels.User;

    public class UserService : IUserService
    {
        private readonly OnlineMenuDbContext dbContext;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public UserService(OnlineMenuDbContext dbContext,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
            this.signInManager = signInManager;
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

        public async Task<IdentityResult> RegisterAsync(RegisterFormModel model)
        {
            ApplicationUser user = new ApplicationUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            await this.userManager.SetEmailAsync(user, model.Email);
            await this.userManager.SetUserNameAsync(user, user.Email);

            IdentityResult result = await this.userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await this.signInManager.SignInAsync(user, false);
            }

            return result;
        }
    }
}
