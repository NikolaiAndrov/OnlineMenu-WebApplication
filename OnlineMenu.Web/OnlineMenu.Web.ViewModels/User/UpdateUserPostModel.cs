namespace OnlineMenu.Web.ViewModels.User
{
	using System.ComponentModel.DataAnnotations;
	using static Common.EntityValidationConstants.ApplicationUserValidation;

	public class UpdateUserPostModel
	{
		[Required(AllowEmptyStrings = false)]
		[StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength)]
		[Display(Name = "First Name")]
		public string FirstName { get; set; } = null!;

		[Required(AllowEmptyStrings = false)]
		[StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength)]
		[Display(Name = "Last Name")]
		public string LastName { get; set;} = null!;
	}
}
