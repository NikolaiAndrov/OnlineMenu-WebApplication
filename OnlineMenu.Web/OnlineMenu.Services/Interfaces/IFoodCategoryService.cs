namespace OnlineMenu.Services.Interfaces
{
    using OnlineMenu.Web.ViewModels.FoodCategory;

    public interface IFoodCategoryService
    {
        Task<ICollection<string>> GetFoodCategoryNamesAsync();

        Task<ICollection<FoodCategoryViewModel>> GetAllFoodCategoriesAsync();

        Task<bool> IsCategoryExistingByIdAsync(int id);

        Task<bool> IsCategoryExistingByNameAsync(string name);

        Task AddNewCategoryAsync(FoodCategoryPostModel model);
    }
}
