namespace OnlineMenu.Web.ViewModels.Drink
{
	using static Common.GeneralApplicationConstants;

	public class DrinkQueryModel
	{
        public DrinkQueryModel()
        {
			this.CurrentPage = DefaultPage;
			this.ItemsPerPage = DefaultItemsPerPage;
			this.Categories = new HashSet<string>();
			this.Drinks = new HashSet<DrinkAllViewModel>();
        }

        public string? Category { get; set; }

		public string? Keyword { get; set; }

		public int CurrentPage { get; set; }

		public int ItemsPerPage { get; set; }

		public int TotalPages { get; set; }

		public ICollection<string> Categories { get; set; }

		public ICollection<DrinkAllViewModel> Drinks { get; set; }
	}
}
