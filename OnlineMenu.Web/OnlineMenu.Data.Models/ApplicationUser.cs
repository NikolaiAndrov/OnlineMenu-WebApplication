namespace OnlineMenu.Data.Models
{
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid();
            this.FavouriteDrinks = new HashSet<UserDrink>();
            this.FavourtiteFood = new HashSet<UserFood>();
        }

        public virtual ICollection<UserDrink> FavouriteDrinks { get; set; }
        public virtual ICollection<UserFood> FavourtiteFood { get; set; }
    }
}
