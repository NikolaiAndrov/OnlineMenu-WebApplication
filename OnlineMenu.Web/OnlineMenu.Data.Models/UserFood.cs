namespace OnlineMenu.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class UserFood
    {
        [Required]
        public Guid UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual ApplicationUser User { get; set; } = null!;

        [Required]
        public Guid FoodId { get; set; }

        [ForeignKey(nameof(FoodId))]
        public virtual Food Food { get; set; } = null!;
    }
}
