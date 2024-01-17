namespace OnlineMenu.Web.ViewModels.Manager
{
	using System.ComponentModel.DataAnnotations;

	public class RemoveManagerPostModel
	{
		[Required]
		[EmailAddress]
		public string Email { get; set; } = null!;
	}
}
