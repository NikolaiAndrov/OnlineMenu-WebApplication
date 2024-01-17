namespace OnlineMenu.Web.ViewModels.DrinkCategory
{
	using System.ComponentModel.DataAnnotations;
	using static Common.GeneralApplicationMessages;

	public class DrinkCategoryDeleteViewModel
	{
		public int Id { get; set; }

		public string Name { get; set; } = null!;

		[Display(Name = ItemsForDeleteMessage)]
		public string ItemsForDelete { get; set; } = null!;
	}
}
