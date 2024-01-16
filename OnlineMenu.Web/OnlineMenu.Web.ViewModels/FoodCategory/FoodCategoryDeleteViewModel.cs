namespace OnlineMenu.Web.ViewModels.FoodCategory
{
	using System.ComponentModel.DataAnnotations;
	using static Common.GeneralApplicationMessages;

	public class FoodCategoryDeleteViewModel
	{
		public int Id { get; set; }

		public string Name { get; set; } = null!;

		[Display(Name = ItemsForDeleteMessage)]
		public string ItemsForDelete { get; set; } = null!; 
	}
}
