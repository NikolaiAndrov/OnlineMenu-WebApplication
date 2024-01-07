﻿namespace OnlineMenu.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using OnlineMenu.Services.Interfaces;
    using OnlineMenu.Web.ViewModels.Food;
    using static Common.NotificationConstantMessages;
    using static Common.GeneralApplicationMessages;

    [Authorize]
    public class FoodController : Controller
    {
        private readonly IFoodService foodService;
        private readonly IFoodCategoryService foodCategoryService;

        public FoodController(IFoodService foodService, IFoodCategoryService foodCategoryService)
        {
            this.foodService = foodService;
            this.foodCategoryService = foodCategoryService;

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

        public async Task<IActionResult> Favourite()
        {
            return this.View();
        }

        public async Task<IActionResult> RemoveFromFavourite(string Id)
        {
            return this.View();
        }

        public async Task<IActionResult> AddToFavourite()
        {
            return this.View();
        }

        public async Task<IActionResult> Edit(string Id)
        {
            return this.View();
        }

        public async Task<IActionResult> Delete(string Id)
        {
            return this.View();
        }
    }
}
