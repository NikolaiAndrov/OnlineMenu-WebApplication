namespace OnlineMenu.Services.Interfaces
{
    using OnlineMenu.Web.ViewModels.Food;
    using OnlineMenu.Web.ViewModels.Home;

    public interface IFoodService
    {
        Task<ICollection<IndexViewModel>> GetFoodForIndexAsync();

        Task<FoodQueryModel> GetAllFoodByQueryModelAsync(FoodQueryModel foodQueryModel);
    }
}
