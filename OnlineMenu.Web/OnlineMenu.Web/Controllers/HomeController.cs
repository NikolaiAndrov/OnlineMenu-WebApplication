namespace OnlineMenu.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using OnlineMenu.Services.Interfaces;
    using OnlineMenu.Web.ViewModels.Home;
    using System.Diagnostics;
    using static Common.NotificationConstantMessages;
    using static Common.GeneralApplicationMessages;

    public class HomeController : Controller
    {
        private readonly IFoodService foodService;

        public HomeController(IFoodService foodService)
        {
            this.foodService = foodService;
        }

        public async Task<IActionResult> Index()
        {

            ICollection<IndexViewModel> indexFood;

            try
            {
                indexFood = await this.foodService.GetFoodForIndexAsync();
            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = UnexpectedErrorMessage;
                return this.RedirectToAction("Login", "Account");
            }

            return this.View(indexFood);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
