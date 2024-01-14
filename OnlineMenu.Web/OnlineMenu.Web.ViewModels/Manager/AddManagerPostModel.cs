namespace OnlineMenu.Web.ViewModels.Manager
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.ManagerValidation;

    public class AddManagerPostModel
    {
        [Required(AllowEmptyStrings = false)]
        [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength)]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
    }
}
