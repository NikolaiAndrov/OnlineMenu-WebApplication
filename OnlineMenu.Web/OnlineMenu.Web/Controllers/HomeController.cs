namespace OnlineMenu.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using OnlineMenu.Services.Interfaces;
    using OnlineMenu.Web.ViewModels.Home;
    using System.Diagnostics;

    public class HomeController : Controller
    {
        private readonly IFoodService foodService;

        public HomeController(IFoodService foodService)
        {
            this.foodService = foodService;
        }

        public async Task<IActionResult> Index()
        {
            ICollection<IndexViewModel> indexFood = await this.foodService.GetFoodForIndexAsync();
            return View(indexFood);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
