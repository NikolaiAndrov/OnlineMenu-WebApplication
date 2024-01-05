namespace OnlineMenu.Services.Interfaces
{
    public interface IUserService
    {
        Task<bool> IsUserExistingByEmailAsync(string email);

        Task<string> GetUserIdByEmailAsync(string email);
    }
}
