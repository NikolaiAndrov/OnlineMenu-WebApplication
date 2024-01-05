namespace OnlineMenu.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class ManagerController : Controller
    {
        public async Task<IActionResult> Add()
        {
            return View();
        }
    }
}
