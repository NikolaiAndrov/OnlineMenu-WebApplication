namespace OnlineMenu.Services.Interfaces
{
	using OnlineMenu.Web.ViewModels.Manager;

	public interface IManagerService
	{
		Task<bool> IsManagerExistingByUserIdAsync(string userId);

		Task<bool> IsManagerExistingByUserEmailAsync(string userEmail);

		Task AddManagerAsync(AddManagerPostModel model, string userId);
	}
}
