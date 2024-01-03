namespace OnlineMenu.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class UserFood
    {
        [Required]
        public Guid ApplicationUserId { get; set; }

        [ForeignKey(nameof(ApplicationUserId))]
        public virtual ApplicationUser User { get; set; } = null!;

        [Required]
        public Guid FoodId { get; set; }

        [ForeignKey(nameof(FoodId))]
        public virtual Food Food { get; set; } = null!;
    }
}
