namespace OnlineMenu.Web.ViewModels.Food
{
    public class FoodAllViewModel
    {
        public string Id { get; set; } = null!;

        public string Name { get; set; } = null!;

        public int Weight { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; } = null!;
    }
}
