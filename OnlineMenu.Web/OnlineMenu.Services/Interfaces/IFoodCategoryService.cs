namespace OnlineMenu.Services.Interfaces
{
    public interface IFoodCategoryService
    {
        Task<ICollection<string>> GetFoodCategoryNamesAsync();
    }
}
