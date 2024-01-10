namespace OnlineMenu.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using OnlineMenu.Services.Interfaces;
    using OnlineMenu.Web.ViewModels.Food;
    using static Common.NotificationConstantMessages;
    using static Common.GeneralApplicationMessages;
	using OnlineMenu.Web.Infrastructure.Extensions;
	using Microsoft.AspNetCore.Mvc.ModelBinding;

	[Authorize]
    public class FoodController : Controller
    {
        private readonly IFoodService foodService;
        private readonly IFoodCategoryService foodCategoryService;
        private readonly IManagerService managerService;

        public FoodController(IFoodService foodService, IFoodCategoryService foodCategoryService, IManagerService managerService)
        {
            this.foodService = foodService;
            this.foodCategoryService = foodCategoryService;
            this.managerService = managerService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> All([FromQuery]FoodQueryModel foodQueryModel)
        {
            try
            {
                await this.foodService.GetAllFoodByQueryModelAsync(foodQueryModel);
                foodQueryModel.Categories = await this.foodCategoryService.GetFoodCategoryNamesAsync();
            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = UnexpectedErrorMessage;
                return this.RedirectToAction("Index", "Home");
            }

            return this.View(foodQueryModel);
        }

        [HttpGet]
        public async Task<IActionResult> Favourite()
        {
            ICollection<FoodAllViewModel> favouriteFood;

            try
            {
                favouriteFood = await this.foodService.GetFavouriteFoodAsync(this.User.GetId());
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = UnexpectedErrorMessage;
                return this.RedirectToAction("Index", "Home");
            }

            return this.View(favouriteFood);
        }

        [HttpGet]
        public async Task<IActionResult> RemoveFromFavourite(string Id)
        {
			bool isFoodExisting;

			try
			{
				isFoodExisting = await this.foodService.IsFoodExistingByIdAsync(Id);
			}
			catch (Exception)
			{
				this.TempData[ErrorMessage] = UnexpectedErrorMessage;
				return this.RedirectToAction("Index", "Home");
			}

			if (!isFoodExisting)
			{
				this.TempData[ErrorMessage] = ItemNotFoundMessage;
				return this.RedirectToAction("Index", "Home");
			}

            try
            {
                string userId = this.User.GetId();
                await this.foodService.RemoveFromFavouriteAsync(Id, userId);
            }
            catch (Exception)
            {
				this.TempData[ErrorMessage] = UnexpectedErrorMessage;
				return this.RedirectToAction("Index", "Home");
			}

            this.TempData[SuccessMessage] = ItemRemovedFromFavouriteMessage;
			return this.RedirectToAction("Favourite", "Food");
		}

        public async Task<IActionResult> AddToFavourite(string Id)
        {
            bool isFoodExisting;

            try
            {
                isFoodExisting = await this.foodService.IsFoodExistingByIdAsync(Id);
            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = UnexpectedErrorMessage;
				return this.RedirectToAction("Index", "Home");
			}

            if (!isFoodExisting)
            {
				this.TempData[ErrorMessage] = ItemNotFoundMessage;
				return this.RedirectToAction("Index", "Home");
			}

            try
            {
                string userId = this.User.GetId();
                await this.foodService.AddToFavouriteAsync(Id, userId);
            }
            catch (Exception)
            {
				this.TempData[ErrorMessage] = UnexpectedErrorMessage;
				return this.RedirectToAction("Index", "Home");
			}

            this.TempData[SuccessMessage] = ItemAddedToFavouriteMessage;
            return this.RedirectToAction("Favourite", "Food");
        }

		[HttpGet]
		public async Task<IActionResult> Add()
		{
            bool isManager;
            FoodPostModel model = new FoodPostModel();

            try
            {
                isManager = await this.managerService.IsManagerExistingByUserIdAsync(this.User.GetId());
                model.Categories = await this.foodCategoryService.GetFoodCategoriesPostAsync();
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
        public async Task<IActionResult> Add(FoodPostModel model)
        {
            bool isManager;
            bool isCategoryExisting;

            try
            {
                isManager = await this.managerService.IsManagerExistingByUserIdAsync(this.User.GetId());
                isCategoryExisting = await this.foodCategoryService.IsCategoryExistingByIdAsync(model.CategoryId);
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
                    model.Categories = await this.foodCategoryService.GetFoodCategoriesPostAsync();
                }
                catch (Exception)
                {
                    this.TempData[ErrorMessage] = UnexpectedErrorMessage;
                    return this.RedirectToAction("Index", "Home");
                }

                return this.View(model);
            }

            string id;

			try
            {
                id = await this.foodService.AddFoodAndReturnIdAsync(model);
            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = UnexpectedErrorMessage;
                return this.RedirectToAction("Index", "Home");
            }

            this.TempData[SuccessMessage] = NewItemAddedMessage;
            return this.RedirectToAction("Details", "Food", new { id });
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(string id)
        {
            bool isFoodExisting;

            try
            {
                isFoodExisting = await this.foodService.IsFoodExistingByIdAsync(id);
            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = UnexpectedErrorMessage;
                return this.RedirectToAction("Index", "Home");
            }

            if (!isFoodExisting)
            {
				this.TempData[ErrorMessage] = ItemNotFoundMessage;
				return this.RedirectToAction("All", "Food");
			}

            FoodDetailsViewModel model;

            try
            {
                model = await this.foodService.GetFoodDetailsAsync(id);
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
            bool isFoodExisting;

            try
            {
                isManager = await this.managerService.IsManagerExistingByUserIdAsync(this.User.GetId());
                isFoodExisting = await this.foodService.IsFoodExistingByIdAsync(Id);
            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = UnexpectedErrorMessage;
                return this.RedirectToAction("Index", "Home");
            }

            if (!isFoodExisting)
            {
                this.TempData[ErrorMessage] = ItemNotFoundMessage;
				return this.RedirectToAction("All", "Food");
			}

            if (!isManager)
            {
                this.TempData[ErrorMessage] = NotAuthorizedMessage;
				return this.RedirectToAction("Index", "Home");
			}

            FoodPostModel model;

            try
            {
                model = await this.foodService.GetFoodForEditAsync(Id);
                model.Categories = await this.foodCategoryService.GetFoodCategoriesPostAsync();
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
        public async Task<IActionResult> Edit(string Id, FoodPostModel model)
        {
			bool isManager;
			bool isFoodExisting;
            bool isFoodCategoryExisting;

			try
			{
				isManager = await this.managerService.IsManagerExistingByUserIdAsync(this.User.GetId());
				isFoodExisting = await this.foodService.IsFoodExistingByIdAsync(Id);
                isFoodCategoryExisting = await this.foodCategoryService.IsCategoryExistingByIdAsync(model.CategoryId);
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

			if (!isFoodExisting)
			{
				this.TempData[ErrorMessage] = ItemNotFoundMessage;
				return this.RedirectToAction("All", "Food");
			}


            if (!isFoodCategoryExisting)
            {
                this.ModelState.AddModelError(nameof(model.CategoryId), CategoryNotExistingMessage);
            }

            if (!this.ModelState.IsValid)
            {
                try
                {
                    model.Categories = await this.foodCategoryService.GetFoodCategoriesPostAsync();
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
                await this.foodService.EditFoodAsync(Id, model);
            }
            catch (Exception)
            {
				this.TempData[ErrorMessage] = UnexpectedErrorMessage;
				return this.RedirectToAction("Index", "Home");
			}

            this.TempData[SuccessMessage] = ItemEditedMessage;
            return this.RedirectToAction("Details", "Food", new { Id });
        }

        public async Task<IActionResult> Delete(string Id)
        {
            return this.View();
        }
    }
}
