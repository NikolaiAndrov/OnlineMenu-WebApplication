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

        Task<FoodCategoryPostModel> GetCategoryForEditAsync(int id);

        Task EditCategoryAsync(FoodCategoryPostModel model, int id);

        Task<FoodCategoryDeleteViewModel> GetCategoryForDeleteAsync(int id); 

        Task DeleteCategoryAsync(int id);
    }
}
