namespace OnlineMenu.Services.Interfaces
{
    public interface IUserService
    {
        Task<bool> IsUserExistingByEmailAsync(string email);

        Task<string> GetUserIdByEmailAsync(string email);

        Task<bool> IsFoodInFavourite(string userId, string foodId);

        Task<bool> IsDrinkInFavourite(string userId, string drinkId);

        Task<bool> IsUserExistingByIdAsync(string userId);
    }
}
