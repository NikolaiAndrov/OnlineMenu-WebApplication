namespace OnlineMenu.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using OnlineMenu.Services.Interfaces;
    using OnlineMenu.Web.Infrastructure.Extensions;
    using static Common.NotificationConstantMessages;
    using static Common.GeneralApplicationMessages;

    [Authorize]
    public class ManagerController : Controller
    {
        private readonly IManagerService managerService;

        public ManagerController(IManagerService managerService)
        {
            this.managerService = managerService;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            string userId = this.User.GetId();
            bool isManager = await this.managerService.IsManagerExistingByUserId(userId);

            if (!isManager)
            {
                this.TempData[ErrorMessage] = NotAuthorizedMessage;
                return this.RedirectToAction("Index", "Home");
            }

            return this.View();
        }
    }
}
