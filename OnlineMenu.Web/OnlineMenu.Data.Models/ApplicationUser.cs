namespace OnlineMenu.Data.Models
{
    using Microsoft.AspNetCore.Identity;
	using System.ComponentModel.DataAnnotations;
	using static Common.EntityValidationConstants.ApplicationUserValidation;

    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid();
            this.FavouriteDrinks = new HashSet<UserDrink>();
            this.FavourtiteFood = new HashSet<UserFood>();
        }

        [Required]
        [MaxLength(FirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(LastNameMaxLength)]
        public string LastName { get; set; } = null!;

        public virtual ICollection<UserDrink> FavouriteDrinks { get; set; }
        public virtual ICollection<UserFood> FavourtiteFood { get; set; }
    }
}
