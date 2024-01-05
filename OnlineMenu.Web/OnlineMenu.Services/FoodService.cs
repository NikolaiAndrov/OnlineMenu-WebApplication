namespace OnlineMenu.Services
{
    using Microsoft.EntityFrameworkCore;
    using OnlineMenu.Data;
    using OnlineMenu.Services.Interfaces;
    using OnlineMenu.Web.ViewModels.Home;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class FoodService : IFoodService
    {
        private readonly OnlineMenuDbContext dbContext;

        public FoodService(OnlineMenuDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ICollection<IndexViewModel>> GetFoodForIndexAsync()
        {
            ICollection<IndexViewModel> indexFood = await this.dbContext.Food
                .Where(f => f.Category.Name == "Desserts" || f.Category.Name == "Burgers")
                .Select(f => new IndexViewModel
                {
                    Id = f.Id.ToString(),
                    Name = f.Name,
                    ImageUrl = f.ImageUrl
                })
                .ToArrayAsync();

            return indexFood;
        }
    }
}
