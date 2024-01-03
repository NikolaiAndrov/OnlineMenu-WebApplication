namespace OnlineMenu.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.FoodCategoryValidation;

    public class FoodCategory
    {
        public FoodCategory()
        {
            this.Food = new HashSet<Food>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        public bool IsDeleted { get; set; }

        public virtual ICollection<Food> Food { get; set; }
    }
}
