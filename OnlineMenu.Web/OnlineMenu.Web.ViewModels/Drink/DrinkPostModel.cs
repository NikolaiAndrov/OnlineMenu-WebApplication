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

        [Required]
		[MaxLength(NameMaxLength)]
		public string Name { get; set; } = null!;

		[Required]
		public int Milliliters { get; set; }

		[Required]
		public decimal Price { get; set; }

		[Required]
		[MaxLength(DescriptionMaxLength)]
		public string Description { get; set; } = null!;

		[Required]
		[Display(Name = "Is Alcoholic")]
		public bool IsAlcoholic { get; set; }

		[Required]
		[MaxLength(ImageUrlMaxLength)]
		[Display(Name = "Image Link")]
		public string ImageUrl { get; set; } = null!;

		[Required]
		[Display(Name = "Category")]
		public int CategoryId { get; set; }

		public ICollection<DrinkCategoryPostModel> Categories { get; set; }
	}
}
