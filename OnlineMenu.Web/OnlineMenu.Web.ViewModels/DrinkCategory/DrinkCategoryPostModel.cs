namespace OnlineMenu.Web.ViewModels.DrinkCategory
{
	using System.ComponentModel.DataAnnotations;
	using static Common.EntityValidationConstants.DrinkCategoryValidation;

	public class DrinkCategoryPostModel
	{
		[Required(AllowEmptyStrings = false)]
		[StringLength(NameMaxLength, MinimumLength = NameMinLength)]
		public string Name { get; set; } = null!;
	}
}
