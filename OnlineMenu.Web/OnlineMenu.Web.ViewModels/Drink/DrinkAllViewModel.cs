namespace OnlineMenu.Web.ViewModels.Drink
{
	public class DrinkAllViewModel
	{
		public string Id { get; set; } = null!;

		public string Name { get; set; } = null!;

		public string Category { get; set; } = null!;

		public bool IsAlcoholic { get; set; } 

		public int Milliliters { get; set; }

		public decimal Price { get; set; }

		public string ImageUrl { get; set; } = null!;
	}
}
