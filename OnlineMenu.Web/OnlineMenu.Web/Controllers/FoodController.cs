namespace OnlineMenu.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class FoodController : Controller
    {
        public async Task<IActionResult> All()
        {
            return View();
        }
    }
}
