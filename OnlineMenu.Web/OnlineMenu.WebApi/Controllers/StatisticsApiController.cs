namespace OnlineMenu.WebApi.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	using OnlineMenu.Services.Interfaces;
	using OnlineMenu.Web.ViewModels.Statistics;

	[Route("api/statistics")]
	[ApiController]
	public class StatisticsApiController : ControllerBase
	{
		private readonly IFoodService foodService;
		private readonly IDrinkService drinkService;
        public StatisticsApiController(IFoodService foodService, IDrinkService drinkService)
        {
            this.foodService = foodService;
			this.drinkService = drinkService;
        }

		[HttpGet]
		[Produces("application/json")]
		[ProducesResponseType(200, Type = typeof(StatisticsViewModel))]
		[ProducesResponseType(400)]
		public async Task<IActionResult> GetStatistics()
		{
			try
			{
				int foodCount = await this.foodService.GetFoodCountAsync();
				int drinskCount = await this.drinkService.GetDrinksCountAsync();

				StatisticsViewModel model = new StatisticsViewModel
				{
					TotalFood = foodCount,
					TotalDrinks = drinskCount
				};

				return this.Ok(model);
			}
			catch (Exception)
			{
				return this.BadRequest();
			}
		}
    }
}
