namespace OnlineMenu.Web.ViewModels.Admin
{
	using System.ComponentModel.DataAnnotations;	

	public class AdminPostModel
	{
		[Required]
		[EmailAddress]
		public string Email { get; set; } = null!;
	}
}
