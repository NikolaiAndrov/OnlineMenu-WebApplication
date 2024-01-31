namespace OnlineMenu.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using OnlineMenu.Services.Interfaces;
    using OnlineMenu.Web.ViewModels.Home;
	using OnlineMenu.Web.Infrastructure.Extensions;
    using static Common.NotificationConstantMessages;
    using static Common.GeneralApplicationMessages;
    using static Common.GeneralApplicationConstants;

	public class HomeController : Controller
    {
        private readonly IFoodService foodService;

        public HomeController(IFoodService foodService)
        {
            this.foodService = foodService;
        }

        public async Task<IActionResult> Index()
        {
            if (this.User.IsAdmin())
            {
                return this.RedirectToAction("Index", "Home", new { Area = AdminAreaName });
            }

            ICollection<IndexViewModel> indexFood;

            try
            {
                indexFood = await this.foodService.GetFoodForIndexAsync();
            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = UnexpectedErrorMessage;
                return this.RedirectToAction("All", "Food");
            }

            return this.View(indexFood);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            if (statusCode == 400 || statusCode == 404)
            {
                return this.View("Error404");
            }

            if (statusCode == 401)
            {
                return this.View("Error401");
            }

            return View();
        }
    }
}
