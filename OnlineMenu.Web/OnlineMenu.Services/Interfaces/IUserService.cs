namespace OnlineMenu.Services.Interfaces
{
    using Microsoft.AspNetCore.Identity;
    using OnlineMenu.Web.ViewModels.User;

    public interface IUserService
    {
        Task<bool> IsUserExistingByEmailAsync(string email);

        Task<string> GetUserIdByEmailAsync(string email);

        Task<bool> IsFoodInFavourite(string userId, string foodId);

        Task<bool> IsDrinkInFavourite(string userId, string drinkId);

        Task<bool> IsUserExistingByIdAsync(string userId);

        Task<string> GetFullNameByIdAsync(string userId);

        Task<ICollection<UserViewModel>> GetAllUsersAsync();

        Task<UpdateUserPostModel> GetUserForUpdateAsync(string userId);

        Task UpdateFullNameAsync(string userId, UpdateUserPostModel model);
    }
}
