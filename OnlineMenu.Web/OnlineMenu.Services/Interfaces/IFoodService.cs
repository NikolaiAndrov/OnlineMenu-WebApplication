namespace OnlineMenu.Services.Interfaces
{
    using OnlineMenu.Web.ViewModels.Food;
    using OnlineMenu.Web.ViewModels.Home;

    public interface IFoodService
    {
        Task<ICollection<IndexViewModel>> GetFoodForIndexAsync();

        Task<FoodQueryModel> GetAllFoodByQueryModelAsync(FoodQueryModel foodQueryModel);

        Task<ICollection<FoodAllViewModel>> GetFavouriteFoodAsync(string userId);

        Task AddToFavouriteAsync(string foodId, string userId);

        Task<bool> IsFoodExistingByIdAsync(string foodId);

        Task RemoveFromFavouriteAsync(string foodId, string userId);

        Task<string> AddFoodAndReturnIdAsync(FoodPostModel model);

        Task<FoodDetailsViewModel> GetFoodDetailsAsync(string foodId);

        Task<FoodPostModel> GetFoodForEditAsync(string foodId);

        Task EditFoodAsync(string foodId, FoodPostModel model);

        Task<FoodDeleteViewModel> GetFoodForDeleteAsync(string foodId);

        Task DeleteFoodAsync(string foodId);

        Task<bool> IsFoodInFavouriteAsync(string userId, string foodId);
    }
}
