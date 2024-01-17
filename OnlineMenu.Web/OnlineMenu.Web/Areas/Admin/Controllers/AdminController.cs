namespace OnlineMenu.Web.Areas.Admin.Controllers
{
	using Microsoft.AspNetCore.Identity;
	using Microsoft.AspNetCore.Mvc;
	using OnlineMenu.Data.Models;
	using OnlineMenu.Web.ViewModels.Admin;

	public class AdminController : BaseAdminController
	{
		private readonly UserManager<ApplicationUser> userManager;
        public AdminController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

		[Route("Admin/Add")]
		public IActionResult Add()
		{
			AdminPostModel model = new AdminPostModel();
			return this.View(model);
		}
	}
}
