namespace OnlineMenu.Web.ViewModels.Food
{
	using OnlineMenu.Web.ViewModels.FoodCategory;
	using System.ComponentModel.DataAnnotations;
	using static Common.EntityValidationConstants.FoodValidation;

	public class FoodPostModel
	{
        public FoodPostModel()
        {
			this.Categories = new HashSet<FoodCategoryViewModel>();
        }

        [Required(AllowEmptyStrings = false)]
		[StringLength(NameMaxLength, MinimumLength = NameMinLength)]
		public string Name { get; set; } = null!;

		[Required]
		[Range(WeightMinValue, WeightMaxValue)]
		public int Weight { get; set; }

		[Required]
		[Range(typeof(decimal), PriceMinValue, PriceMaxValue)]
		public decimal Price { get; set; }

		[Required(AllowEmptyStrings = false)]
		[StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
		public string Description { get; set; } = null!;

		[Required(AllowEmptyStrings = false)]
		[StringLength(ImageUrlMaxLength, MinimumLength = ImageUrlMinLength)]
		[Display(Name = "Image Link")]
		public string ImageUrl { get; set; } = null!;

		[Required]
		[Display(Name = "Category")]
		public int CategoryId { get; set; }

		public ICollection<FoodCategoryViewModel> Categories { get; set; }
	}
}
