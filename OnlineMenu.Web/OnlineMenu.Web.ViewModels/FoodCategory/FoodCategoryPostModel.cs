namespace OnlineMenu.Web.ViewModels.FoodCategory
{
	using System.ComponentModel.DataAnnotations;
	using static Common.EntityValidationConstants.FoodCategoryValidation;

	public class FoodCategoryPostModel
	{
		[Required(AllowEmptyStrings = false)]
		[StringLength(NameMaxLength, MinimumLength = NameMinLength)]
		public string Name { get; set; } = null!;
	}
}
