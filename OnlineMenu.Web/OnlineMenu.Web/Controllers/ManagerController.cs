namespace OnlineMenu.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using OnlineMenu.Services.Interfaces;
    using OnlineMenu.Web.Infrastructure.Extensions;
    using static Common.NotificationConstantMessages;
    using static Common.GeneralApplicationMessages;
    using OnlineMenu.Web.ViewModels.Manager;

    [Authorize]
    public class ManagerController : Controller
    {
        private readonly IManagerService managerService;
        private readonly IUserService userService;

        public ManagerController(IManagerService managerService, IUserService userService)
        {
            this.managerService = managerService;
            this.userService = userService;

        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            bool isManager;
            bool isAdmin = this.User.IsAdmin();

            try
            {
                string userId = this.User.GetId();
                isManager = await this.managerService.IsManagerExistingByUserIdAsync(userId);
            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = UnexpectedErrorMessage;
                return this.RedirectToAction("Index", "Home");
            }

            if (!isManager && !isAdmin)
            {
                this.TempData[ErrorMessage] = NotAuthorizedMessage;
                return this.RedirectToAction("Index", "Home");
            }

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddManagerPostModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            bool isManager;
            bool isManagerExistingByEmail;
            bool isUserExistingByEmail;

            try
            {
                string userId = this.User.GetId();
                isManager = await this.managerService.IsManagerExistingByUserIdAsync(userId);
                isManagerExistingByEmail = await this.managerService.IsManagerExistingByUserEmailAsync(model.Email);
                isUserExistingByEmail = await this.userService.IsUserExistingByEmailAsync(model.Email);
            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = UnexpectedErrorMessage;
                return this.RedirectToAction("Index", "Home");
            }

            if (!isManager && !this.User.IsAdmin())
            {
                this.TempData[ErrorMessage] = NotAuthorizedMessage;
                return this.RedirectToAction("Index", "Home");
            }

            if (isManagerExistingByEmail)
            {
                this.TempData[ErrorMessage] = ExistingManagerErrorMessage;
                return this.RedirectToAction("Index", "Home");
            }

            if (!isUserExistingByEmail)
            {
                TempData[ErrorMessage] = UserNotExistingErrorMessage;
                return this.RedirectToAction("Index", "Home");
            }

            try
            {
                string userToManagerId = await this.userService.GetUserIdByEmailAsync(model.Email);
                await this.managerService.AddManagerAsync(model, userToManagerId);
            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = UnexpectedErrorMessage;
            }

            this.TempData[SuccessMessage] = ManagerAddedSuccessfullyMessage;
            return this.RedirectToAction("Index", "Home");
        }
    }
}
