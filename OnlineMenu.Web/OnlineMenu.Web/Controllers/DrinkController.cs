namespace OnlineMenu.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class DrinkController : Controller
    {
        public async Task<IActionResult> All()
        {
            return View();
        }
    }
}
