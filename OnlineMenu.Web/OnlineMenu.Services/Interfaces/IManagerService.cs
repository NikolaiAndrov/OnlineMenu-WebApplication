namespace OnlineMenu.Services.Interfaces
{
	public interface IManagerService
	{
		Task<bool> IsManagerExistingByUserId(string userId);
	}
}
