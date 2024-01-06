namespace OnlineMenu.Web.ViewModels.Food
{
    using static Common.GeneralApplicationConstants;

    public class FoodQueryModel
    {
        public FoodQueryModel()
        {
            this.CurrentPage = DefaultPage;
            this.ItemsPerPage = DefaultItemsPerPage;
            this.Categories = new HashSet<string>();
            this.FoodAll = new HashSet<FoodAllViewModel>();
        }

        public string? Category { get; set; }

        public string? Keyword { get; set; }

        public int CurrentPage { get; set; }

        public int ItemsPerPage { get; set; }

        public int TotalItems {  get; set; }

        public ICollection<string> Categories { get; set; }

        public ICollection<FoodAllViewModel> FoodAll {  get; set; }
    }
}
