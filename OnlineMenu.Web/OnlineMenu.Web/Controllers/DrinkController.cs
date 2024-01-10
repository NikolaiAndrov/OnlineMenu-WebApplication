namespace OnlineMenu.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
	using OnlineMenu.Services.Interfaces;
	using OnlineMenu.Web.Infrastructure.Extensions;
	using OnlineMenu.Web.ViewModels.Drink;
    using static Common.GeneralApplicationMessages;
    using static Common.NotificationConstantMessages;

	[Authorize]
    public class DrinkController : Controller
    {
        private readonly IDrinkService drinkService;
        private readonly IDrinkCategoryService drinkCategoryService;
        private readonly IManagerService managerService;

        public DrinkController(IDrinkService drinkService, IDrinkCategoryService drinkCategoryService, IManagerService managerService)
        {
            this.drinkService = drinkService;
            this.drinkCategoryService = drinkCategoryService;
            this.managerService = managerService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> All(DrinkQueryModel drinkQueryModel)
        {
            try
            {
                await this.drinkService.GetAllDrinksByQueryModelAsync(drinkQueryModel);
                drinkQueryModel.Categories = await this.drinkCategoryService.GetDrinkCategoryNamesAsync();
            }
            catch (Exception)
            {
				this.TempData[ErrorMessage] = UnexpectedErrorMessage;
				return this.RedirectToAction("Index", "Home");
			}

            return this.View(drinkQueryModel);
        }

        [HttpGet]
        public async Task<IActionResult> Favourite()
        {
            ICollection<DrinkAllViewModel> favouriteDrinks;

            try
            {
                favouriteDrinks = await this.drinkService.GetFavouriteDrinksAsync(this.User.GetId());
            }
            catch (Exception)
            {
				TempData[ErrorMessage] = UnexpectedErrorMessage;
				return this.RedirectToAction("Index", "Home");
			}

            return this.View(favouriteDrinks);
        }

        [HttpGet]
        public async Task<IActionResult> RemoveFromFavourite(string Id)
        {
			bool isDrinkExisting;

			try
			{
				isDrinkExisting = await this.drinkService.IsDrinkExistingByIdAsync(Id);
			}
			catch (Exception)
			{
				this.TempData[ErrorMessage] = UnexpectedErrorMessage;
				return this.RedirectToAction("Index", "Home");
			}

			if (!isDrinkExisting)
			{
				this.TempData[ErrorMessage] = ItemNotFoundMessage;
				return this.RedirectToAction("Index", "Home");
			}

            try
            {
                string userId = this.User.GetId();
                await this.drinkService.RemoveFromFavouriteAsync(Id, userId);
            }
            catch (Exception)
            {
				this.TempData[ErrorMessage] = UnexpectedErrorMessage;
				return this.RedirectToAction("Index", "Home");
			}

            this.TempData[SuccessMessage] = ItemRemovedFromFavouriteMessage;
            return this.RedirectToAction("Favourite", "Drink");
		}

        [HttpGet]
        public async Task<IActionResult> AddToFavourite(string Id)
        {
            bool isDrinkExisting;

            try
            {
                isDrinkExisting = await this.drinkService.IsDrinkExistingByIdAsync(Id);
            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = UnexpectedErrorMessage;
                return this.RedirectToAction("Index", "Home");
            }

            if (!isDrinkExisting)
            {
                this.TempData[ErrorMessage] = ItemNotFoundMessage;
				return this.RedirectToAction("Index", "Home");
			}

            try
            {
                string userId = this.User.GetId();
                await this.drinkService.AddToFavouriteAsync(Id, userId);
            }
            catch (Exception)
            {
				this.TempData[ErrorMessage] = UnexpectedErrorMessage;
				return this.RedirectToAction("Index", "Home");
			}

            this.TempData[SuccessMessage] = ItemAddedToFavouriteMessage;
            return this.RedirectToAction("Favourite", "Drink");
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            bool isManager;
            DrinkPostModel model = new DrinkPostModel();

            try
            {
                isManager = await this.managerService.IsManagerExistingByUserIdAsync(this.User.GetId());
				model.Categories = await this.drinkCategoryService.GetDrinkCategoriesPostAsync();
			}
            catch (Exception)
            {
                this.TempData[ErrorMessage] = UnexpectedErrorMessage;
                return this.RedirectToAction("Index", "Home");
            }

            if (!isManager)
            {
                this.TempData[ErrorMessage] = NotAuthorizedMessage;
				return this.RedirectToAction("Index", "Home");
			}

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(DrinkPostModel model)
        {
            bool isManager;
            bool isCategoryExisting;

            try
            {
                isManager = await this.managerService.IsManagerExistingByUserIdAsync(this.User.GetId());
                isCategoryExisting = await this.drinkCategoryService.IsCategoryExistingByIdAsync(model.CategoryId);
            }
            catch (Exception)
            {
				this.TempData[ErrorMessage] = UnexpectedErrorMessage;
				return this.RedirectToAction("Index", "Home");
			}

            if (!isManager)
            {
                this.TempData[ErrorMessage] = NotAuthorizedMessage;
                return this.RedirectToAction("Index", "Home");
			}

            if (!isCategoryExisting)
            {
                this.ModelState.AddModelError(nameof(model.CategoryId), CategoryNotExistingMessage);
            }

            if (!this.ModelState.IsValid)
            {
                try
                {
                    model.Categories = await this.drinkCategoryService.GetDrinkCategoriesPostAsync();
                }
                catch (Exception)
                {
					this.TempData[ErrorMessage] = UnexpectedErrorMessage;
					return this.RedirectToAction("Index", "Home");
				}

                return this.View(model);
            }

            try
            {
                await this.drinkService.AddDrinkAsync(model);
            }
            catch (Exception)
            {
				this.TempData[ErrorMessage] = UnexpectedErrorMessage;
				return this.RedirectToAction("Index", "Home");
			}

            this.TempData[SuccessMessage] = NewItemAddedMessage;
            return this.RedirectToAction("All", "Drink");
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(string id)
        {
            bool isDrinkExisting;

            try
            {
                isDrinkExisting = await this.drinkService.IsDrinkExistingByIdAsync(id);
            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = UnexpectedErrorMessage;
                return this.RedirectToAction("Index", "Home");
            }

            if (!isDrinkExisting)
            {
                this.TempData[ErrorMessage] = ItemNotFoundMessage;
				return this.RedirectToAction("All", "Drink");
			}

            DrinkDetailsViewModel model;

            try
            {
                model = await this.drinkService.GetDrinkDetailsAsync(id);
            }
            catch (Exception)
            {
				this.TempData[ErrorMessage] = UnexpectedErrorMessage;
				return this.RedirectToAction("Index", "Home");
			}

            return this.View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string Id)
        {
            bool isManager;
            bool isDrinkExisting;

            try
            {
                isManager = await this.managerService.IsManagerExistingByUserIdAsync(this.User.GetId());
                isDrinkExisting = await this.drinkService.IsDrinkExistingByIdAsync(Id);
            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = UnexpectedErrorMessage;
                return this.RedirectToAction("Index", "Home");
            }

            if (!isManager)
            {
                this.TempData[ErrorMessage] = NotAuthorizedMessage;
                return this.RedirectToAction("Index", "Home");
            }

            if (!isDrinkExisting)
            {
                this.TempData[ErrorMessage] = ItemNotFoundMessage;
                return this.RedirectToAction("All", "Drink");
            }

            DrinkPostModel model;

            try
            {
                model = await this.drinkService.GetDrinkForEditAsync(Id);
                model.Categories = await this.drinkCategoryService.GetDrinkCategoriesPostAsync();
            }
            catch (Exception)
            {
				this.TempData[ErrorMessage] = UnexpectedErrorMessage;
				return this.RedirectToAction("Index", "Home");
			}

            this.TempData[InfoMessage] = ItemReadyForEdit;
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string Id, DrinkPostModel model)
        {
			bool isManager;
			bool isDrinkExisting;
            bool isDrinkCategoryExisting; ;

			try
			{
				isManager = await this.managerService.IsManagerExistingByUserIdAsync(this.User.GetId());
				isDrinkExisting = await this.drinkService.IsDrinkExistingByIdAsync(Id);
                isDrinkCategoryExisting = await this.drinkCategoryService.IsCategoryExistingByIdAsync(model.CategoryId);
			}
			catch (Exception)
			{
				this.TempData[ErrorMessage] = UnexpectedErrorMessage;
				return this.RedirectToAction("Index", "Home");
			}

			if (!isManager)
			{
				this.TempData[ErrorMessage] = NotAuthorizedMessage;
				return this.RedirectToAction("Index", "Home");
			}

			if (!isDrinkExisting)
			{
				this.TempData[ErrorMessage] = ItemNotFoundMessage;
				return this.RedirectToAction("All", "Drink");
			}

            if (!isDrinkCategoryExisting)
            {
                this.ModelState.AddModelError(nameof(model.CategoryId), CategoryNotExistingMessage);
            }

            if (!this.ModelState.IsValid)
            {
                try
                {
                    model.Categories = await this.drinkCategoryService.GetDrinkCategoriesPostAsync();
                }
                catch (Exception)
                {
					this.TempData[ErrorMessage] = UnexpectedErrorMessage;
					return this.RedirectToAction("Index", "Home");
				}

                return this.View(model);
            }

            try
            {
                await this.drinkService.EditDrinkAsync(Id, model);
            }
            catch (Exception)
            {
				this.TempData[ErrorMessage] = UnexpectedErrorMessage;
				return this.RedirectToAction("Index", "Home");
			}

            this.TempData[SuccessMessage] = ItemEditedMessage;
            return this.RedirectToAction("Details", "Drink", new { Id });
        }

        public async Task<IActionResult> Delete(string Id)
        {
			bool isManager;
			bool isDrinkExisting;

			try
			{
				isManager = await this.managerService.IsManagerExistingByUserIdAsync(this.User.GetId());
				isDrinkExisting = await this.drinkService.IsDrinkExistingByIdAsync(Id);
			}
			catch (Exception)
			{
				this.TempData[ErrorMessage] = UnexpectedErrorMessage;
				return this.RedirectToAction("Index", "Home");
			}

			if (!isManager)
			{
				this.TempData[ErrorMessage] = NotAuthorizedMessage;
				return this.RedirectToAction("Index", "Home");
			}

			if (!isDrinkExisting)
			{
				this.TempData[ErrorMessage] = ItemNotFoundMessage;
				return this.RedirectToAction("Index", "Home");
			}

			try
			{
				await this.drinkService.DeleteAsync(Id);
			}
			catch (Exception)
			{
				this.TempData[ErrorMessage] = UnexpectedErrorMessage;
				return this.RedirectToAction("Index", "Home");
			}

			this.TempData[SuccessMessage] = ItemDeletedMessage;
			return this.RedirectToAction("All", "Drink");
		}
    }
}
