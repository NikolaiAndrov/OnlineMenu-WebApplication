namespace OnlineMenu.Web.ViewModels.Drink
{
	using OnlineMenu.Web.ViewModels.DrinkCategory;
	using System.ComponentModel.DataAnnotations;
	using static Common.EntityValidationConstants.DrinkValidation;

	public class DrinkPostModel
	{
        public DrinkPostModel()
        {
            this.Categories = new HashSet<DrinkCategoryPostModel>();
        }

        [Required(AllowEmptyStrings = false)]
		[StringLength(NameMaxLength, MinimumLength = NameMinLength)]
		public string Name { get; set; } = null!;

		[Required]
		[Range(MillilitersMinValue, MillilitersMaxValue)]
		public int Milliliters { get; set; }

		[Required]
		[Range(typeof(decimal), PriceMinValue, PriceMaxValue)]
		public decimal Price { get; set; }

		[Required(AllowEmptyStrings = false)]
		[StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
		public string Description { get; set; } = null!;

		[Required]
		[Display(Name = "Is Alcoholic")]
		public bool IsAlcoholic { get; set; }

		[Required(AllowEmptyStrings = false)]
		[StringLength(ImageUrlMaxLength, MinimumLength = ImageUrlMinLength)]
		[Display(Name = "Image Link")]
		public string ImageUrl { get; set; } = null!;

		[Required]
		[Display(Name = "Category")]
		public int CategoryId { get; set; }

		public ICollection<DrinkCategoryPostModel> Categories { get; set; }
	}
}
