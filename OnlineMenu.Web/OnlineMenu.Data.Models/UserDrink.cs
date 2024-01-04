namespace OnlineMenu.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    public class UserDrink
    {
        [Required]
        public Guid UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual ApplicationUser User { get; set; } = null!;

        [Required]
        public Guid DrinkId { get; set; }

        [ForeignKey(nameof(DrinkId))]
        public virtual Drink Drink { get; set; } = null!;
    }
}
