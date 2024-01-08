namespace OnlineMenu.Web.ViewModels.Food
{
	using OnlineMenu.Web.ViewModels.FoodCategory;
	using System.ComponentModel.DataAnnotations;
	using static Common.EntityValidationConstants.FoodValidation;

	public class FoodPostModel
	{
        public FoodPostModel()
        {
			this.Categories = new HashSet<FoodCategoryPostModel>();
        }

        [Required]
		[MaxLength(NameMaxLength)]
		public string Name { get; set; } = null!;

		[Required]
		public int Weight { get; set; }

		[Required]
		public decimal Price { get; set; }

		[Required]
		[MaxLength(DescriptionMaxLength)]
		public string Description { get; set; } = null!;

		[Required]
		[MaxLength(ImageUrlMaxLength)]
		[Display(Name = "Image Link")]
		public string ImageUrl { get; set; } = null!;

		[Required]
		[Display(Name = "Category")]
		public int CategoryId { get; set; }

		public ICollection<FoodCategoryPostModel> Categories { get; set; }
	}
}
