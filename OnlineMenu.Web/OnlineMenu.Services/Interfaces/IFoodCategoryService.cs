namespace OnlineMenu.Services.Interfaces
{
    using OnlineMenu.Web.ViewModels.FoodCategory;

    public interface IFoodCategoryService
    {
        Task<ICollection<string>> GetFoodCategoryNamesAsync();

        Task<ICollection<FoodCategoryPostModel>> GetFoodCategoriesPostAsync();

        Task<bool> IsCategoryExistingByIdAsync(int id);
    }
}
