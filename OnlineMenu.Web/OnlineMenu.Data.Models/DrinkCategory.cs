namespace OnlineMenu.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.DrinkCategoryValidation;

    public class DrinkCategory
    {
        public DrinkCategory()
        {
            this.Drinks = new HashSet<Drink>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        public bool IsDeleted { get; set; }

        public virtual ICollection<Drink> Drinks { get; set; }
    }
}
